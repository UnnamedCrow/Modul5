using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Modul5
{
    internal class Program
    {
        static (string Firstname, string Surname, byte Age, bool HavePet, byte PetCount, string[] PetName, string[] FavouriteColors) InputData()
        {
            (string Firstname, string Surname, byte Age, bool HavePet, byte PetCount, string[] PetName, string[] FavouriteColors) result;

            // Enter FirstName
            Console.Write("Enter your firstname: ");
            result.Firstname = Console.ReadLine();

            // Enter Surname
            Console.Write("Enter your surtname: ");
            result.Surname = Console.ReadLine();

            // Enter Age and chech input
            Console.Write("Enter your age: ");
            while (!byte.TryParse(Console.ReadLine(),out result.Age))
            {
                Console.Write("Oooops! Please try again. Enter your age:");
            }

            // Enter pets information
            result.HavePet = HavePetFunc();
            if (result.HavePet == true)
            {
                result.PetCount = PetCountFunc();
                result.PetName = PetNameFunc(result.PetCount);
            }


            return result;
        }
        /// <summary>
        /// enter pets names
        /// </summary>
        /// <param name="PetCount"></param>
        /// <returns>pet names</returns>
        static string[] PetNameFunc (int PetCount)
        {
            string[] result = new string[PetCount];
            for(int i = 0; i < PetCount; i++)
            {
                Console.Write("Please enter name your pet number {0}", i + 1);
                result[i] = Console.ReadLine();
            }
            return result;
        }

        /// <summary>
        /// User enters information about his pets
        /// </summary>
        /// <returns>bool</returns>
        static byte PetCountFunc()
        {
            byte result = 0;
            Console.Write("How many pets do you have: ");
            if(byte.TryParse(Console.ReadLine(), out result))
                return result;
            else
            {
                Console.WriteLine("Oooops! Please try again...");
                return PetCountFunc();
            }
        }

        /// <summary>
        /// User enters information about his pets
        /// </summary>
        /// <returns>bool</returns>
        static bool HavePetFunc()
        {
            Console.Write("Do you have a pet? Yes or No: ");
            string HavePet = Console.ReadLine();
            if (HavePet == "Yes" || HavePet == "yes")
                return true;
            else
                if (HavePet == "No" || HavePet == "no")
                return false;
            else
            {
                Console.WriteLine("Oooops! Please try again");
                return HavePetFunc();
            }
        }
        static void Main()
        {
             
            Console.ReadLine();
        }
    }
}
