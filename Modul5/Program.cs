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
        static (string Firstname, string Surname, byte Age, bool HavePet, string[] PetName, string[] FavouriteColors) InputData()
        {
            (string Firstname, string Surname, byte Age, bool HavePet, string[] PetName, string[] FavouriteColors) result;

            /// Enter FirstName
            Console.Write("Enter your firstname: ");
            result.Firstname = Console.ReadLine();

            /// Enter Surname
            Console.Write("Enter your surtname: ");
            result.Surname = Console.ReadLine();

            /// Enter Age and validate intup data          
            Console.Write("Enter your age: ");
            result.Age = GetCount("Oooops! Please try again... \nEnter your age: ");

            /// Enter pets information and validate input data
            result.HavePet = HavePetFunc();
            if (result.HavePet == true)
            {
                /// if user have pet or rets - input pets names
                Console.Write("How many pets do you have: ");          
                result.PetName = GetNames(GetCount("Oooops! Please try again... \nHow many pets do you have: "), "Please enter name your pet number {0}: ");
            }
            else 
                /// if user don't have pets - don't need to input names
                result.PetName = null;

            /// Enter colors information and validate input information
            int HowManyColors = 0;
            Console.Write("Enter num of your favourite colors: ");
            /// validation
            while (!int.TryParse(Console.ReadLine(), out HowManyColors) || HowManyColors < 0)
            {
                Console.Write("Oooops! Please try again... \nHow many favourite colors do you have: ");
            }
            if (HowManyColors > 0)
                /// if user have favourite colors - input names of this colors
                result.FavouriteColors = GetNames(HowManyColors, "Please enter your favourite color number {0}: ");
            else
                /// if user have no favourite colors - don't neep to intput colors
                result.FavouriteColors = null;
            return result;
        }
        /// enter age, count pets, count colors
        /// count validation function
        static byte GetCount(string Message)
        {
            if (!byte.TryParse(Console.ReadLine(), out byte count) || count <= 0)
            {
                Console.WriteLine(Message);
                return GetCount(Message);
            }
            else
                return count;
        }
        /// enter  names of pets and colors
        static string[] GetNames(int Count, string Message)
        {
            string[] result = new string[Count];
            for (int i = 0; i < Count; i++)
            {
                Console.Write(Message, i + 1);
                result[i] = Console.ReadLine();
            }
            return result;
        }
        /// User enters information about his pets
        /// validation
        static bool HavePetFunc()
        {
            Console.Write("Do you have a pet? Yes or No: ");
            string HavePet = Console.ReadLine();
            if (string.Equals(HavePet, "YES", StringComparison.OrdinalIgnoreCase))
                return true;
            else
                if (string.Equals(HavePet, "NO", StringComparison.OrdinalIgnoreCase))
                return false;
            else
            {
                Console.WriteLine("Oooops! Please try again");
                return HavePetFunc();
            }
        }
        /// output function for user tuple
        static void OutputData((string Firstname, string Surname, byte Age, bool HavePet, string[] PetName, string[] FavouriteColors) User)
        {
            /// Output Users firstname and surname
            Console.WriteLine("Hello dear, {0} {1}", User.Firstname, User.Surname);

            /// Output Users Age
            Console.WriteLine("Your age is {0} years", User.Age);

            /// Output users pets names if user have pets
            if (User.HavePet)
            {
                /// If user entered pets
                Console.WriteLine("Users pets name is ");
                for (int i = 0; i < User.PetName.Length; i++)
                    Console.WriteLine(User.PetName[i] + " ");
            }
            else
                /// If user have no pets
                Console.WriteLine("User didn't enter any pet");

            /// Output users favourite colors if user have favourite colors
            if (User.FavouriteColors != null)
            {
                Console.WriteLine("Users favourite colors is ");
                for (int i = 0; i < User.FavouriteColors.Length; i++)
                    Console.WriteLine(User.FavouriteColors[i] + " ");
            }
            else
                /// If User have no favourite color
                Console.WriteLine("User didn't enter any favourite color");
        }
        static void Main()
        {
            var User = InputData();

            ///Outpun users data from tuple
            OutputData(User);
            Console.ReadLine();
        }
    }
}
