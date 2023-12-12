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

        // Form6의 생성자
        public Form6()
        {
            InitializeComponent();
            dbManager = new DatabaseManager();
            LoadDiaryEntries(); // 일기 항목 로드 메서드 호출
        }

        // 일기 항목을 로드하는 메서드
        private void LoadDiaryEntries()
        {
            int loggedInUserId = UserSession.Instance.UserId;

            // 일기장 목록에 컬럼이 정의되어 있지 않은 경우 정의
            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.Add("DiaryId", "Diary ID");
                dataGridView1.Columns.Add("DiaryDate", "날짜");

                dataGridView1.Columns["DiaryId"].Visible = false; // Diary ID 컬럼 숨김
                dataGridView1.Columns["DiaryDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // 날짜 컬럼으로 그리드 채움
            }

            List<DatabaseManager.DiaryEntry> diaryEntries = dbManager.GetDiaryEntriesForUser(loggedInUserId);
            foreach (var entry in diaryEntries)
            {
                dataGridView1.Rows.Add(entry.DiaryId, entry.DiaryDate);
            }
        }

        // 새로 작성 버튼 클릭 이벤트 핸들러
        private void new_write_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9(); // 새 일기 작성 폼을 표시
            form9.Show();
        }

        // 뒤로 가기 버튼 클릭 이벤트 핸들러
        private void back_Click(object sender, EventArgs e)
        {
            this.Close(); // 현재 폼을 닫음
        }

        // 일기장 목록 셀 더블 클릭 이벤트 핸들러
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                int diaryId = Convert.ToInt32(dataGridView1.Rows[index].Cells["DiaryId"].Value); // 숨겨진 컬럼에서 diary_id 추출
                int loggedInUserId = UserSession.Instance.UserId;

                Form7 form7 = new Form7(loggedInUserId, diaryId); // 해당 일기의 세부 정보를 표시하는 폼 표시
                form7.Show();
            }
        }
    }
}
