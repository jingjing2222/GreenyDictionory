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
    public partial class Form12 : Form
    {
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
    }
}
