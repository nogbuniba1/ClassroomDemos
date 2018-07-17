using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.Data.Entity;
using Nortthwind.Data.Entities;
using Northwind.Data.Entities;
#endregion

namespace NorthwindSystem.DAL
{
    //To add a little security to the database access, we will set the access privilege of this class to internal
    //This access restricts calls to this class from within this project only
    //This class will be created by any BLL controller class method

    //This class will interact with the entity framework software to access the database
    //To set-up this interaction, this class will inherit from EntityFramework its DdContext Class

    internal class NorthwindContext:DbContext
    {
        //We need to pass the database connection to the entity framework DBContext class via the :base("xxx") parameter. 
        //This is done via the NorthwindContext constructor

        public NorthwindContext():base("NWDB")
        {

        }

        //Indicate the property in this context class that will connect the sql table to the data definition class.
        //This is done by using the Dbcontext - EntityFramework datatype - DbSet<T>
        //  where <T> is the data definition class
        public DbSet<Product> Products { get; set; }    //Product defines an entity while Products is a property
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
    }
}
