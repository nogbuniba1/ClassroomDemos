using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class BasicControls : System.Web.UI.Page
    {
        public static List<DDLClass> DataCollection;

        protected void Page_Load(object sender, EventArgs e)
        {
            //This method will execute on each and every Postback to this page. 
            //This menthod will execute on the first display of this page
            //To determine if the page is new or postback, use PostBack Property.
            //This method is often used as a general method to reset fields or controls at the start of the page processing.
            //E.g. The label MessageLabel is used to display messages to the user. Old messages should be removed from this control on each pass

            // How does one reference a control on the .aspx form?
            //To reference a form control, use the control ID name
            //EACH CONTROL IS AN OBJECT. Therefore, ALTER A PROPERTY VALUE
            MessageLabel.Text = "";

            //Determine if this is the first display of the page, and if so, load data into the dropdownlist
            if(!Page.IsPostBack)
            {
                //Create an instance of List<T> for my "Fake Database Data"
                DataCollection = new List<DDLClass>();

                //Add data to the collection, one entry at a time
                DataCollection.Add(new DDLClass(1, "COMP1008"));
                DataCollection.Add(new DDLClass(2, "DMIT1508"));
                DataCollection.Add(new DDLClass(3, "CPSC1517"));
                DataCollection.Add(new DDLClass(4, "DMIT2018"));

                //usually lists are sorted
                //The List<T> has a .Sort() behavior (method)
                //(x,y) represent any two entries in the data collection at any point in time
                //The landa symbol "=>" :  basically means do the following
                //.CompareTo() : is a method that would compare 2 items and return the result of the comparison. 
                        //The result is interpreted by the Sort() to determine if the order needs to be changed.
                // x vs y is ascending
                // y vs x is descending

                DataCollection.Sort((x, y) => x.DisplayField.CompareTo(y.DisplayField));

                //Place the collection into the dropdown list
                //a) assign the collection to the control (CollectionList)
                CollectionList.DataSource = DataCollection;

                //b) assign the value and display portions of the dropdownlist to specific properties of the data class
                CollectionList.DataTextField = nameof(DDLClass.DisplayField);
                CollectionList.DataValueField = nameof(DDLClass.ValueField);

                //c) Bind the data to the collection (physical attachment)
                CollectionList.DataBind();

                //d) you may wish to add a prompt line at the beginning of the list of data within the dropdownlist
                CollectionList.Items.Insert(0, "Select...");
            }
        }

        protected void SubmitButtonChoice_Click(object sender, EventArgs e)
        {
            //Grab the content of various controls and manipulate the content of other controls
            //Controls have certain properties that can be access for obtaining and assigning values

            //Textbox property: Text
            string submitchoice = TextBoxNumberChoice.Text; //if the property is on the right of an equla sign , we are using the GET and vice versa will be the SET

            if(string.IsNullOrEmpty(submitchoice))
            {
                MessageLabel.Text = "This field can not be blank! Enter a number between 1 and 4.";
            }
            else
            {
                //RadioButtonList Property: SelectedIndex, SelectedValue and SelectedItem
                //SelectedIndex: returns the physical line index number
                //*** SelectedValue: returns the data value associated with the physical line ***  --USED Most TImes
                //SelectedItem: returns the data display(text) associated with the physical line
                RadioButtonListChoice.SelectedValue = submitchoice;
            }
        }

        protected void LinkButtonSubmitChoice_Click(object sender, EventArgs e)
        {
            MessageLabel.Text = "You pressed the Submit Choice Link Button! ";
        }
    }
}