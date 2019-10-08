using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MWeb_test
{
    public class QueryMarkers
    {
        private static void QueryMarkerFromSQL(string connectionString)
        {
            string storedProcedure = "dbo.spGetCoordJSON";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(storedProcedure, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0},{1}", reader[0], reader[1]));
                    }
                }
            }
        }
    }
}
