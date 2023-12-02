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
            int loggedInUserId = UserSession.Instance.UserId; // Assuming you have a way to get the logged-in user's ID
            string diaryDate = dateTimePicker1.Value.ToString("yyyy-MM-dd"); // Format the date as needed
            string diaryEntry = diary.Text; // Assuming 'diary' is the name of your TextBox

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
