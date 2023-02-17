using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ///5.1
            ///tuple with user informaton
            (string Name, string[] Dishes) User;
            User.Dishes = new string[5];
            Console.Write("Enter your name: ");
            User.Name= Console.ReadLine();
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Enter your favourite dish {0}: ", i + 1);
                User.Dishes[i] = Console.ReadLine();
            }
            
        }
    }
}
