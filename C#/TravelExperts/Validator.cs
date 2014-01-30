// ------------------------------------------------------------------
// Pitsini Suwandechochai
// validator for Serch, Add, Modify and Delete Package 
// ------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace TravelExperts
{
    public class Validator
    {
        // The title that will appear in dialog boxes.
        private static string title = "Entry Error";    
        
        public static string Title
        {
            get { return title; }
            set { title = value; }
        }

        // Checks whether the user entered data into a text box.
        public static bool IsPresent(Control control, string str)
        {
            if (control.GetType().ToString() == "System.Windows.Forms.TextBox")
            {
                TextBox textBox = (TextBox)control;
                if (textBox.Text == "")
                {
                    MessageBox.Show(str + " is a required field.", Title);
                    textBox.Focus();
                    return false;
                }
                return true;
            }

            // Checks whether the user entered data into a ComboBox.
            else if (control.GetType().ToString() == "System.Windows.Forms.ComboBox")
            {
                ComboBox comboBox = (ComboBox)control;
                if (comboBox.SelectedIndex == -1)
                {
                    MessageBox.Show(str + " is a required field.", Title);
                    comboBox.Focus();
                    return false;
                }                
            }
            return true;
        }

        // validate name (letter, whitespace and - only)
        public static bool IsLetter(TextBox textBox, string name)
        {
            foreach (char c in textBox.Text)
            {
                if (!Char.IsLetter(c) && !Char.IsWhiteSpace(c) && !(c == '-')) // only letter or white space
                {
                    MessageBox.Show(name + " must be letters only.", Title);
                    textBox.Focus();
                    textBox.SelectAll();
                    return false;
                }
            }
            return true;
        }

        // validate integer
        public static bool IsInt32(TextBox textBox, string name)
        {
            int number = 0;
            if (Int32.TryParse(textBox.Text, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(name + " must be an integer.", "Entry Error");
                textBox.Focus();
                textBox.SelectAll();
                return false;
            }
        }

        // validate positive number only
        public static bool IsPosNum(TextBox textBox, string name)
        {
            decimal number;
            if (textBox.Text != "")
            {
                if (decimal.TryParse(textBox.Text, NumberStyles.Currency, CultureInfo.CurrentCulture.NumberFormat, out number))
                {
                    if (number > 0)
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show(name + " must be a positive number.", "Entry Error");
                        textBox.Focus();
                        textBox.SelectAll();
                        return false;
                    }
                }
                MessageBox.Show(name + " must be a number.", "Entry Error");
                textBox.Focus();
                textBox.SelectAll();
                return false;
            }
            else
            {
                MessageBox.Show(name + " must be a number.", "Entry Error");
                textBox.Focus();
                textBox.SelectAll();
                return false;
            }
        }

        // validate decimal
        public static bool IsDecimal(TextBox textBox)
        {
            try
            {
                decimal.Parse(textBox.Text, NumberStyles.Currency, CultureInfo.CurrentCulture.NumberFormat);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(textBox.Tag + " must be a decimal number.", Title);
                textBox.Focus();
                return false;
            }
        }

        // validate decimal have to be between min and max
        public static bool IsWithinRange(TextBox textBox, decimal min, decimal max)
        {
            decimal number = Convert.ToDecimal(textBox.Text);
            if (number < min || number > max)
            {
                MessageBox.Show(textBox.Tag + " must be between " + min.ToString()
                    + " and " + max.ToString() + ".", Title);
                textBox.Focus();
                return false;
            }
            return true;
        }

        // validate decimal have to be between min and max
        public static bool DateIsWithinRange(DateTime sDate, DateTime eDate)
        {
            // compare between dates
            int result = DateTime.Compare(sDate, eDate);
                        
            if (result == 0)    // if they are the same day
            {
                MessageBox.Show("Start date can't be the same as End date.", Title);
                return false;
            }
            else
                if (result > 0) // if sDate greater than eDate
                {
                    MessageBox.Show("End date can't be less than Start date", Title);
                    return false;
                }
            return true;
        }

        // validate decimal have to be between min and max
        public static bool IsGreaterThan(decimal bPrice, decimal cPrice)
        {
            //compare between decimal numbers
            int result = decimal.Compare(bPrice, cPrice);

            // if num1 less than 2
            if (result == 0 || result < 0)
            {
                MessageBox.Show("Base Price cannot be grather than Agency Commission", Title);
                return false;
            }          
            return true;
        }
    }
}
