using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
namespace DBdemowithADO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("================================");
                Console.WriteLine("ADO.NET Demo");
                Console.WriteLine("1.Insert Data");
                Console.WriteLine("2.Update Data");
                Console.WriteLine("3.Delete Data");
                Console.WriteLine("4.Call Procedure");
                Console.WriteLine("5.Select Data with datareader");
                Console.WriteLine("6.Select Data with Dataset");
                Console.WriteLine("7.Call function");
                Console.WriteLine("================================");
                Console.WriteLine("Enter option:");
                int Choice, Status;
                Choice = Convert.ToInt32(Console.ReadLine());
                switch (Choice)
                {
                    case 1:
                        {
                            Status = GetUserInput.GetData(1);
                            if (Status > 0)
                            {
                                Console.WriteLine($"{Status} rows insertrd.");
                            }
                            else
                            {
                                Console.WriteLine("Insertion failed");
                            }
                            break;
                        }
                    case 2:
                        {
                            Status = UpdateUserData.GetData();
                            if (Status > 0)
                            {
                                Console.WriteLine($"{Status} rows updated.");
                            }
                            else
                            {
                                Console.WriteLine("Updation failed");
                            }
                            break;
                        }
                    case 3:
                        {
                            Status = DeleteUserData.GetIdforDelete();
                            if (Status > 0)
                            {
                                Console.WriteLine($"{Status} rows Deleted.");
                            }
                            else
                            {
                                Console.WriteLine("Deletion failed");
                            }
                            break;
                        }
                    case 4:
                        {
                            Status = GetUserInput.GetData(4);
                            if (Status > 0)
                            {
                                Console.WriteLine($"{Status} rows insertrd.");
                            }
                            else
                            {
                                Console.WriteLine("Insertion failed");
                            }
                            break;
                        }
                    case 5:
                        {
                            DataReaderDemo.ShowDataWithDataReader();
                            break;
                        }
                    case 6:
                        {
                            DatasetDemo.ShowDataWithDataSet();
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("Enter row number:");
                            int Rowid=Convert.ToInt32(Console.ReadLine());
                            FunctionCall.HighestcommisionofEmployee(Rowid);
                            break;
                        }
                }
            }
        }
    }
}