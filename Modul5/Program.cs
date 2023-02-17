using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul5
{
    internal class Program
    {
        /// 5.1.5
        /// add new metod for read color
        static string ShowColor()
        {
            Console.WriteLine("Напишите свой любимый цвет на английском с маленькой буквы");
            string color = Console.ReadLine();

            switch (color)
            {
                case "red":
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Your color is red!");
                    return color;

                case "green":
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Your color is green!");
                    return color;
                case "cyan":
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Your color is cyan!");
                    return color;
                default:
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Your color is yellow!");
                    return color;
            }
        }
        static void Main(string[] args)
        {
            ///5.1
            ///tuple with user informaton
            (string Name, string[] Dishes) User;
            User.Dishes = new string[5];
            Console.Write("Enter your name: ");
            User.Name = Console.ReadLine();
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Enter your favourite dish {0}: ", i + 1);
                User.Dishes[i] = Console.ReadLine();
            }

            /// 5.1.5
            /// use ShowColor
            string[] FavouriteColors = new string[3];
            for(int i = 0; i < 3;i++)
            {
                FavouriteColors[i] = ShowColor();
            }
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(FavouriteColors[i]);
            }
            Console.ReadLine();
        }
    }
}
