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
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, EventArgs e)
        {
            Form16 form16 = new Form16(); // Create an instance of Form16
            form16.Show(); // Show Form16
            this.Close();
        }
    }
}
