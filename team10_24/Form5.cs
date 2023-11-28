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
    public partial class Form5 : Form
    {
        private string connectionString = "server=webp.flykorea.kr;user=hpjw;database=hpjwDB;port=13306;password=qwer!@!@1234;";

        public Form5()
        {
            InitializeComponent();
        }

        private void history_Click(object sender, EventArgs e)
        {
            // 로그인한 사용자의 UID를 12로 고정. 실제 애플리케이션에서는 로그인 세션 등을 통해 동적으로 얻어야 합니다.
            int loggedInUserId = UserSession.Instance.UserId; // 로그인한 사용자의 UID 사용

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

        private void back_Click(object sender, EventArgs e)
        {
            Form16 form16 = new Form16(); // Create an instance of Form16
            form16.Show(); // Show Form16
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
