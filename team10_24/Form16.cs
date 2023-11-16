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
    public partial class Form16 : Form
    {
        public Form16()
        {
            InitializeComponent();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(); // Assuming Form16 is the class name for Green Book main form
            form4.Show();
        }

        private void history_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5(); // Assuming Form16 is the class name for Green Book main form
            form5.Show();
        }

        private void diary_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6(); // Assuming Form16 is the class name for Green Book main form
            form6.Show();
        }

        private void community_Click(object sender, EventArgs e)
        {
            Form11 form11 = new Form11(); // Assuming Form16 is the class name for Green Book main form
            form11.Show();
        }

        private void bookmark_Click(object sender, EventArgs e)
        {
            Form14 form14 = new Form14(); // Assuming Form16 is the class name for Green Book main form
            form14.Show();
        }
    }
}
