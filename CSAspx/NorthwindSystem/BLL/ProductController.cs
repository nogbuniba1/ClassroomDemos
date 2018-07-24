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

        //This method will add a new product to the SQL product table. This method will do the add via entity framework
        //Optionally, one can pass back the new identity value from the successful add
        public int Products_Add(Product newproduct)
        {
            //Start the insert transaction
            using (var context = new NorthwindContext())
            {
                //First stage: Staging
                    //Stage the new record to DbSet<T> for the object instance
                    //At this time, the record IS NOT physically on the database
                context.Products.Add(newproduct);

                //Second stage: Commit the record to the Database
                //Any entity validation is done at this time.
                //If this statement is not executed, the insert IS NOT completed (A rollbaack)
                //If this statement is executed but fails for some reason, the insert IS NOT completed (A rollback)
                //If this statement is executed and is successful, then the insert has physically placed the record on the database. At this time, you can retrieve the new identity value
                context.SaveChanges();

                //After the success of the saved changes, you can access your instance for the new Identity value
                return newproduct.ProductID;
            } 
        }

        //This method updates the database. This method returns the number of records affected on the database
        public int Product_Update(Product updateproduct)
        {
            //Start transaction
            using (var context = new NorthwindContext())
            {
                //Stage
                context.Entry(updateproduct).State = System.Data.Entity.EntityState.Modified;

                //Commit
                return context.SaveChanges();
            }

        }

        //This product deletes any record from the database / This method logically flags a method to be deemed deleted from the database
        public int Product_Delete(int productid)
        {
            //Start transaction
            using (var context = new NorthwindContext())
            {
                ////Physical Delete
                //var existing = context.Products.Find(productid);
                //    //Stage
                //    context.Products.Remove(existing);
                //    //Commit
                //    return context.SaveChanges();


                //Logical Delete - this is an update
                var existing = context.Products.Find(productid);
                //Alter the data value on the record that would logically deem the record deleted
                // You should NOT rely on the user to do this alteration on the web form

                existing.Discontinued = true;

                //Stage
                context.Entry(existing).State = System.Data.Entity.EntityState.Modified;

                //Commit
                return context.SaveChanges();

            }

        }
    }
}
