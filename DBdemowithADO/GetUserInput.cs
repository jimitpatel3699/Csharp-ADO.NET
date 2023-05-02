using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DBdemowithADO
{
    public class GetUserInput
    {
        public static int GetData(int choice)
        {
            int Status = 0;
            string Empname, Job, HireDate;
            int Id, ManagerId, DeptId;
            decimal Salary, Comission;
            Console.WriteLine("Enter employeeid:");
            Id=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter employeename:");
            Empname=Console.ReadLine();
            Console.WriteLine("Enter employeejob:");
            Job=Console.ReadLine();
            Console.WriteLine("Enter employeemanagerid:");
            ManagerId=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter hiredate(MM/DD/YYYY):");
            HireDate=Console.ReadLine();
            Console.WriteLine("Enter Salary:");
            Salary=Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter Comission:");
            Comission=Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter departmentid:");
            DeptId=Convert.ToInt32(Console.ReadLine());
            try
            {
                if(choice==1)
                {
                    Status = Insert.InsertData(Id, Empname, Job, ManagerId, HireDate, Salary, Comission, DeptId);
                }
                if(choice==4)
                {
                    Status = ProceudreCall.CallProcedure(Id, Empname, Job, ManagerId, HireDate, Salary, Comission, DeptId);
                }
            }
            catch
            (Exception ex)
            { 
                Console.WriteLine(ex.ToString());
            }
            return Status;
        }
    }
}
