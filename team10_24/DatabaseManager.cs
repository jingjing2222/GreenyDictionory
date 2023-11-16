using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace team10_24
{
    class DatabaseManager
    {
        private MySqlConnection connection;
        private string connectionString = "server=webp.flykorea.kr;user=hpjw;database=hpjwDB;port=13306;password=qwer!@!@1234;";
        
        public DatabaseManager()
        {
            connection = new MySqlConnection(this.connectionString);
        }
        public class UserData
        {
            public string Id { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }
            public string Username { get; set; }
        }

        public void Connect()
        {
            try
            {
                connection.Open();
                Console.WriteLine("데이터베이스 연결");
            }
            catch (Exception ex)
            {
                Console.WriteLine("연결 오류: " + ex.Message);
            }
        }
        public void Disconnect()
        {
            try
            {
                connection.Close();
                Console.WriteLine("데이터베이스 연결 종료");
            }
            catch (Exception ex)
            {
                Console.WriteLine("연결 종료 오류: " + ex.Message);
  
            }
        }
        public bool Id_check(string inputId) //아이디 중복 확인 버튼에 사용되는 메서드
        {
            try
            {
                string query = "SELECT id FROM UserTable WHERE id = @inputId";  

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@inputId", inputId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // 일치하는 ID를 찾았으므로 false 반환
                            return false;
                        }
                        else
                        {
                            // 일치하는 ID를 찾지 못했으므로 true 반환
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("데이터 조회 중 오류 발생: " + ex.Message);
                // 오류 발생 시 기본적으로 true 반환
                return true;
            }
        }
        public bool Register(string id, string pw, string email, string username) //회원가입 버튼 클릭 시 사용되는 메서드
        {
            try
            {
                string sql = "INSERT INTO UserTable (id, password, email, username) VALUES (@id, @password, @email, @username)";
                MySqlCommand cmd = new MySqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@password", pw);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.ExecuteNonQuery();

                return true; // 성공적으로 추가되었음을 나타내는 값
            }
            catch (Exception ex)
            {
                Console.WriteLine("삽입 오류: " + ex.Message);
                return false; // 추가 실패를 나타내는 값
            }
        }
        public bool IsValidEmail(string email) //이메일 형식 확인 메서드
        {
            // 간단한 이메일 형식의 정규 표현식
            string pattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }


        public UserData GetUserData(string userId) //로그인 할 때 사용
        {
            try
            {
                string query = "SELECT id, password, email, username FROM UserTable WHERE id = @userId";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // 데이터베이스에서 읽어온 값을 사용자 정보 객체에 매핑
                            UserData userData = new UserData
                            {
                                Id = reader.GetString("id"),
                                Password = reader.GetString("password"),
                                Email = reader.GetString("email"),
                                Username = reader.GetString("username")
                            };

                            return userData;
                        }
                    }
                }
                // 사용자 정보가 없을 경우 null 반환
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("데이터 조회 중 오류 발생: " + ex.Message);
                return null;
            }
        }
    }
}
