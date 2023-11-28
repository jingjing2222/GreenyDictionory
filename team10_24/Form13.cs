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

        public Form13(int postId)
        {
            InitializeComponent();
            this.postId = postId;
            LoadPost();
        }

        private void LoadPost()
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
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

                            // 여기에서 title과 content를 UI 컨트롤에 설정합니다.
                            // 예: titleLabel.Text = title; contentTextBox.Text = content;

                            // 현재 로그인한 사용자의 UID와 글의 UID를 비교하여 버튼 활성화 결정
                            textBox1.Text = content;  // textBox1은 내용을 표시하는 텍스트 박스
                            Modify.Enabled = Delete.Enabled = (postUid == UserSession.Instance.UserId);
                        }
                    }
                }
            }
        }

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
                    var query = "DELETE FROM CommunityTable WHERE post_id = @postId";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@postId", postId);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("글이 삭제되었습니다.");
                            this.Close(); // 글 삭제 후 폼을 닫음
                        }
                        else
                        {
                            MessageBox.Show("글 삭제에 실패했습니다.");
                        }
                    }
                }
            }
        }

        private void Modify_Click(object sender, EventArgs e)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var query = "UPDATE CommunityTable SET content = @content WHERE post_id = @postId";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@content",textBox1.Text); // 현재 UI에서의 내용
                    cmd.Parameters.AddWithValue("@postId", postId);

                    cmd.ExecuteNonQuery(); // 예외 처리 없이 실행
                }
            }
            MessageBox.Show("글이 수정되었습니다.");
        }

        private void back_Click(object sender, EventArgs e)
        {
            Form11 form11 = new Form11(); // Create an instance of Form11
            form11.Show(); // Show Form11
            this.Close();
        }
    }
}
