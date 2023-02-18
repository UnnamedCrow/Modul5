using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

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
        /// 5.2.14
        /// add optional param num, that means size of array

        static int[] GetArrayFromConsole(int num = 5)
        {
            var result = new int[num];
            for (int i = 0; i < result.Length; i++)
            {
                Console.Write("Введите элемент массива номер {0}: ", i + 1);
                result[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Array is ready");
            return result;
            //add sorting

        }

        ///5.3.13
        ///add two functions for array sorting <summary>

        /// sorting biggest Up
        static int[] SortArrayAsc(in int[] array)
        {
            int[] result = new int[array.Length];
            for (int i = 0; i < result.Length;i++)
                result[i] = array[i];
            for (int i = 1; i < result.Length; i++)
            {
                for (int j = 0; j < result.Length - i; j++)
                {
                    if (result[j] > result[j + 1])
                    {
                        (result[j], result[j + 1]) = (result[j + 1], result[j]);
                    }
                }
            }
            return result;
        }

        /// sorting biggest down
        static int[] SortArrayDesc(in int[] array)
        {
            int[] result = new int[array.Length];
            for (int i = 0; i < result.Length; i++)
                result[i] = array[i];
            for (int i = 1; i < result.Length; i++)
            {
                for (int j = 0; j < result.Length - i; j++)
                {
                    if (result[j] < result[j + 1])
                    {
                        (result[j], result[j + 1]) = (result[j + 1], result[j]);
                    }
                }
            }
            return result;
        }
        /// 5.2.8
        /// Array sorting
        /// 5.2.17 add optional boolean param for sorting
        static void SortArray(in int[] array, out int[] sortarrayasc, out int[] sortarraydesc)
        {
              
            sortarraydesc = SortArrayDesc(in array);
            sortarrayasc = SortArrayAsc(in array);

        }


        /// <summary>
        /// 5.5.3
        /// add recursion function Echo
        /// </summary>
        static void Echo (string line, int step)
        {
            string a = line;
            /// 5.5.4 add relation Foreground color from step;
            if(15 > step && step > 0)
                Console.ForegroundColor = (ConsoleColor) step;
            Console.WriteLine(".." + a);
            a = a.Remove(0, 1);
            if(step > 0)
            {
              Echo(a, step - 1);  
              
            }
        }

        /// <summary>
        /// 5.5.8
        /// add function Power Up
        /// </summary>
        static int PowerUp(int n, byte pow)
        {
            if (pow == 0)
                return 1;
            else
            if (pow == 1)
                return n;
            else
                return n * PowerUp(n, --pow);
            
                
        }

      

        static void Main()
        {
            /// 5.5.8
            /// use recursive function PowerUp
            Console.WriteLine(PowerUp(5, 3));
            
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

            ///5.5.3
            ///use recirsive function
            Echo(User.Name, User.Name.Length - 1);

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

            /// 5.1.6, 5.2.14
            Console.Write("Enter size of array: ");
            int ArraySize = int.Parse(Console.ReadLine());
            int[] NewArray = GetArrayFromConsole(ArraySize);

            ///5.3.13



            SortArray(in NewArray, out int[] Sortedasc, out int[] Sorteddesc);

            Console.WriteLine("NewArray:");
            foreach (int i in NewArray)
            {
                Console.Write(" " + i);
            }
            Console.WriteLine("\nSortedasc:");
            foreach (int i in Sortedasc)
            {
                Console.Write(" " + i);
            }
            Console.WriteLine("\nSorteddesc: ");
            foreach (int i in Sorteddesc)
            {
                Console.Write(" " + i);
            }
            Console.ReadLine();
        }
    }
}
