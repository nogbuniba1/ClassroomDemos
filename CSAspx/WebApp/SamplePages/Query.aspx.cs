
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


#region Additional Namespaces
using NorthwindSystem.BLL;
using Northwind.Data.Entities;
// use Manage NuGet Packages to add EntityFramework
// add the reference assembly System.Data.Entity
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core;
using Nortthwind.Data.Entities;
#endregion

namespace WebApp.SamplePages
{
    public partial class Query : System.Web.UI.Page
    {
        List<string> errormsgs = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Message.DataSource = null;
            Message.DataBind();
            if (!Page.IsPostBack)
            {
                BindProductList();
                //TODO: Code the methods for these calls
                BindSupplierList();
                BindCategoryList();
            }
        }

        public void BindProductList()
        {
            try
            {
                ProductController sysmgr = new ProductController();
                List<Product> info = sysmgr.Products_List();
                info.Sort((x, y) => x.ProductName.CompareTo(y.ProductName));
                ProductList.DataSource = info;
                ProductList.DataTextField = nameof(Product.ProductName);
                ProductList.DataValueField = nameof(Product.ProductID);
                ProductList.DataBind();
                ProductList.Items.Insert(0, "select ...");
            }
            catch(Exception ex)
            {
                errormsgs.Add("File Error: " + GetInnerException(ex).Message);
                LoadMessageDisplay(errormsgs, "alert alert-warning");
            }
        }

        public void BindSupplierList()
        {
            //TODO: code the method to load the SupplierList control
            try
            {
                SupplierController sysmgr = new SupplierController();
                List<Supplier> info = sysmgr.Suppliers_List();
                info.Sort((x, y) => x.CompanyName.CompareTo(y.CompanyName));
                SupplierList.DataSource = info;
                SupplierList.DataTextField = nameof(Supplier.CompanyName);
                SupplierList.DataValueField = nameof(Supplier.SupplierID);
                SupplierList.DataBind();
                SupplierList.Items.Insert(0, "select ...");
            }
            catch (Exception ex)
            {
                errormsgs.Add("File Error: " + GetInnerException(ex).Message);
                LoadMessageDisplay(errormsgs, "alert alert-warning");
            }
        }

        public void BindCategoryList()
        {
            //TODO: code the method to load the CategoryList control
            try
            {
                CategoryController sysmgr = new CategoryController();
                List<Category> info = sysmgr.Categories_List();
                info.Sort((x, y) => x.CategoryName.CompareTo(y.CategoryName));
                CategoryList.DataSource = info;
                CategoryList.DataTextField = nameof(Category.CategoryName);
                CategoryList.DataValueField = nameof(Category.CategoryID);
                CategoryList.DataBind();
                CategoryList.Items.Insert(0, "select ...");
            }
            catch (Exception ex)
            {
                errormsgs.Add("File Error: " + GetInnerException(ex).Message);
                LoadMessageDisplay(errormsgs, "alert alert-warning");
            }
        }

        //use this method to discover the inner most error message.
        //this routine  has been created by the user
        protected Exception GetInnerException(Exception ex)
        {
            //drill down to the inner most exception
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }
        //use this method to load a DataList with a variable
        //number of message lines.
        //each line is a string
        //the strings (lines) are passed to this routine in
        //   a List<string>
        //second parameter is the bootstrap cssclass
        protected void LoadMessageDisplay(List<string> errormsglist, string cssclass)
        {
            Message.CssClass = cssclass;
            Message.DataSource = errormsglist;
            Message.DataBind();
        }

