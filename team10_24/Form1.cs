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
        private DatabaseManager dbManager;
        public Form1()
        {
            InitializeComponent();
            dbManager = new DatabaseManager();
            dbManager.Connect();
        }

        //로그인 클릭
        private void Login_Click(object sender, EventArgs e)
        {

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
