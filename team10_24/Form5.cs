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

        // history_Click 이벤트 핸들러 - 사용자의 검색 기록을 표시하는 버튼 클릭 시 호출됩니다.
        private void history_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if UserSession.Instance or UserSession.Instance.UserId is null
                if (UserSession.Instance == null || UserSession.Instance.UserId == 0)
                {
                    MessageBox.Show("User session is not initialized.");
                    return;
                }

                int loggedInUserId = UserSession.Instance.UserId; // Get the logged-in user's UID

                // Check if connectionString is null or empty
                if (string.IsNullOrEmpty(connectionString))
                {
                    MessageBox.Show("Database connection string is not set.");
                    return;
                }

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
    SELECT PlantTable.plant_id, PlantTable.plant_name, PlantTable.plant_color, PlantTable.bloom_season 
    FROM PlantTable 
    INNER JOIN SearchHistoryTable ON PlantTable.plant_id = SearchHistoryTable.plant_id 
    WHERE SearchHistoryTable.uid = @UserId
    ORDER BY SearchHistoryTable.search_date DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", loggedInUserId);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dataGridView1.DataSource = dataTable;

                        // Set custom headers after setting the DataSource
                        dataGridView1.Columns["plant_name"].HeaderText = "이름";
                        dataGridView1.Columns["plant_color"].HeaderText = "꽃 색";
                        dataGridView1.Columns["bloom_season"].HeaderText = "개화기";

                        // Hide the plant_id column
                        dataGridView1.Columns["plant_id"].Visible = false;
                    }
                }
            }
            catch (MySqlException sqlEx)
            {
                // Handle database related exceptions
                MessageBox.Show("Database error: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                // Handle general exceptions
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }





        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0 && dataGridView1.Rows[index].Cells["plant_id"] != null)
            {
                // Correct column names as per your DataTable
                int plantId = Convert.ToInt32(dataGridView1.Rows[index].Cells["plant_id"].Value);
                string plantName = dataGridView1.Rows[index].Cells["plant_name"].Value.ToString(); // Ensure this matches your DataTable
                string plantColor = dataGridView1.Rows[index].Cells["plant_color"].Value.ToString(); // Ensure this matches your DataTable
                string bloomSeason = dataGridView1.Rows[index].Cells["bloom_season"].Value.ToString(); // Ensure this matches your DataTable

                Form10 form10 = new Form10(plantId, plantName, plantColor, bloomSeason);
                form10.Show();
                this.Hide();
            }
        }


    }
}
