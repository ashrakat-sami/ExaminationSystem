using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        static string adminPassword="123";
        static string adminName="admin";

        

        public void ExamNotification(string message)
        {
            Console.WriteLine($"Notification: {message}");
        }


        public static bool Login()
        {
           Console.Write("UserName:");
            string name = Console.ReadLine();
            Console.Write("Password:");
            string password = Console.ReadLine();

            if (name == adminName && password == adminPassword)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You are now logged in...\n");
                Console.ForegroundColor = ConsoleColor.White;

                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("UserName or Password is incorrect");
                Console.ForegroundColor = ConsoleColor.White;

                return false;
            }

        }

    }
}
