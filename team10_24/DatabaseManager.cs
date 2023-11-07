using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public bool Id_check(string inputId)
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
    }
}
