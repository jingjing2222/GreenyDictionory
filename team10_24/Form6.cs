using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using team10_24;

namespace team10_24
{
    public partial class Form6 : Form
    {
        private DatabaseManager dbManager;

        public Form6()
        {
            InitializeComponent();
            dbManager = new DatabaseManager();
            LoadDiaryEntries(); // Call the method to load diary entries
        }

        private void LoadDiaryEntries()
        {
            int loggedInUserId = UserSession.Instance.UserId;

            // Define columns if they are not already defined
            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.Add("DiaryId", "Diary ID");
                dataGridView1.Columns.Add("DiaryDate", "Diary Date");
                dataGridView1.Columns["DiaryId"].Visible = false; // Hide the Diary ID column
            }

            List<DatabaseManager.DiaryEntry> diaryEntries = dbManager.GetDiaryEntriesForUser(loggedInUserId);
            foreach (var entry in diaryEntries)
            {
                dataGridView1.Rows.Add(entry.DiaryId, entry.DiaryDate);
            }
        }



        private void new_write_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9(); // Assuming Form16 is the class name for Green Book main form
            form9.Show();
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                int diaryId = Convert.ToInt32(dataGridView1.Rows[index].Cells["DiaryId"].Value); // Get diary_id from hidden column
                int loggedInUserId = UserSession.Instance.UserId;

                Form7 form7 = new Form7(loggedInUserId, diaryId);
                form7.Show();
            }
        }
    }
}
