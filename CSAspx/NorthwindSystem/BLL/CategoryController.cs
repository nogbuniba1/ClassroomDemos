
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespace
using Northwind.Data.Entities;
using NorthwindSystem.DAL;
#endregion

namespace NorthwindSystem.BLL
{
    public class CategoryController
    { 
            //this method will return all records from the SQL table "Categories".
            //This method will first create a transaction code block which uses the DAL context class.
            //The context class has a DbSet<Category> property for referencing the SQL table
            //The property works with EntityFramework ti retrieve the data
            public List<Category> Category_List()
            {
                using (var context = new NorthwindContext())
                {
                    return context.Categories.ToList();
                }
            }

            //this method will return a specific record from the sql Category table based on the Primary Key
            public Category Categories_GetCategory(int categoryId)
            {
                using (var context = new NorthwindContext())
                {
                    return context.Categories.Find(categoryId);
                }
            }
        
    }
}
