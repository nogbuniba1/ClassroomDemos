using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsDriver
{
    //Classes by default have an access priviledge of private. 
    //You must add public to your classes

    public class Die
    {
        //Create a new instance of the math object random. 
        //This will be shared by each instance of die
        //The instance of random object will be created when the first instance of Die is created

        private static Random _rnd = new Random();

        //Classes have 4 basic things
        //a) Data members
        //b) Properties
        //c) Constructors
        //d) Behaviours (Method)

        // Data members may be private for the class for use only within the class
        // The interface with a class is done via properties and behaviours


        //PROPERTIES
        //Properties can be fully implemented. They don't have parameters:
        // - a private data member
        // - a public property
        // - the name of the datemember doesn't have to be the same with the property.
        private int _Sides; //data member
        public int Sides    //property
        {
            get
            {
                //This will return the private data member
                return _Sides;
            }
            private set //we can use the SetSides method to set the _Sides instead
            {
                //"Value" is a reserved keyword used to 
                //obtain the incoming data value to the property 
                //save the incoming date value to your private
                //data member
                _Sides = value; 

            }
        }


        ///Properties can be auto implemented
        // does not have a private data member 
        // the system creates an internal data storage member for the property

        //For the outside user, the "Set" property is now a Read Only
        //Methods and Codes WITHIN the class still have access to the Class
        public int FaceValue { get; private set; }

        //Within a property, you can validate that the incoming data value is "what is expected"

        private string _Color; //data member
        public string Color //property
        {
            get
            {
                return _Color;
            }
            set
            {
                //sample validation - there MUST be date within the incoming value
                //so an empty string is invalid
                if(string.IsNullOrEmpty(value)) //The .IsNullOrEmpty catches string == " " and string == null
                {
                    //incoming data value is incorrect
                    //a) you could send an error message to the outside user
                    //throw new Exception("Color must have a value");

                    //OR

                    //b) you could allow the storage of a null value within the string data member
                    _Color = null;
                }
                else
                {
                    _Color = value;
                }
                
            }
        }



        //CONSTRUCTORS
        //Constructors are NOT directly called by the outside user
        //Constructors are called indirectly when the outside user creates an instance of the class
        //To create an instance of the class, the ootside user will declare --> class variableName = new class();
        //It is the "new" that calles the constructor, you may or may not have a constructor for your class 
        //If you do not code a constructor for your class, then the default system constuctor is executed
        //This default system constructor initializes your local data memeber to their default C# value (Default for numeric = 0, string = null, boolean is False)


        //If you code a constructor for your class then, you are responsible for all/any constructor in the class

        //"DEFAULT" CONSTRUCTOR
        //This constructor is similar to the system constructor
        //This constructor would be called for  --> new classname();
        public Die()
        {
            //even though the sides would be set to a value numeric, within this class a more logical value would be 6
            Sides = 6;
            Color = "White";
            Roll();
        }

        //"GREEDY" CONSTRUCTOR
        //This constructor usually receives a list of parameter, one for each data member in the class
        //The constructor takes the parameter values and assigns the value to the appropriate data member
        //This constructor would be called for ---> new classname(value1, value2.....)
        public Die(int sides, string color)
        {
            Sides = sides; //The set{} of the property sides is used. The set is on the left side
            Color = color;
            Roll();
        }

        //BEHAVIOURS
        //These are METHODS
        public void Roll()
        {
            //This method will be used to generate a new faceValue for the instance
            //The instance of the math class Randon() has been coded at the top of this class
            //The method in the class Random will be called .Next(Inclusive lowest number, exclusive highest number)
            FaceValue = _rnd.Next(1, Sides + 1);
        }

        public void SetSides (int sides)
        {
            //let us assume only 6 to 20 sided dice are allowed
            if(sides > 5 && sides < 21)
            {
                Sides = sides;
                Roll();
            }
            else
            {
                //bad input
                throw new Exception("Invalid number of sides for the dice");
            }
        }
    }
}
