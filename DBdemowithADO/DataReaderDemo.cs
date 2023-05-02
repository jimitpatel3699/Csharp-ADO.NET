using ConsoleTables;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBdemowithADO
{
    internal class DataReaderDemo
    {
        private static string? _connectionString = ConfigurationManager.ConnectionStrings["SqlServerConnection"].ConnectionString;
        public static void ShowDataWithDataReader()
        {
            string Query = "SELECT * FROM Employee";
            try
            {
                SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();
                SqlCommand command = new SqlCommand(Query, connection);
                SqlDataReader reader = command.ExecuteReader();
                var table = new ConsoleTable("Id", "EmployeeName", "Job", "ManagerId", "HireDate" ,"Salary","Commision","Department_Id");
                while (reader.Read())
                {
                    table.AddRow(reader["Id"], reader["EmployeeName"], reader["Job"], reader["ManagerId"], reader["HireDate"], reader["Salary"], reader["Commision"], reader["Department_Id"]);
                    
                }
                table.Options.EnableCount = false;
                table.Write();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
