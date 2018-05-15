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
                            break;
                        }
                    case "B":
                        {
                            //logic can be done actually inside the case
                            //one does not have to always call a method

                            //Roll the dice for each player
                            //The dot operator is used with your instance to access a property or behaviour
                            Player1Dice.Roll();
                            Player2Dice.Roll();

                            //Record the result for the roll for this turn
                            //We need to create a new instance of the Turn class
                            Turn aturn = new Turn();

                            //assign the facevalue of each dice to the Turn instance
                            //      set                         get
                            aturn.Player1DiceValue = Player1Dice.FaceValue;
                            aturn.Player2DiceValue = Player2Dice.FaceValue;

                            //Determine battle results
                            //It does not matter in this logic whether we use the values from aturn or the Die variables
                            if(aturn.Player1DiceValue > Player2Dice.FaceValue) //OR
                            {
                                aturn.TurnWinner = "Player 1";
                            }
                            else if (aturn.Player1DiceValue < aturn.Player2DiceValue)
                            {
                                aturn.TurnWinner = "Player 2";
                            }
                            else
                            {
                                aturn.TurnWinner = "It is a Draw";
                            }

                            //Display result to the user
                            Console.WriteLine("Results: Player 1 rolled {0}, " + " Player 2 rolled {1}, " + " Winner: {2}", aturn.Player1DiceValue, aturn.Player2DiceValue, aturn.TurnWinner);

                            //Add aturn instance to the List<T>
                            gameTurns.Add(aturn);
                            break;

                           
                        }
                    case "C":
                        {
                            //Display the current standing in the game
                            //foreach loop: This loop will start processing your collection from the first instance to the last instance, moving automatically to the next instance

                            //C# will strong datatype variable at compile time when the data type is used in declaring the variable
                            //C# also has a datatype called var.
                            //Var datatype is set at execution time BUT is still strongly datatype on its FIRST execution
                            foreach (var thisTurn in gameTurns)
                            {
                                Console.WriteLine("Results: Player 1 rolled {0}, " + " Player 2 rolled {1}, " + " Winner: {2}", thisTurn.Player1DiceValue, thisTurn.Player2DiceValue, thisTurn.TurnWinner);
                            }
                            Console.WriteLine("\n");
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
            Console.Write("Enter number of sides: ");

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
