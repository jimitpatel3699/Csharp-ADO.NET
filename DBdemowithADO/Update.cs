using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBdemowithADO
{
    internal class Update
    {
        private static string? _connectionString = ConfigurationManager.ConnectionStrings["SqlServerConnection"].ConnectionString;
        public static int UpdateData(int Id, decimal Salary, decimal Commision)
        {
            string Query = "UPDATE Employee SET Salary=@Salary,Commision=@Commision WHERE Id=@Id";
            int rowsAffected = 0;
            try
            {
                    using SqlConnection connection = new SqlConnection(_connectionString);
                    connection.Open();
                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@Id", Id);
                    command.Parameters.AddWithValue("@Salary", Salary);
                    command.Parameters.AddWithValue("@Commision", Commision);
                    rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return rowsAffected;
        }
    }
}
