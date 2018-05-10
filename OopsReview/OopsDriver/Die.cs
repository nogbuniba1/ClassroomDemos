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

        //Properties can be fully implemented. They don't have parameters:
        // - a private data member
        // - a public property
        private int _Sides;
        public int Sides
        {
            get
            {
                //This will return the private data member
                return _Sides;
            }
            set
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

        public int FaceValue { get; set; }
    }
}
