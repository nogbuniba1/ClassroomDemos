using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel.DataAnnotations.Schema; //added this for the [Table()]
using System.ComponentModel.DataAnnotations;

#endregion


namespace Northwind.Data.Entities
{
    //the Table annotation points to the table in the SQL DB that this class defines
    [Table("Products")]
    public class Product
    {
        //create a property for each attribute on the SQL table
        //use C# datatypes for the SQL attributes
        //Rules:
        // a) If you use the attribute name as your property name, the order of properties is not important
        // b) If you do NOT use the attribute name as your property name, the order of properties must match the order of attributes
        // c) Foreign Keys do NOT need an annotation if the property name is the same as the attribute name
        // d) Primary Keys are by default treated as IDENTITY. If your PK is not an IDENTITY then you must add 
        //    .DataGenerated(DataGeneratedOption.xxxx) annotation parameter
        // e) Primary key properties are best defaulted to end in ID (Id)
        // f) Compound PK are described using the Column(Order=n) annotation parameter; where n is 1, 2, 3, etc. (physical order of SQL attributes)

        //Validation can be done on your individual property of your entity 

        [Key] // or [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Product Name is required")]
        [StringLength(40, ErrorMessage = "Product Name is limited to 40 characters")]
        public string ProductName { get; set; }

        public int? SupplierID { get; set; } // foreign key,    ? does mean nullable (null)
        public int? CategoryID { get; set; } // foreign key

        [StringLength(20, ErrorMessage = "Quantity per Unit is limited to 20 characters")]
        public string QuantityPerUnit { get; set; }

        [Range(0.0, double.MaxValue, ErrorMessage = "Invalid Price")]
        public decimal? UnitPrice { get; set; }

        [Range(0.0, double.MaxValue, ErrorMessage = "Invalid Units in Stock")]
        public Int16? UnitsInStock { get; set; }

        [Range(0.0, double.MaxValue, ErrorMessage = "Invalid units on order")]
        public Int16? UnitsOnOrder { get; set; }

        [Range(0.0, double.MaxValue, ErrorMessage = "Invalid reorder level")]
        public Int16? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

        // sometimes you will want another property in your class that will return a not attribute value to the user
        // example: Name, which could be created by the first and last name properties
        // to create these non mapped (non existing SQL attributes) properties, use the annotation [NotMapped]

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
