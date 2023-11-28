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

                    // 유저의 uid를 이용해서 북마크된 식물 목록을 가져오는 쿼리
                    string query = @"SELECT PlantTable.plant_name FROM PlantTable INNER JOIN BookMarkTable ON BookMarkTable.plant_id = BookMarkTable.plant_id WHERE BookMarkTable.uid = @UserId";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
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
                catch (Exception ex)
                {
                    MessageBox.Show("데이터베이스 연결 실패" + ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                int plantId = Convert.ToInt32(dataGridView1.Rows[index].Cells["plantId"].Value);
                string plantName = dataGridView1.Rows[index].Cells["plantName"].Value.ToString();
                string plantColor = dataGridView1.Rows[index].Cells["plantColor"].Value.ToString();
                string bloomSeason = dataGridView1.Rows[index].Cells["bloomSeason"].Value.ToString();

                // Form10으로 선택한 식물 정보를 전달하는 코드
                Form10 form10 = new Form10(plantId, plantName, plantColor, bloomSeason);
                form10.Show();
                this.Hide();
            }
        }
    }
}

