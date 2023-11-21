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
        // 데이터베이스 연결을 위한 문자열 정의
        private string connectionString = "server=webp.flykorea.kr;user=hpjw;database=hpjwDB;port=13306;password=qwer!@!@1234;";

        public Form5()
        {
            InitializeComponent();
        }

        // history_Click 이벤트 핸들러 - 사용자의 검색 기록을 표시하는 버튼 클릭 시 호출됩니다.
        private void history_Click(object sender, EventArgs e)
        {
            // 로그인한 사용자의 UID를 12로 고정. 실제 애플리케이션에서는 로그인 세션 등을 통해 동적으로 얻어야 합니다.
            int loggedInUserId = 12;

            try
            {
                // MySQL 데이터베이스에 연결
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    // 사용자의 UID에 해당하는 식물 이름을 조회하는 SQL 쿼리
                    string query = @"
                    SELECT PlantTable.plant_name 
                    FROM PlantTable 
                    INNER JOIN SearchHistoryTable ON PlantTable.plant_id = SearchHistoryTable.plant_id 
                    WHERE SearchHistoryTable.uid = @UserId";

                    // 쿼리 실행
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // 쿼리에 사용자의 UID를 매개변수로 전달
                        cmd.Parameters.AddWithValue("@UserId", loggedInUserId);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // DataGridView에 조회된 데이터를 바인딩하여 표시
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                // 데이터베이스 연결 실패 시 사용자에게 오류 메시지 표시
                MessageBox.Show("데이터베이스 연결에 실패했습니다: " + ex.Message);
            }
        }

        // dataGridView1_CellContentClick 이벤트 핸들러 - DataGridView의 셀이 클릭될 때 호출됩니다.
        // 현재 이 메서드는 비어 있으며, 필요한 경우 셀 클릭 이벤트에 대한 추가 처리를 구현할 수 있습니다.
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 셀 클릭 이벤트 처리 (필요한 경우 여기에 구현)
        }
    }
}
