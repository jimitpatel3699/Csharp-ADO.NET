using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBdemowithADO
{
    internal class FunctionCall
    {
        private static string? _connectionString = ConfigurationManager.ConnectionStrings["SqlServerConnection"].ConnectionString;
        public static void HighestcommisionofEmployee(int Rownum)
        {
            string Query = "SELECT * FROM fn_EmployeehighestCommision(@Rownum)";
            try
            {
                SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();
                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@Rownum",Rownum);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable("Employee");
                adapter.Fill(dataTable);
                connection.Close();
                var table = new ConsoleTable("Id", "EmployeeName", "Job", "ManagerId", "HireDate", "Salary", "Commision", "Department_Id");
                foreach (DataRow row in dataTable.Rows)
                {
                    table.AddRow(row["Id"], row["EmployeeName"], row["Job"], row["ManagerId"], row["HireDate"], row["Salary"], row["Commision"], row["Department_Id"]);

                }
                table.Options.EnableCount = false;
                table.Write();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}