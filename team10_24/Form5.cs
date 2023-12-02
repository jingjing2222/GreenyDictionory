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
    public partial class Form5 : Form
    {
        // 데이터베이스 연결을 위한 연결 문자열
        private string connectionString = "server=webp.flykorea.kr; user=hpjw; database=hpjwDB; port=13306; password=qwer!@!@1234;";

        // Form5 생성자
        public Form5()
        {
            // 폼 컴포넌트 초기화
            InitializeComponent();

            // 데이터 그리드 뷰 사용자 정의 설정
            CustomizeDataGridView();
        }

        // 데이터 그리드 뷰 사용자 정의 설정 메서드
        private void CustomizeDataGridView()
        {
            // 그리드 뷰 칼럼 자동 크기 조정
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // 그리드 뷰 폰트 설정
            dataGridView1.Font = new Font(dataGridView1.Font.FontFamily, 10);
        }

        // history_Click 이벤트 핸들러 - 사용자의 검색 기록을 표시하는 버튼 클릭 시 호출됨
        private void history_Click(object sender, EventArgs e)
        {
            try
            {
                // UserSession.Instance나 UserSession.Instance.UserId가 null인지 확인
                if (UserSession.Instance == null || UserSession.Instance.UserId == 0)
                {
                    MessageBox.Show("사용자 세션이 초기화되지 않았습니다.");
                    return;
                }

                // 로그인한 사용자의 uid 가져오기
                int loggedInUserId = UserSession.Instance.UserId;

                // 데이터베이스 연결 문자열이 null이나 비어 있는지 확인
                if (string.IsNullOrEmpty(connectionString))
                {
                    MessageBox.Show("데이터베이스 연결 문자열이 설정되지 않았습니다.");
                    return;
                }

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // 검색 기록을 가져오는 SQL 쿼리
                    string query = @"
SELECT PlantTable.plant_id, PlantTable.plant_name, PlantTable.plant_color, PlantTable.bloom_season 
FROM PlantTable 
INNER JOIN SearchHistoryTable ON PlantTable.plant_id = SearchHistoryTable.plant_id 
WHERE SearchHistoryTable.uid = @UserId
ORDER BY SearchHistoryTable.search_date DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // 로그인한 사용자의 UID를 쿼리 매개변수로 설정
                        cmd.Parameters.AddWithValue("@UserId", loggedInUserId);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // DataTable을 dataGridView의 DataSource로 설정
                        dataGridView1.DataSource = dataTable;

                        // 커스텀 헤더 설정
                        dataGridView1.Columns["plant_name"].HeaderText = "이름";
                        dataGridView1.Columns["plant_color"].HeaderText = "꽃 색";
                        dataGridView1.Columns["bloom_season"].HeaderText = "개화기";

                        // plant_id 칼럼 숨김
                        dataGridView1.Columns["plant_id"].Visible = false;
                    }
                }
            }
            catch (MySqlException sqlEx)
            {
                // 데이터베이스 관련 예외 처리
                MessageBox.Show("데이터베이스 오류: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                // 일반 예외 처리
                MessageBox.Show("오류 발생: " + ex.Message);
            }
        }

        // back_Click 이벤트 핸들러 - 뒤로 가기 버튼 클릭 시 호출됨
        private void back_Click(object sender, EventArgs e)
        {
            // 현재 폼을 닫음
            this.Close();
        }

        // dataGridView1_CellDoubleClick 이벤트 핸들러 - 셀을 더블 클릭 시 호출됨
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            // 인덱스가 유효하고 해당 셀의 plant_id가 null이 아닌 경우 처리
            if (index >= 0 && dataGridView1.Rows[index].Cells["plant_id"] != null)
            {
                // DataTable과 일치하는 칼럼 이름을 사용하여 데이터 추출
                int plantId = Convert.ToInt32(dataGridView1.Rows[index].Cells["plant_id"].Value);
                string plantName = dataGridView1.Rows[index].Cells["plant_name"].Value.ToString();
                string plantColor = dataGridView1.Rows[index].Cells["plant_color"].Value.ToString();
                string bloomSeason = dataGridView1.Rows[index].Cells["bloom_season"].Value.ToString();

                // 새 폼(Form10)을 생성하고 표시
                Form10 form10 = new Form10(plantId, plantName, plantColor, bloomSeason);
                form10.Show();

                // 현재 폼을 숨김
                this.Hide();
            }
        }
    }
}
