using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace team10_24
{
    public partial class Form8 : Form
    {
        // DatabaseManager 클래스의 인스턴스
        private DatabaseManager dbManager;

        // Form8의 생성자
        public Form8()
        {
            InitializeComponent();
            InitializeDataGridView();
            CustomizeDataGridView();
        }

        // 식물 목록 초기화 메서드
        private void InitializeDataGridView()
        {
            dbManager = new DatabaseManager();
            // 식물 목록 컬럼 설정
            dataGridView1.Columns.Add("plantId", "식물 ID");
            dataGridView1.Columns.Add("plantName", "이름");
            dataGridView1.Columns.Add("plantColor", "꽃 색");
            dataGridView1.Columns.Add("bloomSeason", "개화기");

            // 식물 ID 컬럼 숨김
            dataGridView1.Columns["plantId"].Visible = false;
        }

        // DataGridView에 식물 데이터를 설정하는 메서드
        public void SetPlantData(DatabaseManager.Plantdata plantData)
        {
            if (plantData != null)
            {
                // 식물 목록에 식물 정보 행 추가
                dataGridView1.Rows.Add(plantData.plant_id, plantData.plant_name, plantData.plant_color, plantData.bloom_season);
            }
        }

        // 식물 목록 설정 메서드
        private void CustomizeDataGridView()
        {
            // 식물 목록 칼럼 크기 및 폰트 조정
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Font = new Font(dataGridView1.Font.FontFamily, 10);
        }

        // 수정 버튼 클릭 이벤트 핸들러
        private void Modify_Click(object sender, EventArgs e)
        {
            // 수정 버튼 클릭 시 로직
        }

        // 삭제 버튼 클릭 이벤트 핸들러
        private void Delete_Click(object sender, EventArgs e)
        {
            // 삭제 버튼 클릭 시 로직
        }

        // 리뷰 버튼 클릭 이벤트 핸들러
        private void review_Click(object sender, EventArgs e)
        {
            // 리뷰 버튼 클릭 시 로직
        }

        // 북마크 버튼 클릭 이벤트 핸들러
        private void bookmark_Click(object sender, EventArgs e)
        {
            // 북마크 버튼 클릭 시 로직
        }

        // 뒤로 가기 버튼 클릭 이벤트 핸들러
        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
            Form4 form4 = new Form4();
            form4.Show();
        }

        // 검색 기준을 설정하는 메서드
        public void SetSearchCriteria(string plantName, string colorValue, string seasonValue)
        {
            // 식물 검색 결과 가져오기
            List<DatabaseManager.Plantdata> searchedPlants = dbManager.SearchPlants(plantName, colorValue, seasonValue);

            dataGridView1.Rows.Clear(); // 기존 데이터 클리어
            if (searchedPlants.Count > 0)
            {
                foreach (var plant in searchedPlants)
                {
                    // 식물 목록에 검색된 식물 정보 행 추가
                    dataGridView1.Rows.Add(plant.plant_id, plant.plant_name, plant.plant_color, plant.bloom_season);
                }
            }
            else
            {
                MessageBox.Show("검색된 식물이 없습니다.");
            }
        }

        // 식물 목록 셀 더블 클릭 이벤트 핸들러
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // 선택된 행의 인덱스 얻기
            int index = e.RowIndex;
            if (index >= 0)
            {
                // 로그인한 사용자의 uid 가져오기
                int loggedInUserId = UserSession.Instance.UserId;
                // 식물 목록에서 식물 ID 가져오기
                int plantId = Convert.ToInt32(dataGridView1.Rows[index].Cells["plantId"].Value);
                string plantName = dataGridView1.Rows[index].Cells["plantName"].Value.ToString();
                string plantColor = dataGridView1.Rows[index].Cells["plantColor"].Value.ToString();
                string bloomSeason = dataGridView1.Rows[index].Cells["bloomSeason"].Value.ToString();

                // 검색 기록 추가
                dbManager.AddSearchHistory(loggedInUserId, plantId, DateTime.Now);

                // Form10에 식물 ID 및 기타 정보 전달
                form10 form10 = new form10(plantId, plantName, plantColor, bloomSeason);
                form10.Show();
                this.Hide();
            }
        }

        // 식물 목록 셀 컨텐츠 클릭 이벤트 핸들러
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 셀 컨텐츠 클릭 시 로직
        }
    }
}
