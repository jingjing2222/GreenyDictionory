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

        private void pw_check_bt_Click(object sender, EventArgs e) //비밀번호 확인 버튼
        {
            if (pw.Text.Equals(pw_check.Text))
            {
                MessageBox.Show("비밀번호 확인이 완료되었습니다.");
                pw.Enabled = false;
                pw_check.Enabled = false;
            }
            else
            {
                MessageBox.Show("비밀번호가 일치하지 않습니다.");
                //return false;
            }
        }

        private void Id_check_bt_Click(object sender, EventArgs e) //아이디 확인 버튼
        {
            if (dbManager.Id_check(Id.Text))
            {
                MessageBox.Show("사용 가능한 아이디입니다.");
                Id.Enabled = false;
            }
            else
            {
                MessageBox.Show("이미 있는 아이디입니다.");
            }
        }

        private void submit_Click(object sender, EventArgs e) //제출 버튼
        {
            if (Id.Enabled)
            {
                MessageBox.Show("아이디 확인을 완료하세요.");
                return;
            }
            else if (pw.Enabled)
            {
                MessageBox.Show("비밀번호 확인을 완료하세요.");
                return;
            }
            else if (string.IsNullOrEmpty(name_tx.Text))
            {
                MessageBox.Show("이름을 입력하세요.");
                return;
            }
            else if (!dbManager.IsValidEmail(email_tx.Text))
            {
                MessageBox.Show("올바른 이메일 형식을 입력하세요.");
                return;

            }
            bool result = dbManager.Register(Id.Text, pw.Text, email_tx.Text, name_tx.Text);
            if (result)
            {
                MessageBox.Show("회원가입이 완료되었습니다.");

                // Form3을 닫는다.
                this.Close();
            }
            else
            {
                MessageBox.Show("데이터 추가 중 오류가 발생했습니다.");
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
