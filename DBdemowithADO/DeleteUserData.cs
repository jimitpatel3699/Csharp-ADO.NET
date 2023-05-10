using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBdemowithADO
{
    internal class DeleteUserData
    {
        public static int GetIdforDelete()
        {
            int Id;
            Console.WriteLine("Enter employeeid:");
            Id = Convert.ToInt32(Console.ReadLine());
            int Status = FindId.EmployeeId(Id);
            if (Status == 0)
            {
                Console.WriteLine("Id not find");
            }
            else
            {
                try
                {
                    Status = Delete.DeleteData(Id);
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