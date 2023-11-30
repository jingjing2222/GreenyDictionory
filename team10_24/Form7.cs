using System;
using System.Windows.Forms;
using team10_24;

namespace team10_24
{
    public partial class Form7 : Form
    {
        private DatabaseManager dbManager;
        private int userId;
        private int diaryId;

        public Form7(int userId, int diaryId)
        {
            InitializeComponent();
            dbManager = new DatabaseManager(); // Initialize DatabaseManager
            this.userId = userId;
            this.diaryId = diaryId;
            LoadDiaryEntry();
        }

        private void LoadDiaryEntry()
        {
            DatabaseManager.DiaryEntry entry = dbManager.GetDiaryEntry(this.userId, this.diaryId);
            if (entry != null)
            {
                // Assuming you have a TextBox named diaryTextBox for displaying diary entry
                textBox1.Text = entry.DiaryText;
            }
        }

        private void Modify_Click(object sender, EventArgs e)
        {
            string updatedDiaryEntry = textBox1.Text; // Assuming textBox1 contains the diary entry

            if (dbManager.UpdateDiaryEntry(diaryId, updatedDiaryEntry))
            {
                MessageBox.Show("수정 성공");
            }
            else
            {
                MessageBox.Show("수정 실패");
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("삭제하시겠습니까?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                if (dbManager.DeleteDiaryEntry(diaryId))
                {
                    MessageBox.Show("삭제 성공");
                    this.Close(); // Optionally close the form after deletion
                }
                else
                {
                    MessageBox.Show("삭제 실패");
                }
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}