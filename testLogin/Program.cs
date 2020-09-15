using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;
using DataModels;
namespace testLogin
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Account");
            string Acc = Console.ReadLine();
            Console.WriteLine("Password");
            string Pass = Console.ReadLine();
            LoginService service = new LoginService();
            var emp= new Employees { Account = Acc, Password = Pass };
            service.EmpData = emp;
            if (service.Login())
            {
                Console.WriteLine("Login successful!");
                Console.WriteLine($"welcome {service.EmpData.FirstName} {service.EmpData.LastName}");
            }
            else
                Console.WriteLine("Login Unsuccessful!");
            Console.WriteLine("press any key to exit");
            Console.Read();
        }
    }
}
