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
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }

        private void Delete_Click(object sender, EventArgs e)
        {

        }

        private void Modify_Click(object sender, EventArgs e)
        {

        }

        private void back_Click(object sender, EventArgs e)
        {
            Form11 form11 = new Form11(); // Create an instance of Form11
            form11.Show(); // Show Form11
            this.Close();
        }
    }
}
