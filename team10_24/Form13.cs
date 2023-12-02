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
    public partial class Form13 : Form
    {
        private int postId; // 현재 보여지는 글의 ID
        private string connectionString = "server=webp.flykorea.kr; user=hpjw; database=hpjwDB; port=13306; password=qwer!@!@1234;";

        // Form13의 생성자
        public Form13(int postId)
        {
            InitializeComponent();
            this.postId = postId;
            LoadPost(); // 글 로드 메서드 호출
        }

        // 글 로드 메서드
        private void LoadPost()
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                // 커뮤니티 테이블에서 해당 글의 정보를 가져오는 쿼리
                var query = "SELECT uid, title, content FROM CommunityTable WHERE post_id = @postId";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@postId", postId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int postUid = reader.GetInt32("uid");
                            string title = reader.GetString("title");
                            string content = reader.GetString("content");

                            // UI 컨트롤에 제목과 내용 설정
                            textBox1.Text = content;
                            Modify.Enabled = Delete.Enabled = (postUid == UserSession.Instance.UserId);
                        }
                    }
                }
            }
        }

        // 삭제 버튼 클릭 이벤트 핸들러
        private void Delete_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("정말로 이 글을 삭제하시겠습니까?",
                                        "글 삭제 확인",
                                        MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    // 커뮤니티 테이블에서 해당 글을 삭제하는 쿼리
                    var query = "DELETE FROM CommunityTable WHERE post_id = @postId";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@postId", postId);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("글이 삭제되었습니다.");
                            this.Close(); // 글 삭제 후 Form11을 표시
                            Form11 form11 = new Form11();
                            form11.Show();
                        }
                        else
                        {
                            MessageBox.Show("글 삭제에 실패했습니다.");
                        }
                    }
                }
            }
        }

        // 수정 버튼 클릭 이벤트 핸들러
        private void Modify_Click(object sender, EventArgs e)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                // 커뮤니티 테이블에서 해당 글의 내용을 업데이트하는 쿼리
                var query = "UPDATE CommunityTable SET content = @content WHERE post_id = @postId";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@content", textBox1.Text); // 현재 UI에서의 내용
                    cmd.Parameters.AddWithValue("@postId", postId);

                    cmd.ExecuteNonQuery(); // 쿼리 실행
                }
            }
            MessageBox.Show("글이 수정되었습니다.");
            this.Close(); // 글 수정 후 Form11을 표시
            Form11 form11 = new Form11();
            form11.Show();
        }

        // 뒤로 가기 버튼 클릭 이벤트 핸들러
        private void back_Click(object sender, EventArgs e)
        {
            Form11 form11 = new Form11();
            form11.Show();
            this.Close();
        }
    }
}
