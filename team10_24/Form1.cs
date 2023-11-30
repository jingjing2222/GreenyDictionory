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
            public int? GetUserId(string id)
            {
                string connectionString = "server=webp.flykorea.kr; user=hpjw; database=hpjwDB; port=13306; password=qwer!@!@1234;";
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    var query = "SELECT uid FROM UserTable WHERE id = @id";
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

        private void Login_Click(object sender, EventArgs e)
        {
            int? userId = dbManager.GetUserId(Id.Text);
            if (userId.HasValue)
            {
                UserSession.Instance.UserId = userId.Value; // 사용자의 UID 저장
                this.Hide();
                Form16 form16 = new Form16();
                form16.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("아이디가 올바르지 않습니다.");
            }
        }

        private void Signup_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }
    }
    public class UserSession
    {
        public static UserSession Instance { get; } = new UserSession();
        public int UserId { get; set; }
        private UserSession() { }
    }

}
