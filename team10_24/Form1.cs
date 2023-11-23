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
    public partial class Form1 : Form
    {
        public class DatabaseManager
        {
            public int? GetUserId(string username)
            {
                // MySQL 데이터베이스 연결 문자열
                string connectionString = "/* 여기에 MySQL 연결 문자열 입력 */";

                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    var query = "SELECT uid FROM UserTable WHERE id = @username";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);

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
        public class UserData
        {
            public int UserId { get; set; } // 사용자의 ID
                                            // 기존의 다른 프로퍼티들...
        }
        private DatabaseManager dbManager;

        public Form1()
        {
            InitializeComponent();
            dbManager = new DatabaseManager();
            dbManager.Connect();
        }
        public class UserSession
        {
            public static UserSession Instance { get; } = new UserSession();

            public int UserId { get; set; }
            private UserSession() { }
        }

        //로그인 클릭
        private void Login_Click(object sender, EventArgs e)
        {
            DatabaseManager.UserData userData = dbManager.GetUserData(Id.Text);

            if (userData != null && userData.Password == PW.Text)
            {
                MessageBox.Show("로그인 성공!");
                UserSession.Instance.UserId = userData.UserId; // 사용자의 UID 저장
                this.Hide();
                Form16 form16 = new Form16(); 
                form16.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("아이디 또는 비밀번호가 올바르지 않습니다.");
            }
        }

        //회원가입 클릭
        private void Signup_Click(object sender, EventArgs e)
        {

            Form3 form3 = new Form3(); // Create an instance of Form2
            form3.Show(); // Show Form2
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
