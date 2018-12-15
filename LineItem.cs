using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBooksReporting
{
    class LineItem
    {
        // Public Fields
        public string type;
        public DateTime date;
        public string name;
        public string item;
        public int quantity;
        public decimal price;


        // Constructor
        public LineItem(string[] fields)
        {
            type = fields[1].Trim('\"');
            DateTime.TryParse(fields[2].Trim('\"'), out date);
            name = fields[5].Trim('\"');
            item = fields[6].Trim('\"');
            int.TryParse(fields[7], out quantity);
            decimal.TryParse(fields[8], out price);
        }


        // Overrides
        public override string ToString()
        {
            return String.Format("{0} to \"{2}\" on {1}: {4} of \"{3}\" @ ${5}", type, date.ToShortDateString(), name, item, quantity, price);
        }
    }
}
