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

namespace team10_24
{
    public partial class Form11 : Form
    {
        // 데이터베이스 연결 문자열
        private string connectionString = "server=webp.flykorea.kr; user=hpjw; database=hpjwDB; port=13306; password=qwer!@!@1234;";

        // Form11의 생성자
        public Form11()
        {
            // 컴포넌트 초기화 및 커뮤니티 게시글 로드와 커뮤니티 목록 설정
            InitializeComponent();
            LoadCommunityPosts();
            CustomizeDataGridView();
        }

        // 커뮤니티 게시글을 로드하는 메서드
        private void LoadCommunityPosts()
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                // CommunityTable과 UserTable을 조인하여 post_id, title, username을 선택하는 쿼리
                var query = @"
            SELECT c.post_id, c.title, u.username 
            FROM CommunityTable c
            JOIN UserTable u ON c.uid = u.uid";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // 커뮤니티 목록에 DataTable을 연결
                    dataGridView1.DataSource = dataTable;

                    // post_id 칼럼을 숨김
                    dataGridView1.Columns["post_id"].Visible = false;
                }
            }
        }

        // 커뮤니티 목록 설정 메서드
        private void CustomizeDataGridView()
        {
            // 커뮤니티 목록의 칼럼 크기와 폰트 설정
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Font = new Font(dataGridView1.Font.FontFamily, 10);
        }

        // 뒤로 가기 버튼 클릭 이벤트 핸들러
        private void back_Click(object sender, EventArgs e)
        {
            // 현재 폼을 닫음
            this.Close();
        }

        // 새 게시글 작성 버튼 클릭 이벤트 핸들러
        private void button1_Click(object sender, EventArgs e)
        {
            // Form12를 생성하고 표시
            Form12 form12 = new Form12();
            form12.Show();
            this.Close();
        }

        // 커뮤니티 목록의 셀 더블 클릭 이벤트 핸들러
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // 선택된 셀의 행이 유효하고 새 행이 아닌 경우
            if (e.RowIndex >= 0 && dataGridView1.Rows[e.RowIndex].IsNewRow == false)
            {
                var selectedRow = dataGridView1.Rows[e.RowIndex];
                int postId = Convert.ToInt32(selectedRow.Cells["post_id"].Value);

                // Form13을 생성하고 postId를 전달
                Form13 form13 = new Form13(postId);
                form13.Show();
                this.Close();
            }
            else
            {
                // 빈 칸 선택 시 메시지 표시
                MessageBox.Show("빈 칸 입니다.");
            }
        }
    }
}
