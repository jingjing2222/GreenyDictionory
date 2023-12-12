using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace team10_24
{
    public partial class Form14 : Form
    {
        private string connectionString = "server=webp.flykorea.kr;user=hpjw;database=hpjwDB;port=13306;password=qwer!@!@1234;";

        // Form14의 생성자
        public Form14()
        {
            InitializeComponent();
            LoadBookmarkedPlants(); // 북마크된 식물을 로드하는 메서드 호출
            CustomizeDataGridView(); // 식물 북마크 목록 설정
        }

        // 뒤로 가기 버튼 클릭 이벤트 핸들러
        private void back_Click(object sender, EventArgs e)
        {
            this.Close(); // 현재 폼을 닫음
        }

        // 북마크된 식물을 로드하는 메서드
        private void LoadBookmarkedPlants()
        {
            int loggedInUserId = UserSession.Instance.UserId; // 현재 로그인한 사용자의 ID

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // 북마크 테이블과 식물 테이블을 조인하여 해당 사용자의 북마크 정보를 가져오는 쿼리
                    string query = @"
                    SELECT PlantTable.plant_id, PlantTable.plant_name, PlantTable.plant_color, PlantTable.bloom_season 
                    FROM PlantTable 
                    INNER JOIN BookMarkTable ON PlantTable.plant_id = BookMarkTable.plant_id 
                    WHERE BookMarkTable.uid = @UserId";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@UserId", loggedInUserId);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dataGridView1.DataSource = dataTable;

                        // 식물 북마크 목록의 커스텀 헤더 설정
                        dataGridView1.Columns["plant_name"].HeaderText = "이름";
                        dataGridView1.Columns["plant_color"].HeaderText = "꽃 색";
                        dataGridView1.Columns["bloom_season"].HeaderText = "개화기";

                        // plant_id 컬럼 숨김
                        dataGridView1.Columns["plant_id"].Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("데이터베이스 연결 실패" + ex.Message);
                }
            }
        }

        // 식물 북마크 목록 설정 메서드
        private void CustomizeDataGridView()
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Font = new Font(dataGridView1.Font.FontFamily, 10);
        }

        // 식물 북마크 목록 셀 내용 클릭 이벤트 핸들러
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0 && dataGridView1.Rows[index].Cells["plant_id"] != null)
            {
                // 클릭된 행의 데이터 추출
                int plantId = Convert.ToInt32(dataGridView1.Rows[index].Cells["plant_id"].Value);
                string plantName = dataGridView1.Rows[index].Cells["plant_name"].Value.ToString();
                string plantColor = dataGridView1.Rows[index].Cells["plant_color"].Value.ToString();
                string bloomSeason = dataGridView1.Rows[index].Cells["bloom_season"].Value.ToString();

                // Form10에 식물 정보 전달
                form10 form10 = new form10(plantId, plantName, plantColor, bloomSeason);
                form10.Show();
                this.Hide();
            }
        }
    }
}
