//Author:Prokodi
//Created Date: Jan-29-2014
// Call data model class

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExperts_Porkodi
{
   public class Product
    {
       private int productId;
       private string prodName;

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
}
}

 
