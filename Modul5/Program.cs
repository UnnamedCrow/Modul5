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
        /// add new metod for read color <summary>
        /// 5.2.2, 5.2.7
        /// add one param in function

        static string ShowColor(string name, int age)
        {
            /// 5.2.3, 5.2.7 modificate console otput
            Console.Write($"{name}, {age}\n напишите свой любимый цвет на английском с маленькой буквы :");
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

        /// 5.1.6
        /// get array from the console
        /// 5.2.8
        /// modificate input array
        static int[] GetArrayFromConsole()
        {
            Console.Write("Enter size of array: ");
            int i = int.Parse(Console.ReadLine());
            var result = new int[i];
            for (i = 0; i < result.Length; i++)
            {
                Console.Write("Введите элемент массива номер {0}: ", i + 1);
                result[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Array is ready");
            return result;
            //add sorting

        }
        /// <summary>
        /// 5.2.8
        /// Array sorting
        static int[] SortArray(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
                }
            }
            return array;
        }
        static void Main(string[] args)
        {
            ///5.1
            ///tuple with user informaton
            (string Name, int Age, string[] Dishes) User;
            User.Dishes = new string[5];
            Console.Write("Enter your name: ");
            User.Name = Console.ReadLine();
            Console.Write("Enter your age: ");
            User.Age = Convert.ToInt16(Console.ReadLine());
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Enter your favourite dish {0}: ", i + 1);
                User.Dishes[i] = Console.ReadLine();
            }

            /// 5.2.2
            /// modificate function ShowColor

            /// 5.1.5
            /// use ShowColor
            string[] FavouriteColors = new string[3];
            for (int i = 0; i < 3; i++)
            {
                FavouriteColors[i] = ShowColor(User.Name, User.Age);
            }
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(FavouriteColors[i]);
            }

            // 5.1.6
            int[] NewArray = GetArrayFromConsole();
            NewArray = SortArray(NewArray);

            foreach (int i in NewArray)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }
    }
}
