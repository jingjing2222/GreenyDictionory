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
            // Logic to modify the diary entry
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            // Logic to delete the diary entry
        }

        private void Okay_Click(object sender, EventArgs e)
        {
            // Logic for okay action, if needed
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}