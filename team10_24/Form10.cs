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
        private static readonly Dictionary<string, string> colorMapping = DatabaseManager.colorMapping;
        private static readonly Dictionary<string, string> seasonMapping = DatabaseManager.seasonMapping;

        public Form10()
        {
            InitializeComponent();
        }

        public Form10(string plantName, string plantColor, string bloomSeason)
        {
            InitializeComponent();

            // 이름 설정
            name_add.Text = plantName;

            // 꽃 색 설정
            SetRadioColor(plantColor);

            // 개화기 설정
            SetRadioSeason(bloomSeason);
        }

        private void Add_Click(object sender, EventArgs e)
        {
            // 추가 버튼 클릭 시 로직
        }

        private void back_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            form8.Show();
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
    }
}
