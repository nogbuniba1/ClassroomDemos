using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Nortthwind.Data.Entities;
using NorthwindSystem.DAL;
#endregion

namespace NorthwindSystem.BLL
{
    //This is the public interface class that will handle web page service requests for data to the Product SQL table
    //Methods in this class can interact with the internal DAL Context class

    public class ProductController
    {
        //this method will return all records from the SQL table "Products".
        //This method will first create a transaction code block which uses the DAL context class.
        //The context class has a DbSet<Product> property for referencing the SQL table
        //The property works with EntityFramework ti retrieve the data
        public List<Product> Products_List()
        {
            using (var context = new NorthwindContext())
            {
                return context.Products.ToList();
            }
        }

        //this method will return a specific record from the sql products table based on the Primary Key
        public Product Products_GetProduct(int productId)
        {
            using (var context = new NorthwindContext())
            {
                return context.Products.Find(productId);
            }
        }
    }
}
