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
        public Form8()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
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

    }
}
