using System;
using System.Collections.Generic;

using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Northwind.Data.Entities;
using Northwind.Data.Views;
using NorthwindSystem.DAL;
using System.ComponentModel;
#endregion 

namespace NorthwindSystem.BLL
{
    [DataObject]
    public class SupplierController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Supplier> Suppliers_List()
        {
            //need to connect to the Context class
            //this connection will be done in a transaction coding group
            using (var context = new NorthwindContext())
            {
                //via EnityFrame, make a request for all records,
                //all attributes from the specified DbSet property
                return context.Suppliers.ToList();
            }
        }

        
        public List<SupplierCategories> Suppliers_GetCategories(int suppilerid)
        {
            using (var context = new NorthwindContext())
            {
                IEnumerable<SupplierCategories> results =
                    context.Database.SqlQuery<SupplierCategories>("Suppliers_GetCategories @SupplierID",
                                    new SqlParameter("SupplierID", suppilerid));
                return results.ToList();
            }
        }

        
        public Supplier Suppliers_GetSupplier(int supplierid)
        {
            using (var context = new NorthwindContext())
            {
                return context.Suppliers.Find(supplierid);
            }
        }


        public List<Supplier> Suppliers_GetByPartialCompanyName(string partialname)
        {
            using (var context = new NorthwindContext())
            {
                IEnumerable<Supplier> results =
                           context.Database.SqlQuery<Supplier>("Suppliers_GetByPartialCompanyName @PartialName",
                                           new SqlParameter("PartialName", partialname));
                return results.ToList();
            }
        }
    }
}
