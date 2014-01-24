using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExperts
{
    public class Supplier //allows encapsulation of supplier info, really its only the id and name, but it allows very verbose use of this info
    {//Paul Teixeira 653708
        private int supplierId;
        private string supName;
        
        public Supplier(int newId, string Name) //this time i put the list into the consructor, because the normal use of this object is AFTER you get the products of the id
        {
            supplierId = newId;
            supName = Name;
        }
        public int SuplierId
        {
            get
            {
                return supplierId;
            }
            set
            {
                supplierId = value;
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
