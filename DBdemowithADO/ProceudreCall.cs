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
    internal class ProceudreCall
    {
        private static string? _connectionString = ConfigurationManager.ConnectionStrings["SqlServerConnection"].ConnectionString;
        public static int CallProcedure(int Id, string EmpName, string Job, int ManagerId, string Hiredate, decimal Salary, decimal Commision, int DeptId)
        {
            int rowsAffected = 0;
            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("usp_EmployeeInsert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", Id);
                command.Parameters.AddWithValue("@EmployeeName", EmpName);
                command.Parameters.AddWithValue("@Job", Job);
                command.Parameters.AddWithValue("@ManagerId", ManagerId);
                command.Parameters.AddWithValue("@Hiredate", Hiredate);
                command.Parameters.AddWithValue("@Salary", Salary);
                command.Parameters.AddWithValue("@Commision", Commision);
                command.Parameters.AddWithValue("@Department_Id", DeptId);
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
