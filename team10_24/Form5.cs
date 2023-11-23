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
        private string connectionString = "server=webp.flykorea.kr; user=hpjw; database=hpjwDB; port=13306; password=qwer!@!@1234;";

        public Form5()
        {
            InitializeComponent();
        }

        private void history_Click(object sender, EventArgs e)
        {
            int loggedInUserId = UserSession.Instance.UserId; // 세션에서 로그인한 사용자의 UID 가져오기

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                SELECT PlantTable.plant_name 
                FROM PlantTable 
                INNER JOIN SearchHistoryTable ON PlantTable.plant_id = SearchHistoryTable.plant_id 
                WHERE SearchHistoryTable.uid = @UserId";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", loggedInUserId);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // 여기에서 dataTable을 사용하여 사용자 인터페이스에 데이터를 표시합니다.
                    // 예: dataGridView.DataSource = dataTable;
                }
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            Form16 form16 = new Form16();
            form16.Show();
            this.Close();
        }
    }
}
