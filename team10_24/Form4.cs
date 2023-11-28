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

        public Form4()
        {
            InitializeComponent();
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
            this.Close();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            string plantName = name_search.Text;
            string selectedColor = GetSelectedRadioButtonValue(groupBoxColors);
            string selectedSeason = GetSelectedRadioButtonValue(groupBoxSeasons);

            // 선택된 색상과 계절의 실제 값(한국어)을 가져옵니다.
            string colorValue = null;
            string seasonValue = null;

            if (!string.IsNullOrEmpty(selectedColor) && DatabaseManager.colorMapping.ContainsKey(selectedColor))
            {
                colorValue = DatabaseManager.colorMapping[selectedColor];
            }

            if (!string.IsNullOrEmpty(selectedSeason) && DatabaseManager.seasonMapping.ContainsKey(selectedSeason))
            {
                seasonValue = DatabaseManager.seasonMapping[selectedSeason];
            }

            Form8 form8 = new Form8();
            form8.SetSearchCriteria(plantName, colorValue, seasonValue);
            form8.Show();
            this.Close();
        }




        // 그룹박스 내에서 선택된 라디오 버튼의 값을 반환하는 메서드
        private string GetSelectedRadioButtonValue(GroupBox groupBox)
        {
            foreach (Control control in groupBox.Controls)
            {
                // Control이 RadioButton인 경우에만 처리
                if (control is RadioButton rb && rb.Checked)
                {
                    return rb.Name; // 선택된 RadioButton의 Name 속성 반환
                }
            }
            return null; // 선택된 RadioButton이 없는 경우
        }


        private void groupBoxColors_Enter(object sender, EventArgs e)
        {

        }

        private void Add_Click(object sender, EventArgs e)
        {
            string plantName = name_search.Text;
            string selectedColor = GetSelectedRadioButtonValue(groupBoxColors);
            string selectedSeason = GetSelectedRadioButtonValue(groupBoxSeasons);

            string colorValue = selectedColor != null ? DatabaseManager.colorMapping[selectedColor] : null;
            string seasonValue = selectedSeason != null ? DatabaseManager.seasonMapping[selectedSeason] : null;

            if (!string.IsNullOrEmpty(plantName) && colorValue != null && seasonValue != null)
            {
                DatabaseManager dbManager = new DatabaseManager();
                if (!dbManager.CheckIfPlantExists(plantName, colorValue, seasonValue))
                {
                    if (dbManager.AddPlantData(plantName, colorValue, seasonValue))
                    {
                        MessageBox.Show("식물 데이터가 성공적으로 추가되었습니다.");
                    }
                    else
                    {
                        MessageBox.Show("식물 데이터 추가에 실패했습니다.");
                    }
                }
                else
                {
                    MessageBox.Show("동일한 이름, 색상, 계절의 식물이 이미 존재합니다.");
                }
            }
            else
            {
                MessageBox.Show("모든 필드를 올바르게 채워주세요.");
            }
        }

    }
}
