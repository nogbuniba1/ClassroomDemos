using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create the instances of our objects to be used in this program
            //You can check for additional namespaces that may be needed to use your objects.

            //We need to have a structure that will allow one to hold an unknown number of instances of a variable
            //List<T> is an object that holds 'X' number of data type instances
            //The new List<T> physically creates the instance of List<T> in memory. The constructor od list<T> is called
            List<Turn> gameTurns = new List<Turn>();


            //Create 2 instances of the die object
            Die Player1Dice = new Die();            //Default Constructor
            Die Player2Dice = new Die(6, "green");       //Greedy Constructor
            string menuChoice = "";
            do
            {
                Console.WriteLine("Game Menu: \n");
                Console.WriteLine("A) Set Die side count");
                Console.WriteLine("B) Roll the dice");
                Console.WriteLine("C) Display all game turn results");
                Console.WriteLine("X) Exit");
                Console.Write("Enter menu choice: ");
                menuChoice = Console.ReadLine();

                switch (menuChoice.ToUpper())
                {

                    case "A":
                        {
                            //logic can de done using a method
                            //The method will need to ahve the variable Player1Dice and Player2Dice passed to it.
                            //Objects are passed by reference
                            SetDiceSides(Player1Dice, Player2Dice);
                            //Console.WriteLine("You selected A");
                            break;
                        }
                    case "B":
                        {
                            //logic can be done actually inside the case
                            //one does not have to always call a method

                            Console.WriteLine("You selected B");
                            break;
                        }
                    case "C":
                        {
                            Console.WriteLine("You selected C");
                            break;
                        }
                    case "X":
                        {
                            Console.WriteLine("Thank you for playing. Come again.");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid menu choice. Try again.");
                            break;
                        }

                }
            } while (menuChoice.ToUpper() != "X");
            Console.ReadKey();
        }
        public static void SetDiceSides(Die player1dice, Die player2dice)
        {
            string indicesize = "";
            int dicesize = 6;
            Console.WriteLine("Set Dice face count of 6 to 20");
            Console.WriteLine("An invalid entry will default to 6");
            Console.WriteLine("Enter number of sides");

            indicesize = Console.ReadLine();

            //Validation
            //a) Did the user enter a number
            if (!int.TryParse(indicesize, out dicesize))
            {
                Console.WriteLine("Die size is invalid. Die size will be set to 6");
                dicesize = 6;
            }
            else
            {
                //b) Is the integer btw 6 and 20
                if (dicesize < 6 || dicesize > 20)
                {
                    Console.WriteLine("Die size is invalid. Die size will be set to 6");
                    dicesize = 6;
                }
                else
                {
                    Console.WriteLine("Die size will be set to {0}", dicesize);
                }
            }
            player1dice.SetSides(dicesize);
            player2dice.SetSides(dicesize);
        }
    }
}
