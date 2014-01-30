/* Paul Teixeira
 * allows encapsulation of supplier info, really its only the id and name, but it allows very verbose use of this info
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExperts
{
    public class Supplier 
    {//Paul Teixeira 653708
        private int ProductSupplierId;
        private string supName;
        
        public Supplier(int newId, string Name)
        {
            ProductSupplierId = newId;
            supName = Name;
        }
        public int SuplierId
        {
            get
            {
                return ProductSupplierId;
            }
            set
            {
                ProductSupplierId = value;
            }
        }
        public string SupName
        {
            get
            {
                return supName;
            }
            set
            {
                supName = value;
            }
        }
        public override string ToString()
        {
            return supName;
        }
    }
}
