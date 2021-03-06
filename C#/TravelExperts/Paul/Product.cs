﻿/*Paul Teixiera
 * Product class allows encapsulation of product properties passed from gui to db and back again
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExperts
{
    public class Product //allows encapsulation of all the properties accociated with the 'Products'
    {//Paul Teixiera
        private int productId;
        private string prodName;
        private string supplierName; //by design i added the name and Id of the supplier, so the product object knows who supplies them to the package
        private int productSupplierId;
        public Product(int newproductId, string newprodName)
        {
            productId = newproductId;
            prodName = newprodName;
        }
        public Product(int newproductId, string newprodName, string newsupplierName, int newProductSupplierId)
        { //constructor fills all pedigree information in
            productId = newproductId;
            prodName = newprodName;
            supplierName = newsupplierName;
            productSupplierId = newProductSupplierId;
        }
        //gets and sets of public properties allow access after construction, but only through safe channels 
        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }
        public string ProdName
        {
            get { return prodName; }
            set { prodName = value; }
        }
        public string SupplierName
        {
            get { return supplierName; }
            set { supplierName = value; }
        }
        public int ProductSupplierId
        {
            get { return productSupplierId; }
            set { productSupplierId = value; }
        }
        public string JustNames()
        {
            return prodName;
        }
        public override string ToString()
        {
            if (supplierName != null) return prodName + " --- " + supplierName; //i grudgenly accept your silly thing
            else return prodName;
        }
        public override bool Equals(object obj) //run by listbox.contains to check if it exists this overides the REFERENCE checking with name checking (Because normally this function compares the reference of two objects, even though the same product has the same internal information, the differnet references of two simlar products say they are DIFFERENT objects (which is valid but not what i need), i override to say that if the ToString is the same, then the objects are the same)
        {
            if (obj != System.DBNull.Value) //check if its not null ofcourse
            {
                return ((Product)obj).ToString() == this.ToString();//cast it to product and compare ToStrings of this product and perameters prodcut
            }
            else return false;
        }
    }
}
