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
    public class UserSession
    {
        public static UserSession Instance { get; } = new UserSession();
        public int UserId { get; set; }
        private UserSession() { }
    }
    public partial class Form14 : Form
    {
        private string connectionString = "server=webp.flykorea.kr;user=hpjw;database=hpjwDB;port=13306;password=qwer!@!@1234;";
        private int loggedInUserID;

        public Form14()
        {
            InitializeComponent();
            loggedInUserID = userID;
            LoadBookmarkedPlants();
        }

        private void back_Click(object sender, EventArgs e)
        {
            Form16 form16 = new Form16(); // Create an instance of Form16
            form16.Show(); // Show Form16
            this.Close();
        }

        private void LoadBookmarkedPlants()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // 유저의 uid를 이용해서 북마크된 식물 목록을 가져오는 쿼리
                    string query = @"SELECT PlantTable.plant_name FROM PlantTable INNER JOIN BookMarkTable ON BookMarkTable.plant_id = Plants.plant_id WHERE BookMarkTable.uid = @UserId";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserID", loggedInUserID);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string plantName = reader["plant_name"].ToString();

                            // DataGridView에 식물 이름 추가
                            dataGridView1.Rows.Add(plantName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                string selectedPlantName = selectedRow.Cells["ColumnName"].Value.ToString(); // ColumnName에 식물 이름 열 이름을 넣어주세요

                // 폼10으로 이동하는 코드
                Form10 form10 = new Form10(); // 선택된 식물 이름을 폼10에 전달
                form10.Show();
            }
        }
    }
}

