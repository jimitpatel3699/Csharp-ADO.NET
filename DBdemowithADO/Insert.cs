using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBdemowithADO
{
    internal class Insert
    {   
        private static string? _connectionString = ConfigurationManager.ConnectionStrings["SqlServerConnection"].ConnectionString;
        public static int InsertData(int Id,string EmpName,string Job,int ManagerId,string Hiredate,decimal Salary,decimal Commision,int DeptId)
        {
            string Query = "INSERT INTO Employee(Id,EmployeeName,Job,ManagerId,HireDate,Salary,Commision,Department_Id) VALUES(@Id,@EmployeeName,@Job,@ManagerId,@HireDate,@Salary,@Commision,@DepartmentId)";
            int rowsAffected = 0;
            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();
                SqlCommand command = new SqlCommand(Query,connection);
                command.Parameters.AddWithValue("@Id",Id);
                command.Parameters.AddWithValue("@EmployeeName",EmpName);
                command.Parameters.AddWithValue("@Job",Job);
                command.Parameters.AddWithValue("@ManagerId",ManagerId);
                command.Parameters.AddWithValue("@Hiredate",Hiredate);
                command.Parameters.AddWithValue("@Salary",Salary);
                command.Parameters.AddWithValue("@Commision",Commision);
                command.Parameters.AddWithValue("@DepartmentId",DeptId);
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