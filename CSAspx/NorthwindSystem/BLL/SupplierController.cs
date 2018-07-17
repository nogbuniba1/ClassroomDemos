
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
    public class SupplierController
    {
        public class ProductController
        {
            //this method will return all records from the SQL table "Suppliers".
            //This method will first create a transaction code block which uses the DAL context class.
            //The context class has a DbSet<Suppliers> property for referencing the SQL table
            //The property works with EntityFramework ti retrieve the data
            public List<Supplier> Supplier_List()
            {
                using (var context = new NorthwindContext())
                {
                    return context.Suppliers.ToList();
                }
            }

            //this method will return a specific record from the sql Suppliers table based on the Primary Key
            public Supplier Suppliers_GetSupplier(int supplierId)
            {
                using (var context = new NorthwindContext())
                {
                    return context.Suppliers.Find(supplierId);
                }
            }
        }
    }
}
