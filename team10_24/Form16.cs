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
            private DatabaseManager dbManager;
            // Form16의 생성자
            public Form16()
            {
                InitializeComponent();
            }

            // 검색 버튼 클릭 이벤트 핸들러
            private void Search_Click(object sender, EventArgs e)
            {
                Form4 form4 = new Form4(); // 검색 폼을 표시
                form4.ShowDialog();
            }

            // 기록 버튼 클릭 이벤트 핸들러
            private void history_Click(object sender, EventArgs e)
            {
                Form5 form5 = new Form5(); // 기록 조회 폼을 표시
                form5.ShowDialog();
            }

            // 일기 버튼 클릭 이벤트 핸들러
            private void diary_Click(object sender, EventArgs e)
            {
                Form6 form6 = new Form6(); // 일기 폼을 표시
                form6.ShowDialog();
            }

            // 커뮤니티 버튼 클릭 이벤트 핸들러
            private void community_Click(object sender, EventArgs e)
            {
                Form11 form11 = new Form11(); // 커뮤니티 폼을 표시
                form11.ShowDialog();
            }

            // 북마크 버튼 클릭 이벤트 핸들러
            private void bookmark_Click(object sender, EventArgs e)
            {
                Form14 form14 = new Form14(); // 북마크 폼을 표시
                form14.ShowDialog();
            }

            // 로그아웃 버튼 클릭 이벤트 핸들러
            private void logout_Click(object sender, EventArgs e)
            {
                dbManager = new DatabaseManager();
                this.Hide();
                Form1 form1 = new Form1(); // 로그인 폼으로 돌아감
                form1.ShowDialog();
                dbManager.Disconnect();

            }

            // Form16 닫힐 때 이벤트 핸들러
            private void Form16_FormClosing(object sender, FormClosingEventArgs e)
            {
                Application.Exit(); // 모든 폼을 닫고 애플리케이션 종료
            }
        }
    }
