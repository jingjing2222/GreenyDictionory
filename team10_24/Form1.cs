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
{   public partial class Form1 : Form
    {
        
        public class DatabaseManager
        {
            // 사용자 아이디를 데이터베이스에서 가져오는 메서드
            public int? GetUserId(string id) 
            {
                // 데이터베이스 연결
                string connectionString = "server=webp.flykorea.kr; user=hpjw; database=hpjwDB; port=13306; password=qwer!@!@1234;";
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    var query = "SELECT uid FROM UserTable WHERE id = @id";   // 쿼리문 생성
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        var result = command.ExecuteScalar();
                        if (result != null)
                        {
                            return Convert.ToInt32(result);
                        }
                    }
                }
                return null;
            }
        }

        private DatabaseManager dbManager;

        public Form1()
        {
            InitializeComponent();
            dbManager = new DatabaseManager();
            PW.PasswordChar = '*';
        }

        // 로그인 버튼 클릭 이벤트 핸들러
        private void Login_Click(object sender, EventArgs e)
        {
            int? userId = dbManager.GetUserId(Id.Text);
            if (userId.HasValue)  // 사용자 아이디가 존재하는 경우
            {
                UserSession.Instance.UserId = userId.Value; // 사용자의 UID 저장
                this.Hide();
                Form16 form16 = new Form16();
                form16.ShowDialog();
                this.Close();
            }
            else         //아이디가 올바르지 않은 경우
            {
                MessageBox.Show("아이디가 올바르지 않습니다.");
            }
        }

        // 회원가입 버튼 클릭 이벤트 핸들러
        private void Signup_Click(object sender, EventArgs e)
        {
            // 회원가입 폼(form3) 열기
            Form3 form3 = new Form3();
            form3.Show();
        }
    }

    // 사용자 세션
    public class UserSession
    {
        public static UserSession Instance { get; } = new UserSession();
        public int UserId { get; set; }
        private UserSession() { }
    }

}
