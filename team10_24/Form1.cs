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
    // 애플리케이션의 메인 폼 클래스
    public partial class Form1 : Form
    {
        // 데이터베이스 작업을 관리하는 클래스
        public class DatabaseManager
        {
            // 제공된 사용자 이름을 기반으로 데이터베이스에서 사용자 ID를 검색하는 메소드
            public int? GetUserId(string id)
            {
                // 데이터베이스 연결 문자열
                string connectionString = "server=webp.flykorea.kr; user=hpjw; database=hpjwDB; port=13306; password=qwer!@!@1234;";

                // 데이터베이스 연결을 적절히 해제하기 위한 using 문
                using (var connection = new MySqlConnection(connectionString))
                {
                    // 데이터베이스 연결을 여는 부분
                    connection.Open();

                    // 사용자 ID를 검색하는 SQL 쿼리
                    var query = "SELECT uid FROM UserTable WHERE id = @id";

                    // SQL 쿼리를 실행하기 위한 명령을 생성하는 부분
                    using (var command = new MySqlCommand(query, connection))
                    {
                        // 제공된 사용자 이름을 쿼리에 매개변수로 추가하는 부분
                        command.Parameters.AddWithValue("@id", id);

                        // 쿼리를 실행하고 결과를 저장하는 부분
                        var result = command.ExecuteScalar();

                        // 결과가 반환되었는지 확인하고 정수로 변환하는 부분
                        if (result != null)
                        {
                            return Convert.ToInt32(result);
                        }
                    }
                }

                // 사용자 ID를 찾지 못한 경우 null을 반환
                return null;
            }
        }

        // DatabaseManager 클래스의 인스턴스
        private DatabaseManager dbManager;

        // Form1의 생성자
        public Form1()
        {
            // 폼 컴포넌트 초기화 부분
            InitializeComponent();

            // DatabaseManager의 새 인스턴스를 생성하는 부분
            dbManager = new DatabaseManager();

            // 비밀번호 필드에 대한 비밀번호 문자를 설정하는 부분
            PW.PasswordChar = '*';
        }

        // 로그인 버튼 클릭 이벤트 핸들러
        private void Login_Click(object sender, EventArgs e)
        {
            // 입력된 사용자 이름을 기반으로 사용자 ID를 검색하는 부분
            int? userId = dbManager.GetUserId(Id.Text);

            // 유효한 사용자 ID가 반환되었는지 확인하는 부분
            if (userId.HasValue)
            {
                // UserSession 싱글톤 인스턴스에 사용자 ID를 저장하는 부분
                UserSession.Instance.UserId = userId.Value;

                // 현재 폼을 숨김
                this.Hide();

                // 다음 폼(Form16)을 생성하고 표시하는 부분
                Form16 form16 = new Form16();
                form16.ShowDialog();
            }
            else
            {
                // 사용자 이름이 올바르지 않은 경우 메시지 박스를 표시하는 부분
                MessageBox.Show("아이디가 올바르지 않습니다.");
            }
        }

        // 회원가입 버튼 클릭 이벤트 핸들러
        private void Signup_Click(object sender, EventArgs e)
        {
            // 회원가입 폼(Form3)을 생성하고 표시하는 부분
            Form3 form3 = new Form3();
            form3.Show();
        }
    }

    // 사용자 세션 정보를 유지하는 싱글톤 클래스
    public class UserSession
    {
        // UserSession 클래스의 정적 인스턴스
        public static UserSession Instance { get; } = new UserSession();

        // 사용자 ID를 저장하는 속성
        public int UserId { get; set; }

        // 클래스 외부에서 인스턴스화를 방지하기 위한 private 생성자
        private UserSession() { }
    }
}
