using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class ContestEntry : System.Web.UI.Page
    {
        //Since we are not currently using a database, we will collect the contest entries into  a List<T> collection
        //<T> will be the class entry
        //The List<T> will be static to hang around during testing
        public static List<Entry> contestentries = new List<Entry>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Message.Text = "";
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            FirstName.Text = "";
            LastName.Text = "";
            StreetAddress1.Text = "";
            StreetAddress2.Text = "";
            City.Text = "";
            Province.SelectedIndex = 0;
            PostalCode.Text = "";
            EmailAddress.Text = "";
            Terms.Checked = false;
            CheckAnswer.Text = "";
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            //On the server side, you can re-run the validation controls
            if(Page.IsValid)
            {
                string firstname = FirstName.Text;
                string lastname = LastName.Text;
                string streetaddress1 = StreetAddress1.Text;
                string streetaddress2 = StreetAddress2.Text;
                string city = City.Text;
                string province = Province.SelectedValue;
                string postalcode = PostalCode.Text;
                string email = EmailAddress.Text;
                bool terms = Terms.Checked;
                string answer = CheckAnswer.Text;

                //There may be validation that cannot be done using the basic validation controls OR there maybe a need for logic control validation

                if(terms) //Test to show if the checkbox was "checked"
                {
                    //Message.Text = firstname + " " + lastname;

                    //Create an instance of the Entry using the greedy constructor
                    Entry theEntry = new Entry(firstname, lastname, streetaddress1, streetaddress2, city, province, postalcode, email);

                    //Add to the collection of entries
                    contestentries.Add(theEntry);

                    //Atatch the collection of entries to the gridview control
                    ContestEntries.DataSource = contestentries;
                    ContestEntries.DataBind();
                }
                else
                {
                    Message.Text = "You did not agree to the terms of the contest. Entry Denied!";
                }
                
            }
            
        }
    }
}