        protected void SearchProduct_Click(object sender, EventArgs e)
        {
            //TODO: code this method to lookup and display the selected product

            //Do you have something to search for?
            //The dropdownlist has a prompt lin in index 0
            if(ProductList.SelectedIndex == 0)
            {
                errormsgs.Add("Select a product to fetch!");
                LoadMessageDisplay(errormsgs, "alert alert-warning");
            }
            else
            {
                //If you are leaving the web project to access code within another project, you should use user-friendly error handling.
                try
                {
                    //To use an object, create an instance of that object
                    ProductController sysmgr = new ProductController();

                    //Call the appropriate method within your instance
                    Product info = sysmgr.Products_GetProduct(int.Parse(ProductList.SelectedValue));

                    //Check that product was found.
                    //Single record data is checked against null
                    //multi-record data is chaecked against count

                    if(info == null)
                    {
                        //The product was not found
                        //Display message to the user
                        //Refresh the incorrect dropdownlist to reflect the accurate current product list
                        errormsgs.Add("Product was not found. Select and try again!");
                        LoadMessageDisplay(errormsgs, "alert alert-warning");
                        BindProductList();

                        //Optionally, you could empty the product data fields
                        ProductID.Text = "";
                        ProductName.Text = "";
                    }
                    else
                    {
                        //Product was found - Display
                        ProductID.Text = info.ProductID.ToString();
                        ProductName.Text = info.ProductName;
                        SupplierList.SelectedValue = info.SupplierID == null ? "select ..." : info.SupplierID.ToString();
                        CategoryList.SelectedValue = info.CategoryID == null ? "select ..." : info.CategoryID.ToString();
                        QuantityPerUnit.Text = info.QuantityPerUnit == null ? "" : info.QuantityPerUnit;
                        UnitPrice.Text = info.UnitPrice == null ? "" : string.Format("{0:0.00}",info.UnitPrice);
                        UnitsInStock.Text = info.UnitsInStock == null ? "" : info.UnitsInStock.ToString();
                        UnitsOnOrder.Text = info.UnitsOnOrder == null ? "" : info.UnitsOnOrder.ToString();
                        ReorderLevel.Text = info.ReorderLevel == null ? "" : info.ReorderLevel.ToString();
                        Discontinued.Checked = info.Discontinued;

                    }
                }
                catch (Exception ex)
                {
                    errormsgs.Add("File Error: " + GetInnerException(ex).Message);
                    LoadMessageDisplay(errormsgs, "alert alert-warning");
                }
            }
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            ProductList.ClearSelection();
            ProductID.Text = "";
            ProductName.Text = "";
            SupplierList.ClearSelection();  //This will reset to prompt line
            CategoryList.SelectedIndex = -1; //This will also reset to prompt line. YOu can use any one of the 2
            QuantityPerUnit.Text = "";
            UnitPrice.Text = "";
            UnitsInStock.Text = "";
            UnitsOnOrder.Text = "";
            ReorderLevel.Text = "";
            Discontinued.Checked = false;
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            //Re-execute form validation
            if(Page.IsValid)
            {
                //Other validation such as ensuring that selection has been made on our dropdown list
                //For this example, we'll assume that supplier ID and Category ID are required

                if(SupplierList.SelectedIndex == 0)
                {
                    errormsgs.Add("Supplier was not selected");
                    LoadMessageDisplay(errormsgs, "alert alert-warning");
                }
                else if(CategoryList.SelectedIndex == 0)
                {
                    errormsgs.Add("Category was not selected");
                    LoadMessageDisplay(errormsgs, "alert alert-warning");
                }
                else
                {
                    try
                    {
                        //Create a new instance of the entity to be added
                        Product newProduct = new Product();

                        //Extract the webdata and load your new instance
                        newProduct.ProductName = ProductName.Text;
                        newProduct.SupplierID = int.Parse(SupplierList.SelectedValue);
                        newProduct.CategoryID = int.Parse(CategoryList.SelectedValue);
                        newProduct.QuantityPerUnit = QuantityPerUnit.Text == null ? null: QuantityPerUnit.Text;
                        if(string.IsNullOrEmpty(UnitPrice.Text))
                        {
                            newProduct.UnitPrice = null;
                        }
                        else
                        {
                            newProduct.UnitPrice = decimal.Parse(UnitPrice.Text);
                        }

                        if (string.IsNullOrEmpty(UnitsInStock.Text))
                        {
                            newProduct.UnitsInStock = null;
                        }
                        else
                        {
                            newProduct.UnitsInStock = Int16.Parse(UnitsInStock.Text);
                        }

                        if (string.IsNullOrEmpty(UnitsOnOrder.Text))
                        {
                            newProduct.UnitsOnOrder = null;
                        }
                        else
                        {
                            newProduct.UnitsOnOrder = Int16.Parse(UnitsOnOrder.Text);
                        }

                        if (string.IsNullOrEmpty(ReorderLevel.Text))
                        {
                            newProduct.ReorderLevel = null;
                        }
                        else
                        {
                            newProduct.ReorderLevel = Int16.Parse(ReorderLevel.Text);
                        }

                        //For discontinued, logically one would assume, you would not add a discontinued product to your list.
                            //Therefore, this field will logically be false on the add.
                            //newProduct.Discontinued = false; 
                        newProduct.Discontinued = Discontinued.Checked;
                        //connect to the system (BLL)
                        //Issue your call and check results
                        ProductController sysmgr = new ProductController();
                        int newproductid = sysmgr.Products_Add(newProduct);

                        ProductID.Text = newproductid.ToString();

                        //refresh the product list to show the new product in the list
                        BindProductList();

                        //Point to the new product in the list
                        ProductList.SelectedValue = ProductID.Text;

                        //Communicate to the user
                        errormsgs.Add("Product has been added");
                        LoadMessageDisplay(errormsgs, "alert alert-success");
                    }
                    catch (DbUpdateException ex)
                    {
                        UpdateException updateException = (UpdateException)ex.InnerException;
                        if (updateException.InnerException != null)
                        {
                            errormsgs.Add(updateException.InnerException.Message.ToString());
                        }
                        else
                        {
                            errormsgs.Add(updateException.Message);
                        }
                        LoadMessageDisplay(errormsgs, "alert alert-danger");
                    }
                    catch (DbEntityValidationException ex)
                    {
                        foreach (var entityValidationErrors in ex.EntityValidationErrors)
                        {
                            foreach (var validationError in entityValidationErrors.ValidationErrors)
                            {
                                errormsgs.Add(validationError.ErrorMessage);
                            }
                        }
                        LoadMessageDisplay(errormsgs, "alert alert-danger");
                    }
                    catch (Exception ex)
                    {
                        errormsgs.Add(GetInnerException(ex).ToString());
                        LoadMessageDisplay(errormsgs, "alert alert-danger");
                    }

                }
            }
        }

        protected void Update_Click(object sender, EventArgs e)
        {

        }

        protected void Delete_Click(object sender, EventArgs e)
        {

        }
    }
}