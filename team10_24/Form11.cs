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
    public partial class Form11 : Form
    {
        private string connectionString = "server=webp.flykorea.kr; user=hpjw; database=hpjwDB; port=13306; password=qwer!@!@1234;";

        public Form11()
        {
            InitializeComponent();
            LoadCommunityPosts();
        }

        private void LoadCommunityPosts()
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var query = "SELECT post_id, title FROM CommunityTable";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;

                    dataGridView1.Columns["post_id"].Visible = false;
                }
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            Form16 form16 = new Form16(); // Create an instance of Form16
            form16.Show(); // Show Form16
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form12 form12 = new Form12();
            form12.Show();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Rows[e.RowIndex].IsNewRow == false)
            {
                var selectedRow = dataGridView1.Rows[e.RowIndex];
                int postId = Convert.ToInt32(selectedRow.Cells["post_id"].Value);

                Form13 form13 = new Form13(postId); // Form13 생성자에 postId 전달
                form13.Show();
            }
            else
            {
                MessageBox.Show("빈 칸 입니다.");
            }
        }
    }
}
