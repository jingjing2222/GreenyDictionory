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

    public partial class Form10 : Form
    {
        private DatabaseManager dbManager;
        private static readonly Dictionary<string, string> colorMapping = DatabaseManager.colorMapping;
        private static readonly Dictionary<string, string> seasonMapping = DatabaseManager.seasonMapping;
        private int plantId;
        public Form10()
        {
            InitializeComponent();
        }

        public Form10(int plantId, string plantName, string plantColor, string bloomSeason)
        {
            InitializeComponent();
            dbManager = new DatabaseManager(); // DatabaseManager 인스턴스 초기화
            this.plantId = plantId;
            name_add.Text = plantName;
            SetRadioColor(plantColor);
            SetRadioSeason(bloomSeason);
        }

        private void Add_Click(object sender, EventArgs e)
        {
            // 추가 버튼 클릭 시 로직
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetRadioColor(string colorValue)
        {
            string englishColor = GetEnglishValueFromKorean(colorMapping, colorValue);
            CheckRadioButton(groupBoxColors, englishColor);
        }

        private void SetRadioSeason(string seasonValue)
        {
            string englishSeason = GetEnglishValueFromKorean(seasonMapping, seasonValue);
            CheckRadioButton(groupBoxSeasons, englishSeason);
        }

        private string GetEnglishValueFromKorean(Dictionary<string, string> mapping, string koreanValue)
        {
            return mapping.FirstOrDefault(x => x.Value == koreanValue).Key;
        }

        private void CheckRadioButton(GroupBox groupBox, string radioButtonName)
        {
            foreach (Control control in groupBox.Controls)
            {
                if (control is RadioButton rb && rb.Name == radioButtonName)
                {
                    rb.Checked = true;
                    break;
                }
            }
        }

        private void Modify_Click(object sender, EventArgs e)
        {
            string newName = name_add.Text;

            // RadioButton의 이름을 한국어 값으로 변환
            string newColorEnglish = GetSelectedRadioButtonValue(groupBoxColors);
            string newSeasonEnglish = GetSelectedRadioButtonValue(groupBoxSeasons);
            string newColor = colorMapping.FirstOrDefault(x => x.Key == newColorEnglish).Value;
            string newSeason = seasonMapping.FirstOrDefault(x => x.Key == newSeasonEnglish).Value;

            if (!dbManager.CheckIfPlantExists(newName, newColor, newSeason))
            {
                bool isUpdated = dbManager.UpdatePlantData(plantId, newName, newColor, newSeason);
                if (isUpdated)
                {
                    MessageBox.Show("식물 데이터가 성공적으로 수정되었습니다.");
                }
                else
                {
                    MessageBox.Show("식물 데이터 수정에 실패했습니다.");
                }
            }
            else
            {
                MessageBox.Show("동일한 이름, 색상, 계절의 식물이 이미 존재합니다.");
            }
        }


        private string GetSelectedRadioButtonValue(GroupBox groupBox)
        {
            foreach (Control control in groupBox.Controls)
            {
                if (control is RadioButton rb && rb.Checked)
                {
                    return rb.Name; // 라디오 버튼의 Name 속성을 반환
                }
            }
            return null; // 선택된 라디오 버튼이 없는 경우
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("이 식물을 삭제하시겠습니까?", "삭제 확인", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (dbManager.DeletePlantData(plantId))
                {
                    MessageBox.Show("식물 데이터가 성공적으로 삭제되었습니다.");
                    this.Close(); // Form10 창을 닫음
                    Form8 form8 = new Form8();
                    form8.Show(); // Form8 창을 다시 열음
                }
                else
                {
                    MessageBox.Show("식물 데이터 삭제에 실패했습니다.");
                }
            }
        }
    }
}
