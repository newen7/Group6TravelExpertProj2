using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ------------------------------------------------------------------
// Jon's Supplier Entity class
// Student name: Jonathan Love
// Student ID: 000655580
// Description of code: An entity class which only gets and sets 
// values needed in the GUI and DB layers.  Paul created a supplier
// class like this too but I wanted to use my own.  I believe his has
// an overridden ToString() method.  Mine doesn't.  Just values,
// properties and a constructor with two parameters
// ------------------------------------------------------------------
namespace TravelExperts.Jon
{
    public class Supplier 
    {
        // private variables(some call them fields or values)
        private int supplierId;
        private string supName;

        // constructor
        public Supplier(int Id, string Name)
        {
            supplierId = Id;
            supName = Name;
        }

        // public properties
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
        // boring but it does what I need it to :)
    }
}
