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
        public Form15()
        {
            InitializeComponent();
            InitializeListView();
        }

        private void InitializeListView()
        {
            // 리뷰 목록 뷰 설정
            listView1.View = View.List;
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void review_add_Click(object sender, EventArgs e)
        {
            // 텍스트박스에서 리뷰 텍스트 가져오기
            string reviewText = textBox1.Text;

            if (!string.IsNullOrEmpty(reviewText))
            {
                // 리스트뷰에 리뷰 추가
                listView1.Items.Add(reviewText);

                // 추가 후 텍스트 박스 초기화
                textBox1.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("리뷰를 입력하세요.");
            }
        }
    }
}
