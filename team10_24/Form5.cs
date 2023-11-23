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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void history_Click(object sender, EventArgs e)
        {
<<<<<<< Updated upstream
=======
            // 로그인한 사용자의 UID를 12로 고정. 실제 애플리케이션에서는 로그인 세션 등을 통해 동적으로 얻어야 합니다.
            int loggedInUserId = UserSession.Instance.UserId; // 로그인한 사용자의 UID 사용

            try
            {
                // MySQL 데이터베이스에 연결
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    // 사용자의 UID에 해당하는 식물 이름을 조회하는 SQL 쿼리
                    string query = @"
                    SELECT PlantTable.plant_name 
                    FROM PlantTable 
                    INNER JOIN SearchHistoryTable ON PlantTable.plant_id = SearchHistoryTable.plant_id 
                    WHERE SearchHistoryTable.uid = @UserId";

                    // 쿼리 실행
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // 쿼리에 사용자의 UID를 매개변수로 전달
                        cmd.Parameters.AddWithValue("@UserId", loggedInUserId);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
>>>>>>> Stashed changes

        }
    }
}
