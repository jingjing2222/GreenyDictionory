using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace team10_24
{
    public partial class Form3 : Form
    {
        private DatabaseManager dbManager;
        public Form3()
        {
            InitializeComponent();
            dbManager = new DatabaseManager();
            dbManager.Connect();
        }

        private void pw_check_bt_Click(object sender, EventArgs e)
        {

        }

        private void Id_check_bt_Click(object sender, EventArgs e)
        {
            if (dbManager.Id_check(Id.Text))
            {
                MessageBox.Show("사용 가능한 아이디입니다.");
            }
            else
                MessageBox.Show("이미 있는 아이디입니다.");
        }

        private void submit_Click(object sender, EventArgs e)
        {

        }
    }
}
