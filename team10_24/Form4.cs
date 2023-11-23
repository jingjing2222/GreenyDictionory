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
using team10_24;

namespace team10_24
{
    public partial class Form4 : Form
    {
        private DatabaseManager dbManager;

        public Form4()
        {
            InitializeComponent();
            dbManager = new DatabaseManager();
        }

        private void white_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void green_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void brown_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void yellow_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void orange_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pink_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void red_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void purple_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void hotpink_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void blue_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void black_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void spring_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void summer_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void fall_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void winter_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void back_Click(object sender, EventArgs e)
        {
            Form16 form16 = new Form16(); // Create an instance of Form16
            form16.Show(); // Show Form16
            this.Close();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            // name_search 텍스트 박스에서 식물 이름을 가져옵니다.
            string plantName = name_search.Text;

            // 꽃 색상을 선택한 라디오 버튼에서 가져옵니다.
            string selectedColor = GetSelectedRadioButtonValue(groupBoxColors);

            // 개화기를 선택한 라디오 버튼에서 가져옵니다.
            string selectedSeason = GetSelectedRadioButtonValue(groupBoxSeasons);
            MessageBox.Show(selectedColor + selectedSeason,"??");

            // SearchPlants 메서드를 호출하여 식물 데이터를 검색합니다.
            DatabaseManager.Plantdata searchedPlant = dbManager.SearchPlants(plantName, selectedColor, selectedSeason);

            Form8 form8 = new Form8();
            form8.SetPlantData(searchedPlant); // Form8에 식물 데이터 설정
            form8.Show();
            this.Close();
        }

        // 그룹박스 내에서 선택된 라디오 버튼의 값을 반환하는 메서드
        private string GetSelectedRadioButtonValue(GroupBox groupBox)
        {
            foreach (RadioButton rb in groupBox.Controls)
            {
                if (rb.Checked)
                {
                    return rb.Name; // 라디오 버튼의 Name 속성을 반환합니다.
                }
            }
            return null; // 선택된 라디오 버튼이 없는 경우
        }

    }
}
