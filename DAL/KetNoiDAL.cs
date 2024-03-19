using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DAL
{
    public class KetNoiDAL
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["QLTTSVNTNT"].ConnectionString;
        public static DataTable TruyVanLayDuLieu(string query)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                     adapter.Fill(data);
                }
            }

            return data;
        }


        public static int TruyVanKhongLayDuLieu(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    return command.ExecuteNonQuery();
                }
            }
        }
    }
}
