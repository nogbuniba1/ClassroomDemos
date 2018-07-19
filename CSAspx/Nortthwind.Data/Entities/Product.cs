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


    //Validation can be done on your individual property of your entity

        [Key]
        public int ProductID {get; set;}

        [Required(ErrorMessage = "Product name is required")]
        [StringLength(40, ErrorMessage ="Product name is limited to 40 Characters")]
        public string ProductName { get; set; }
        public int? SupplierID { get; set; } //Foreign Key 
        public int? CategoryID { get; set; } //Foreign Key / "?" - means it is nullable field

        [StringLength(20, ErrorMessage = "Quantity per unit is limited to 20 characters")]
        public string QuantityPerUnit { get; set; }

        [Range(0.00,double.MaxValue,ErrorMessage ="Invalid Price")]
        public decimal? UnitPrice { get; set; }

        [Range(0.0, double.MaxValue, ErrorMessage ="Invalid Unit in Stock")]
        public Int16? UnitsInStock { get; set; }

        [Range(0.0, double.MaxValue, ErrorMessage = "Invalid Unit on Order")]
        public Int16? UnitsOnOrder { get; set; }

        [Range(0.0, double.MaxValue, ErrorMessage = "Invalid ReOrder Level")]
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
