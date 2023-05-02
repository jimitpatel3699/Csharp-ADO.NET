using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DBdemowithADO
{
    internal class FindId
    {
        private static string? _connectionString = ConfigurationManager.ConnectionStrings["SqlServerConnection"].ConnectionString;
        public static int EmployeeId(int Id)
        {
            int Status = 0;
            object? Result = null;
            string Query = "SELECT Id FROM Employee WHERE Id=@Id";
            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();
                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@Id", Id);
                Result=command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if(Result != null) { Status = 1; }
            else {  Status = 0; }
            return Status;
        }
    }
}