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
            result.Age = GetUserAge();

            /// Enter pets information
            result.HavePet = HavePetFunc();
            if (result.HavePet == true)

                /// if user have pet or rets - input pets names
                result.PetName = GetPetName(PetCountFunc());
            else
                
                /// if user don't have pets - don't need to input names
                result.PetName = null;

            /// Enter colors information
            int HowManyColors = GetNumColors();
            if (HowManyColors > 0)

                /// if user have favourite colors - input names of this colors
                result.FavouriteColors = GetFavColors(HowManyColors);
            else

                /// if user have no favourite colors - don't neep to intput colors
                result.FavouriteColors = null;
            return result;
        }

        /// Function for get users age
        /// and validate input data
        static byte GetUserAge()
        {
            Console.Write("Enter your age: ");
            if(byte.TryParse(Console.ReadLine(), out byte result) && result > 0)
                return result;
            else
            {
                Console.WriteLine("Oooops! Please try again...");
                return GetUserAge();
            }
        }

        /// Get num of favourite colors 
        /// and validate data
        /// <returns>num of favourite colors</returns>
        static int GetNumColors()
        {           
            Console.Write("Enter num of your favourite colors: ");
            if(int.TryParse(Console.ReadLine(), out int result))
                return result;
            else
            {
                Console.WriteLine("Oooops! Please try again...");
                return GetNumColors();
            }
                
        }

        /// Get favourite colors from user
        static string[] GetFavColors(int ColorsCount)
        {
            string[] result = new string[ColorsCount];
            for (int i = 0; i < ColorsCount; i++)
            {
                Console.Write("Please enter your favourite color number {0}: ", i + 1);
                result[i] = Console.ReadLine();
            }
            return result;
        }

        /// enter pets names
        /// <param name="PetCount"></param>
        /// <returns>pet names</returns>
        static string[] GetPetName(int PetCount)
        {
            string[] result = new string[PetCount];
            for (int i = 0; i < PetCount; i++)
            {
                Console.Write("Please enter name your pet number {0}: ", i + 1);
                result[i] = Console.ReadLine();
            }
            return result;
        }

        /// <summary>
        /// User enters information about his pets
        /// validation 
        /// </summary>
        /// <returns>bool</returns>
        static byte PetCountFunc()
        {
            Console.Write("How many pets do you have: ");
            if (byte.TryParse(Console.ReadLine(), out byte result) && result > 0)
                return result;
            else
            {
                Console.WriteLine("Oooops! Please try again...");
                return PetCountFunc();
            }
        }

        /// <summary>
        /// User enters information about his pets
        /// validation
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

        /// <summary>
        /// output function
        /// for user tuple
        /// </summary>
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

                ///If user have no pets
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
            /// Input Users data in to tuple
            var User = InputData();

            ///Outpun users data from tuple
            OutputData(User);
            Console.ReadLine();
        }
    }
}
