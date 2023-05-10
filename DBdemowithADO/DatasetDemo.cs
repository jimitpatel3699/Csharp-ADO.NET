using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBdemowithADO
{
    internal class DatasetDemo
    {
        private static string? _connectionString = ConfigurationManager.ConnectionStrings["SqlServerConnection"].ConnectionString;
        public static void ShowDataWithDataSet()
        {
            string Query = "SELECT * FROM Employee";
            try
            {
                SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();
                SqlCommand command = new SqlCommand(Query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                connection.Close();
                var table = new ConsoleTable("Id", "EmployeeName", "Job", "ManagerId", "HireDate", "Salary", "Commision", "Department_Id");
                foreach (DataRow row in dataSet.Tables[0].Rows)
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