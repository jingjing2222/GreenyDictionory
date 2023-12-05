using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Renci.SshNet;
using MySql.Data.MySqlClient;

namespace team10_24
{

    public partial class Form10 : Form
    {
        // 데이터베이스 연결 문자열
        private string connectionString = "server=webp.flykorea.kr; user=hpjw; database=hpjwDB; port=13306; password=qwer!@!@1234;";
        private DatabaseManager dbManager;
        private static readonly Dictionary<string, string> colorMapping = DatabaseManager.colorMapping;
        private static readonly Dictionary<string, string> seasonMapping = DatabaseManager.seasonMapping;
        private int plantId;

        // 기본 생성자
        public Form10()
        {
            InitializeComponent();
            LoadImageFromServer();
        }

        // 식물 정보를 가진 생성자
        public Form10(int plantId, string plantName, string plantColor, string bloomSeason)
        {
            InitializeComponent();
            dbManager = new DatabaseManager(); // DatabaseManager 인스턴스 초기화
            this.plantId = plantId;
            name_add.Text = plantName;
            SetRadioColor(plantColor);
            SetRadioSeason(bloomSeason);
            LoadImageFromServer();
        }

        // 식물 ID에 해당하는 이미지 파일명을 반환하는 메서드
        public string GetImageFileName(int plantId)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var query = "SELECT plant_name FROM PlantTable WHERE plant_id = @plantId";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@plantId", plantId);
                    var result = cmd.ExecuteScalar();
                    return result?.ToString();
                }
            }
        }

        // 서버에서 이미지를 로드하는 메서드
        private void LoadImageFromServer()
        {
            string host = "webp.flykorea.kr";
            string username = "hpjw";
            string password = "qwer!@!@12347";
            int port = 13022;
            string imageFileName = GetImageFileName(plantId);
            string remoteFileName = "/home/hpjw/식물 이미지/" + imageFileName + ".jpg";

            try
            {
                using (var sftp = new SftpClient(host, port, username, password))
                {
                    sftp.Connect();
                    using (var memoryStream = new MemoryStream())
                    {
                        sftp.DownloadFile(remoteFileName, memoryStream);
                        memoryStream.Position = 0;

                        PlantImage.Image = Image.FromStream(memoryStream);
                        PlantImage.SizeMode = PictureBoxSizeMode.StretchImage; // 이미지 사이즈 모드 설정
                    }
                    sftp.Disconnect();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SFTP 파일 다운로드 실패: " + ex.Message);
            }
        }

        // 추가 버튼 클릭 이벤트 핸들러
        private void Add_Click(object sender, EventArgs e)
        {
            // 추가 버튼 클릭 시 로직
        }

        // 뒤로 가기 버튼 클릭 이벤트 핸들러
        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
            Form4 form4 = new Form4();
            form4.Show();
        }

        // 색상 라디오 버튼 설정 메서드
        private void SetRadioColor(string colorValue)
        {
            string englishColor = GetEnglishValueFromKorean(colorMapping, colorValue);
            CheckRadioButton(groupBoxColors, englishColor);
        }

        // 계절 라디오 버튼 설정 메서드
        private void SetRadioSeason(string seasonValue)
        {
            string englishSeason = GetEnglishValueFromKorean(seasonMapping, seasonValue);
            CheckRadioButton(groupBoxSeasons, englishSeason);
        }

        // 한국어 값을 영어 값으로 변환하는 메서드
        private string GetEnglishValueFromKorean(Dictionary<string, string> mapping, string koreanValue)
        {
            return mapping.FirstOrDefault(x => x.Value == koreanValue).Key;
        }

        // 라디오 버튼을 체크하는 메서드
        private void CheckRadioButton(GroupBox groupBox, string radioButtonName)
        {
            foreach (Control control in groupBox.Controls)
            {
                if (control is RadioButton rb && rb.Name == radioButtonName)
                {
                    rb.Checked = true;
                    break;
                }
            }
        }

        // 수정 버튼 클릭 이벤트 핸들러
        private void Modify_Click(object sender, EventArgs e)
        {
            string newName = name_add.Text;

            // RadioButton의 이름을 한국어 값으로 변환
            string newColorEnglish = GetSelectedRadioButtonValue(groupBoxColors);
            string newSeasonEnglish = GetSelectedRadioButtonValue(groupBoxSeasons);
            string newColor = colorMapping.FirstOrDefault(x => x.Key == newColorEnglish).Value;
            string newSeason = seasonMapping.FirstOrDefault(x => x.Key == newSeasonEnglish).Value;

            if (!dbManager.CheckIfPlantExists(newName, newColor, newSeason))
            {
                bool isUpdated = dbManager.UpdatePlantData(plantId, newName, newColor, newSeason);
                if (isUpdated)
                {
                    MessageBox.Show("식물 데이터가 성공적으로 수정되었습니다.");
                }
                else
                {
                    MessageBox.Show("식물 데이터 수정에 실패했습니다.");
                }
            }
            else
            {
                MessageBox.Show("동일한 이름, 색상, 계절의 식물이 이미 존재합니다.");
            }
        }

        // 선택된 라디오 버튼의 값을 반환하는 메서드
        private string GetSelectedRadioButtonValue(GroupBox groupBox)
        {
            foreach (Control control in groupBox.Controls)
            {
                if (control is RadioButton rb && rb.Checked)
                {
                    return rb.Name; // 라디오 버튼의 Name 속성을 반환
                }
            }
            return null; // 선택된 라디오 버튼이 없는 경우
        }

        // 삭제 버튼 클릭 이벤트 핸들러
        private void Delete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("이 식물을 삭제하시겠습니까?", "삭제 확인", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (dbManager.DeletePlantData(plantId))
                {
                    MessageBox.Show("식물 데이터가 성공적으로 삭제되었습니다.");
                    this.Close(); // Form10 창을 닫음
                    Form4 form4 = new Form4();
                    form4.Show();
                }
                else
                {
                    MessageBox.Show("식물 데이터 삭제에 실패했습니다.");
                }
            }
        }

        // 북마크 버튼 클릭 이벤트 핸들러
        private void bookmark_Click(object sender, EventArgs e)
        {
            int loggedInUserId = UserSession.Instance.UserId; // 현재 로그인한 사용자의 uid를 가져옴

            if (dbManager.CheckBookmarkExists(loggedInUserId, plantId))
            {
                if (dbManager.DeleteBookmark(loggedInUserId, plantId))
                {
                    MessageBox.Show("북마크가 삭제되었습니다.");
                }
                else
                {
                    MessageBox.Show("북마크 삭제에 실패했습니다.");
                }
            }
            else
            {
                if (dbManager.AddBookmark(loggedInUserId, plantId))
                {
                    MessageBox.Show("북마크 추가에 성공했습니다.");
                }
                else
                {
                    MessageBox.Show("북마크 추가에 실패했습니다.");
                }
            }
        }

        private void review_Click(object sender, EventArgs e)
        {
            DatabaseManager dbManager = new DatabaseManager();
            Form15 form15 = new Form15(plantId);
            form15.Show();

            // 현재 폼을 닫음
            this.Close();
        }
    }
}
