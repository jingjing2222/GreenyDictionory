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

        // Form7의 생성자
        public Form7(int userId, int diaryId)
        {
            InitializeComponent();
            dbManager = new DatabaseManager(); // DatabaseManager 초기화
            this.userId = userId;
            this.diaryId = diaryId;
            LoadDiaryEntry(); // 일기 항목 로드 메서드 호출
        }

        // 일기 항목을 로드하는 메서드
        private void LoadDiaryEntry()
        {
            DatabaseManager.DiaryEntry entry = dbManager.GetDiaryEntry(this.userId, this.diaryId);
            if (entry != null)
            {
                textBox1.Text = entry.DiaryText;
            }
        }

        // 수정 버튼 클릭 이벤트 핸들러
        private void Modify_Click(object sender, EventArgs e)
        {
            string updatedDiaryEntry = textBox1.Text;

            if (dbManager.UpdateDiaryEntry(diaryId, updatedDiaryEntry))
            {
                MessageBox.Show("수정 성공");
            }
            else
            {
                MessageBox.Show("수정 실패");
            }
        }

        // 삭제 버튼 클릭 이벤트 핸들러
        private void Delete_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("삭제하시겠습니까?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                if (dbManager.DeleteDiaryEntry(diaryId))
                {
                    MessageBox.Show("삭제 성공");
                    this.Close(); // 선택적으로 삭제 후 폼을 닫음
                }
                else
                {
                    MessageBox.Show("삭제 실패");
                }
            }
        }

        // 돌아 가기 버튼 클릭 이벤트 핸들러
        private void back_Click(object sender, EventArgs e)
        {
            this.Close(); // 현재 폼을 닫음
        }
    }
}
