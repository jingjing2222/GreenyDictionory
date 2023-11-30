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
        
        public Form14()
        {
            InitializeComponent();
            LoadBookmarkedPlants();
            CustomizeDataGridView();
        }


        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadBookmarkedPlants()
        {
            int loggedInUserId = UserSession.Instance.UserId;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Updated query to include all necessary columns
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

                        // Set custom headers after setting the DataSource
                        dataGridView1.Columns["plant_name"].HeaderText = "이름";
                        dataGridView1.Columns["plant_color"].HeaderText = "꽃 색";
                        dataGridView1.Columns["bloom_season"].HeaderText = "개화기";

                        // Hide the plant_id column
                        dataGridView1.Columns["plant_id"].Visible = false;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("데이터베이스 연결 실패" + ex.Message);
                }
            }
        }
        private void CustomizeDataGridView()
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Font = new Font(dataGridView1.Font.FontFamily, 10);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0 && dataGridView1.Rows[index].Cells["plant_id"] != null)
            {
                // Fetch the data from the clicked row's cells
                int plantId = Convert.ToInt32(dataGridView1.Rows[index].Cells["plant_id"].Value);
                string plantName = dataGridView1.Rows[index].Cells["plant_name"].Value.ToString();
                string plantColor = dataGridView1.Rows[index].Cells["plant_color"].Value.ToString();
                string bloomSeason = dataGridView1.Rows[index].Cells["bloom_season"].Value.ToString();

                Form10 form10 = new Form10(plantId, plantName, plantColor, bloomSeason);
                form10.Show();
                this.Hide();
            }
        }

    }
}

