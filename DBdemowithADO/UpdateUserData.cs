using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBdemowithADO
{
    internal class UpdateUserData
    {
        public static int GetData()
        { 
            int Id;
            decimal Salary, Comission;
            Console.WriteLine("Enter employeeid:");
            Id = Convert.ToInt32(Console.ReadLine());
            int Status = FindId.EmployeeId(Id);
            if (Status == 0)
            {
                Console.WriteLine("Id not find");
            }
            else
            {
                Console.WriteLine("Enter Salary:");
                Salary = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Enter Comission:");
                Comission = Convert.ToDecimal(Console.ReadLine());
                try
                {
                    Status = Update.UpdateData(Id, Salary, Comission);
                }
                catch
                (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            return Status;
        }
    }
}
