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
        private string connectionString = "server=webp.flykorea.kr; user=hpjw; database=hpjwDB; port=13306; password=qwer!@!@1234;";

        public Form12()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, EventArgs e)
        {
            Form11 form11 = new Form11(); // Create an instance of Form11
            form11.Show(); // Show Form11
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string title = titleTextBox.Text; // 제목 입력 필드
            string content = contentTextBox.Text; // 내용 입력 필드

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(content))
            {
                MessageBox.Show("제목과 내용을 모두 입력해주세요.");
                return;
            }

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var query = "INSERT INTO CommunityTable (uid, title, content, post_date) VALUES (@uid, @title, @content, NOW())";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@uid", UserSession.Instance.UserId); // 현재 로그인한 사용자의 UID
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@content", content);

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("새 글이 추가되었습니다.");
                        this.Close(); // 글 추가 후 폼을 닫음
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
