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
            string id = Id.Text; // Replace with your actual ID TextBox control name
            string password = PW.Text; // Replace with your actual Password TextBox control name

            // Check if either the ID or password field is empty
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Please enter your ID.");
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter your password.");
                return;
            }

            // Validate the ID and password
            /*if (!dbManager.ValidateCredentials(id, password))
            {
                MessageBox.Show("Invalid ID or password.");
                return;
            }*/

            // If both ID and password are correct, transition to Form 16 (Green Book Main Form)
            Form16 form16 = new Form16(); // Assuming Form16 is the class name for Green Book main form
            form16.Show();
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

        private void Id_TextChanged(object sender, EventArgs e)
        {

        }

        private void PW_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
