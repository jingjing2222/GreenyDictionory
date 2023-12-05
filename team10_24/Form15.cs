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
    public partial class Form15 : Form
    {
        public int plantId;
        public Form15(int plantId)
        {
            this.plantId = plantId;
            InitializeComponent();
            InitializeListView();
        }

        private void InitializeListView()
        {
            listView1.Items.Clear(); // 기존 아이템을 클리어
            listView1.View = View.Details;

            if (listView1.Columns.Count == 0)
            {
                listView1.Columns.Add("User Name", 150);
                listView1.Columns.Add("Review", 250);
            }

            DatabaseManager dbManager = new DatabaseManager();
            var reviews = dbManager.GetReviews(plantId); // 현재 plantId에 해당하는 리뷰를 가져옵니다

            foreach (var review in reviews)
            {
                ListViewItem item = new ListViewItem(review.UserName);
                item.SubItems.Add(review.ReviewContent);
                listView1.Items.Add(item);
            }
        }


        private void review_add_Click(object sender, EventArgs e)
        {
            string reviewText = textBox1.Text;

            if (!string.IsNullOrEmpty(reviewText))
            {
                DatabaseManager dbManager = new DatabaseManager();
                int loggedInUserId = UserSession.Instance.UserId; // Assuming you have a UserSession class

                if (dbManager.AddReview(loggedInUserId, this.plantId, reviewText)) // plantId 추가
                {
                    textBox1.Text = string.Empty;
                    MessageBox.Show("리뷰가 성공적으로 추가되었습니다.");
                    InitializeListView(); // 리뷰 추가 후 ListView를 새로고침
                }
                else
                {
                    MessageBox.Show("리뷰 추가에 실패했습니다.");
                }
            }
            else
            {
                MessageBox.Show("리뷰를 입력하세요.");
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
