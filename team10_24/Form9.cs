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
    public partial class Form9 : Form
    {
        private DatabaseManager dbManager;

        public Form9()
        {
            InitializeComponent();
            dbManager = new DatabaseManager();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            int loggedInUserId = UserSession.Instance.UserId; // 로그인한 사용자의 ID를 얻을 수 있는 방법이 있다고 가정
            string diaryDate = dateTimePicker1.Value.ToString("yyyy-MM-dd"); // 필요에 따라 날짜 형식을 지정
            string diaryEntry = diary.Text; // diary가 TextBox의 이름이라고 가정

            if (dbManager.AddDiaryEntry(loggedInUserId, diaryDate, diaryEntry))
            {
                MessageBox.Show("식물 일기장 추가 성공");
            }
            else
            {
                MessageBox.Show("식물 일기장 추가 실패");
            }
        }


        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
