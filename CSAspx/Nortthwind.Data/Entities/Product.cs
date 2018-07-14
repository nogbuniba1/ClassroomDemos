using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion

namespace Nortthwind.Data.Entities
{
    //The Table annotation points to the table in the sql database that this class defines
    [Table("Products")]

    public class Product
    {
        //Create a property for each attributes on the sql table.
        //Use C# datatypes for the sql attributes

            //RULES
        //a) If you use the attribute name as your property name, the order of properties is not important
        //b) If you don't use the attribute name as your property name, the order of properties must match the order of attributes.
        //c) Foreign keys(FK) do NOT need an annotation if the property name is the same as the attribute name
        //d) Primary keys (PK) by default are treated as identity. If your PK is not an identity, 
        //then you must add a .DataGenerated(DatataGeneratedOption.xxx)annotation parameter.
        //e) PK properties are best defaulted to end in ID (Id)
        //f) Compound PKs are described using the Column(Order=n) annotation parameter where n = 1,2,3,4 etc (Physical order of SQL attributes)

        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductID {get; set;}
        public string ProductName { get; set; }
        public int? SupplierID { get; set; } //Foreign Key 
        public int? CategoryID { get; set; } //Foreign Key / "?" - means it is nullable field
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public Int16? UnitInStock { get; set; }
        public Int16? UnitOnOrder { get; set; }
        public Int16? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

        //Sometimes, you will want another property in your class that will return a non-attribute value to the user
        //Example; Name -which could be created by the First and Last name properties
            //To Create these non mapped (non-existing sql attributes) properties, use the annotation [NotMApped]

        [NotMapped]
        public string ProductIDName
        {
            get
            {
                return ProductName + " (" + ProductID.ToString() + ")";
            }
        }
    }
}
