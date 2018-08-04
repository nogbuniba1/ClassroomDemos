using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Northwind.Data.Entities;
using NorthwindSystem.DAL;
using System.ComponentModel; //Used to expose the class and methods for ODS
#endregion

namespace NorthwindSystem.BLL
{
    [DataObject]
    public class CategoryController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)] //There can only be one type can be a default (i.e be true)
        public List<Category> Categories_List()
        {
            //need to connect to the Context class
            //this connection will be done in a transaction coding group
            using (var context = new NorthwindContext())
            {
                //via EnityFrame, make a request for all records,
                //all attributes from the specified DbSet property
                return context.Categories.ToList();
            }
        }

        //this method will return a specific record from the sql Category table based on the Primary Key
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Category Categories_GetCategory(int categoryId)
        {
            using (var context = new NorthwindContext())
            {
                return context.Categories.Find(categoryId);
            }
        }


    }
}
