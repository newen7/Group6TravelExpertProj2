// To --> Jon / Paul / Porkodi, I created cause I needed for my Package Class
// I just copied from our final Workshop project.
// You can erase it if you have your part ready! :)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExperts
{
    class Product //allows encapsulation of all the properties accociated with the 'Products'
    {//Paul Teixiera
        private int productId;
        private string prodName;
        private string supplierName; //by design i added the name and Id of the supplier, so the product object knows who supplies them to the package
        private int productSupplierId;
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
        public override string ToString()
        {
            return supplierName + " " + prodName;
        }
    }
}
