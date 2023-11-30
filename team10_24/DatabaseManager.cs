using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace team10_24
{
    public class DatabaseManager
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
        public class Plantdata
        {
            public int plant_id { get; set; }
            public string plant_name { get; set; }
            public string bloom_season { get; set; }
            public string plant_color { get; set; }
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
        // 색상과 계절에 대한 영어-한국어 매핑 딕셔너리
        public static readonly Dictionary<string, string> colorMapping = new Dictionary<string, string>
{
    {"white", "흰색"}, {"green", "초록색"}, {"brown", "갈색"},
    {"yellow", "노랑"}, {"orange", "주황"}, {"pink", "핑크"},
    {"red", "빨강"}, {"purple", "보라"}, {"hotpink", "핫핑크"},
    {"blue", "파랑"}, {"black", "검정"}
};

        public static readonly Dictionary<string, string> seasonMapping = new Dictionary<string, string>
{
    {"spring", "봄"}, {"summer", "여름"}, {"fall", "가을"}, {"winter", "겨울"}
};

        // 식물 데이터를 검색하는 메서드
        public List<Plantdata> SearchPlants(string plantName, string color, string season)
        {
            List<Plantdata> plants = new List<Plantdata>();

            string query = "SELECT * FROM PlantTable WHERE 1=1";
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            if (!string.IsNullOrEmpty(plantName))
            {
                query += " AND plant_name LIKE @plantName";
                parameters.Add(new MySqlParameter("@plantName", $"%{plantName}%"));
            }

            if (!string.IsNullOrEmpty(color))
            {
                query += " AND plant_color = @plantColor";
                parameters.Add(new MySqlParameter("@plantColor", color));
            }

            if (!string.IsNullOrEmpty(season))
            {
                query += " AND bloom_season = @bloomSeason";
                parameters.Add(new MySqlParameter("@bloomSeason", season));
            }

            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddRange(parameters.ToArray());

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Plantdata plantData = new Plantdata
                        {
                            plant_id = reader.GetInt32("plant_id"),
                            plant_name = reader.GetString("plant_name"),
                            bloom_season = reader.GetString("bloom_season"),
                            plant_color = reader.GetString("plant_color")
                        };
                        plants.Add(plantData);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in SearchPlants: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return plants;
        }

        public bool UpdatePlantData(int plantId, string newName, string newColor, string newSeason)
        {
            try
            {
                string query = "UPDATE PlantTable SET plant_name = @newName, plant_color = @newColor, bloom_season = @newSeason WHERE plant_id = @plantId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@plantId", plantId);
                    command.Parameters.AddWithValue("@newName", newName);
                    command.Parameters.AddWithValue("@newColor", newColor);
                    command.Parameters.AddWithValue("@newSeason", newSeason);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Update Error: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool CheckIfPlantExists(string plantName, string plantColor, string bloomSeason)
        {
            string query = "SELECT COUNT(*) FROM PlantTable WHERE plant_name = @plantName AND plant_color = @plantColor AND bloom_season = @bloomSeason";
            MySqlCommand command = new MySqlCommand(query, connection);

            // 매개변수 추가
            command.Parameters.AddWithValue("@plantName", plantName);
            command.Parameters.AddWithValue("@plantColor", plantColor);
            command.Parameters.AddWithValue("@bloomSeason", bloomSeason);

            try
            {
                connection.Open();
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0; // 식물이 존재하면 true, 그렇지 않으면 false 반환
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in CheckIfPlantExists: " + ex.Message);
                return false; // 예외 발생 시 false 반환
            }
            finally
            {
                connection.Close();
            }
        }
        public bool DeletePlantData(int plantId)
        {
            try
            {
                string query = "DELETE FROM PlantTable WHERE plant_id = @plantId";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@plantId", plantId);
                connection.Open();
                int result = cmd.ExecuteNonQuery();

                return result > 0; // 삭제가 성공적으로 수행되면 true 반환
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in DeletePlantData: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool AddPlantData(string plantName, string plantColor, string bloomSeason)
        {
            try
            {
                string query = "INSERT INTO PlantTable (plant_name, plant_color, bloom_season) VALUES (@plantName, @plantColor, @bloomSeason)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@plantName", plantName);
                cmd.Parameters.AddWithValue("@plantColor", plantColor);
                cmd.Parameters.AddWithValue("@bloomSeason", bloomSeason);

                connection.Open();
                int result = cmd.ExecuteNonQuery();

                return result > 0; // 성공적으로 추가되면 true 반환
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in AddPlantData: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool AddBookmark(int userId, int plantId)
        {
            try
            {
                // First, check if the bookmark already exists
                string checkQuery = "SELECT COUNT(*) FROM BookMarkTable WHERE uid = @userId AND plant_id = @plantId";
                MySqlCommand checkCmd = new MySqlCommand(checkQuery, connection);

                checkCmd.Parameters.AddWithValue("@userId", userId);
                checkCmd.Parameters.AddWithValue("@plantId", plantId);

                connection.Open();
                int exists = Convert.ToInt32(checkCmd.ExecuteScalar());
                if (exists > 0)
                {
                    // If the bookmark already exists, return false
                    return false;
                }

                // If the bookmark does not exist, proceed to insert it
                string insertQuery = "INSERT INTO BookMarkTable (uid, plant_id) VALUES (@userId, @plantId)";
                MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection);

                insertCmd.Parameters.AddWithValue("@userId", userId);
                insertCmd.Parameters.AddWithValue("@plantId", plantId);

                int result = insertCmd.ExecuteNonQuery(); // Executes the insert query

                return result > 0; // Returns true if the record was inserted successfully
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in AddBookmark: " + ex.Message);
                return false; // Returns false if there was an error
            }
            finally
            {
                connection.Close(); // Always close the connection
            }
        }
        public bool AddSearchHistory(int userId, int plantId, DateTime searchDate)
        {
            try
            {
                string query = "INSERT INTO SearchHistoryTable (uid, plant_id, search_date) VALUES (@userId, @plantId, @searchDate)";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@plantId", plantId);
                cmd.Parameters.AddWithValue("@searchDate", searchDate);

                connection.Open();
                int result = cmd.ExecuteNonQuery();

                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in AddSearchHistory: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool CheckBookmarkExists(int userId, int plantId)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM BookMarkTable WHERE uid = @userId AND plant_id = @plantId";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@plantId", plantId);

                connection.Open();
                int exists = Convert.ToInt32(cmd.ExecuteScalar());

                return exists > 0; // Returns true if the bookmark exists
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in CheckBookmarkExists: " + ex.Message);
                return false; // Returns false if there was an error
            }
            finally
            {
                connection.Close(); // Always close the connection
            }
        }

        public bool DeleteBookmark(int userId, int plantId)
        {
            try
            {
                string query = "DELETE FROM BookMarkTable WHERE uid = @userId AND plant_id = @plantId";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@plantId", plantId);

                connection.Open();
                int result = cmd.ExecuteNonQuery();

                return result > 0; // Returns true if the deletion was successful
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in DeleteBookmark: " + ex.Message);
                return false; // Returns false if there was an error
            }
            finally
            {
                connection.Close(); // Always close the connection
            }
        }





    }
}
