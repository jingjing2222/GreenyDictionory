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
    public partial class Form12 : Form
    {
        // 데이터베이스 연결 문자열
        private string connectionString = "server=webp.flykorea.kr; user=hpjw; database=hpjwDB; port=13306; password=qwer!@!@1234;";

        // Form12의 생성자
        public Form12()
        {
            InitializeComponent();
        }

        // 뒤로 가기 버튼 클릭 이벤트 핸들러
        private void back_Click(object sender, EventArgs e)
        {
            Form11 form11 = new Form11();
            form11.Show();
            this.Close(); // 현재 폼을 닫고 Form11을 표시
        }

        // 글 추가 버튼 클릭 이벤트 핸들러
        private void button1_Click(object sender, EventArgs e)
        {
            string title = titleTextBox.Text; // 제목 입력 필드
            string content = contentTextBox.Text; // 내용 입력 필드

            // 제목과 내용이 비어 있는지 확인
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(content))
            {
                MessageBox.Show("제목과 내용을 모두 입력해주세요.");
                return;
            }

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                // 커뮤니티 테이블에 글 추가하는 SQL 쿼리
                var query = "INSERT INTO CommunityTable (uid, title, content, post_date) VALUES (@uid, @title, @content, NOW())";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@uid", UserSession.Instance.UserId); // 현재 로그인한 사용자의 UID
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@content", content);

                    // SQL 쿼리 실행 결과 확인
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("새 글이 추가되었습니다.");
                        this.Close(); // 글 추가 후 폼을 닫음
                        Form11 form11 = new Form11();
                        form11.Show();
                    }
                    else
                    {
                        MessageBox.Show("글 추가에 실패했습니다.");
                    }
                }
            }
        }
    }
}
