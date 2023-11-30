﻿using System;
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
        private DatabaseManager dbManager;
        public Form8()
        {
            InitializeComponent();
            InitializeDataGridView();
            CustomizeDataGridView();
        }

        private void InitializeDataGridView()
        {
            dbManager = new DatabaseManager();
            // DataGridView 컬럼 초기화
            dataGridView1.Columns.Add("plantId", "식물 ID");
            dataGridView1.Columns.Add("plantName", "이름");
            dataGridView1.Columns.Add("plantColor", "꽃 색");
            dataGridView1.Columns.Add("bloomSeason", "개화기");

            dataGridView1.Columns["plantId"].Visible = false;
        }

        public void SetPlantData(DatabaseManager.Plantdata plantData)
        {
            if (plantData != null)
            {
                // DataGridView에 행 추가
                dataGridView1.Rows.Add(plantData.plant_id,plantData.plant_name, plantData.plant_color, plantData.bloom_season);
            }
        }
        private void CustomizeDataGridView()
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Font = new Font(dataGridView1.Font.FontFamily, 10);
            // 여기에 다른 커스터마이징 코드를 추가할 수 있습니다.
        }


        private void Modify_Click(object sender, EventArgs e)
        {

        }

        private void Delete_Click(object sender, EventArgs e)
        {

        }

        private void review_Click(object sender, EventArgs e)
        {

        }

        private void bookmark_Click(object sender, EventArgs e)
        {

        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
            Form4 form4 = new Form4();
            form4.Show();
        }
        public void SetSearchCriteria(string plantName, string colorValue, string seasonValue)
        {
            List<DatabaseManager.Plantdata> searchedPlants = dbManager.SearchPlants(plantName, colorValue, seasonValue);

            dataGridView1.Rows.Clear(); // 기존 데이터 클리어
            if (searchedPlants.Count > 0)
            {
                foreach (var plant in searchedPlants)
                {
                    dataGridView1.Rows.Add(plant.plant_id, plant.plant_name, plant.plant_color, plant.bloom_season); // 식물 ID도 함께 추가
                }
            }
            else
            {
                MessageBox.Show("검색된 식물이 없습니다.");
            }
        }
        // Form8 클래스 내부
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // 선택된 행의 인덱스 얻기
            int index = e.RowIndex;
            if (index >= 0)
            {
                int loggedInUserId = UserSession.Instance.UserId; // Get the logged-in user's ID
                // DataGridView에서 식물 ID 얻기
                int plantId = Convert.ToInt32(dataGridView1.Rows[index].Cells["plantId"].Value);
                string plantName = dataGridView1.Rows[index].Cells["plantName"].Value.ToString();
                string plantColor = dataGridView1.Rows[index].Cells["plantColor"].Value.ToString();
                string bloomSeason = dataGridView1.Rows[index].Cells["bloomSeason"].Value.ToString();

                // Add the search history record
                dbManager.AddSearchHistory(loggedInUserId, plantId, DateTime.Now);

                // Form10에 식물 ID 및 기타 정보 전달
                Form10 form10 = new Form10(plantId, plantName, plantColor, bloomSeason);
                form10.Show();
                this.Hide();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
