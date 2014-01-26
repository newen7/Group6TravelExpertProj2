using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExperts.Jon
{
    public class Supplier 
    {
        private int supplierId;
        private string supName;

        public Supplier(int Id, string Name)
        {
            supplierId = Id;
            supName = Name;
        }
        public int SupplierId
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
    }
}
