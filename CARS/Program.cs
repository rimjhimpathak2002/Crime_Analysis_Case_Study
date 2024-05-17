using CARS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS
{
    internal class Program
    {

        public static void Main(string[] args)
        {
            Console.WriteLine("--------------------Welcome To Crime Analysis Service System ---------------------------");
            Console.WriteLine("Please Enter Username");
            string username = Console.ReadLine();
            Console.WriteLine("Please Enter Password"); 
            string password = Console.ReadLine();
            if (username == "CARS" && password == "nature234")
            {
                MainModule md = new MainModule();
                md.Run();
            }
            else
            {
                Console.WriteLine("Incorrect Username or Password !! Try again.");
            }
      
        
            }
}
}
