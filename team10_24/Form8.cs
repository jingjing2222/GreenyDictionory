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
    public partial class Form8 : Form
    {
        private DatabaseManager dbManager;
        public Form8()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            dbManager = new DatabaseManager();
            // DataGridView 컬럼 초기화
            dataGridView1.Columns.Add("plantName", "이름");
            dataGridView1.Columns.Add("plantColor", "꽃 색");
            dataGridView1.Columns.Add("bloomSeason", "개화기");
        }

        public void SetPlantData(DatabaseManager.Plantdata plantData)
        {
            if (plantData != null)
            {
                // DataGridView에 행 추가
                dataGridView1.Rows.Add(plantData.plant_name, plantData.plant_color, plantData.bloom_season);
            }
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
            Form4 form4 = new Form4(); // Create an instance of Form4
            form4.Show(); // Show Form4
            this.Close();
        }
        public void SetSearchCriteria(string plantName, string colorValue, string seasonValue)
        {
            List<DatabaseManager.Plantdata> searchedPlants = dbManager.SearchPlants(plantName, colorValue, seasonValue);

            dataGridView1.Rows.Clear(); // 기존 데이터 클리어
            if (searchedPlants.Count > 0)
            {
                foreach (var plant in searchedPlants)
                {
                    dataGridView1.Rows.Add(plant.plant_name, plant.plant_color, plant.bloom_season);
                }
            }
            else
            {
                MessageBox.Show("검색된 식물이 없습니다.");
            }
        }


    }
}
