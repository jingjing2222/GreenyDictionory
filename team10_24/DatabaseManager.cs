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

        // 데이터베이스 연결
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

        //데이터베이스 연결 종료
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

        //식물 데이터 업데이트
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

        // 식물 이름, 색상, 개화기를 기준으로 데이터베이스에 존재하는지 확인
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

        // 식물 데이터 삭제
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

        // 식물 데이터 추가
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

        // 북마크 추가
        public bool AddBookmark(int userId, int plantId)
        {
            try
            {
                // 북마크가 이미 존재하는지 확인
                string checkQuery = "SELECT COUNT(*) FROM BookMarkTable WHERE uid = @userId AND plant_id = @plantId";
                MySqlCommand checkCmd = new MySqlCommand(checkQuery, connection);

                checkCmd.Parameters.AddWithValue("@userId", userId);
                checkCmd.Parameters.AddWithValue("@plantId", plantId);

                connection.Open();
                int exists = Convert.ToInt32(checkCmd.ExecuteScalar());
                if (exists > 0)
                {
                    // 북마크가 존재하는 경우 false 반환
                    return false;
                }

                // 북마크가 존재하지 않으면 계속 삽입
                string insertQuery = "INSERT INTO BookMarkTable (uid, plant_id) VALUES (@userId, @plantId)";
                MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection);

                insertCmd.Parameters.AddWithValue("@userId", userId);
                insertCmd.Parameters.AddWithValue("@plantId", plantId);

                int result = insertCmd.ExecuteNonQuery(); // 삽입 쿼리문 실행
                return result > 0; // 성공적으로 삽입되면 true를 반환
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in AddBookmark: " + ex.Message);
                return false; // 오류가 있으면 false 반환
            }
            finally
            {
                connection.Close(); // 항상 연결 닫기
            }
        }

        // 검색기록 추가
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

        // 북마크 존재 확인
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

                return exists > 0; // 북마크가 존재하면 true를 반환
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in CheckBookmarkExists: " + ex.Message);
                return false; // 오류가 있으면 false 반환
            }
            finally
            {
                connection.Close(); // 항상 연결 닫기
            }
        }

        // 북마크 삭제
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

                return result > 0; // 삭제가 성공되면 true 반환
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in DeleteBookmark: " + ex.Message);
                return false; // 오류 발생하면 false 반환
            }
            finally
            {
                connection.Close(); // 항상 연결 닫기
            }
        }
        // 일기장 추가
        public bool AddDiaryEntry(int userId, string diaryDate, string diaryEntry)
        {
            try
            {
                string query = "INSERT INTO DiaryTable (uid, diary_date, diary_entry) VALUES (@userId, @diaryDate, @diaryEntry)";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@diaryDate", diaryDate);
                cmd.Parameters.AddWithValue("@diaryEntry", diaryEntry);

                connection.Open();
                int result = cmd.ExecuteNonQuery();

                return result > 0; // 삽입 성공하면 true 반환
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in AddDiaryEntry: " + ex.Message);
                return false; // 오류 발생하면 false 반환
            }
            finally
            {
                connection.Close();
            }
        }
        public class DiaryEntry
        {
            public int DiaryId { get; set; }
            public string DiaryDate { get; set; }
            public string DiaryText { get; set; }
        }

        // 특정 유저 일기 가져오기
        public List<DiaryEntry> GetDiaryEntriesForUser(int userId)
        {
            List<DiaryEntry> entries = new List<DiaryEntry>();
            string query = "SELECT diary_id, diary_date, diary_entry FROM DiaryTable WHERE uid = @UserId ORDER BY diary_date DESC";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    connection.Open();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            entries.Add(new DiaryEntry
                            {
                                DiaryId = reader.GetInt32("diary_id"),
                                DiaryDate = reader.GetString("diary_date"),
                                DiaryText = reader.GetString("diary_entry")
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetDiaryEntriesForUser: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return entries;
        }

        // 일기 가져오기
        public DiaryEntry GetDiaryEntry(int userId, int diaryId)
        {
            DiaryEntry entry = null;
            string query = "SELECT diary_id, diary_date, diary_entry FROM DiaryTable WHERE uid = @UserId AND diary_id = @DiaryId";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@DiaryId", diaryId);
                    connection.Open();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            entry = new DiaryEntry
                            {
                                DiaryId = reader.GetInt32("diary_id"),
                                DiaryDate = reader.GetString("diary_date"),
                                DiaryText = reader.GetString("diary_entry")
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetDiaryEntry: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return entry;
        }

        // 일기 업데이트
        public bool UpdateDiaryEntry(int diaryId, string newEntry)
        {
            try
            {
                string query = "UPDATE DiaryTable SET diary_entry = @newEntry WHERE diary_id = @diaryId";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@diaryId", diaryId);
                    cmd.Parameters.AddWithValue("@newEntry", newEntry);

                    connection.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in UpdateDiaryEntry: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        // 일기 삭제
        public bool DeleteDiaryEntry(int diaryId)
        {
            try
            {
                string query = "DELETE FROM DiaryTable WHERE diary_id = @diaryId";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@diaryId", diaryId);

                    connection.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in DeleteDiaryEntry: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        // 리뷰 추가
        public bool AddReview(int userId, int plantId, string reviewContent)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var query = "INSERT INTO ReviewTable (uid, plant_id, review_content, review_date) VALUES (@uid, @plantId, @reviewContent, NOW())";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@uid", userId);
                    cmd.Parameters.AddWithValue("@plantId", plantId);
                    cmd.Parameters.AddWithValue("@reviewContent", reviewContent);
                    var result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
        }

        // 특정 식물 리뷰 가져오기
        public List<(string UserName, string ReviewContent)> GetReviews(int plantId)
        {
            List<(string UserName, string ReviewContent)> reviews = new List<(string UserName, string ReviewContent)>();

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                // 'plant_id' 조건을 추가하여 해당 식물에 대한 리뷰만 가져옵니다
                var query = "SELECT u.username, r.review_content FROM ReviewTable r JOIN UserTable u ON r.uid = u.uid WHERE r.plant_id = @plantId";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@plantId", plantId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string userName = reader.GetString("username");
                            string reviewContent = reader.GetString("review_content");
                            reviews.Add((UserName: userName, ReviewContent: reviewContent));
                        }
                    }
                }
            }

            return reviews;
        }
    }
}
