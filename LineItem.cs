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

        // Data in original Sales CSV
        public string type;
        public DateTime date;
        public string customer;
        public string item;
        public int quantity;
        public decimal price;

        // Data added from CSV of Company Name Mapping
        public string normalizedCustomer;

        public string[] itemMap;


        // Properties
        public decimal Subtotal { get { return price * quantity; } }

        public string CustomerName { get { return normalizedCustomer ?? customer; } }

        public string ItemName { get { return itemMap != null ? itemMap[1] : item; } }
        public string ItemFullName
        {
            get
            {
                if (itemMap == null)
                    return string.Empty;

                StringBuilder sb = new StringBuilder(itemMap[1]);
                for (int i=2; i<itemMap.Length; i++)
                {
                    sb.AppendFormat(" - {0}", itemMap[i]);
                }
                return sb.ToString();
            }
        }


        // Constructor
        public LineItem(string[] fields)
        {
            type = fields[1].Trim('\"');
            DateTime.TryParse(fields[2].Trim('\"'), out date);
            customer = fields[5].Trim('\"');
            item = fields[6].Trim('\"');
            int.TryParse(fields[7], out quantity);
            decimal.TryParse(fields[8], out price);
        }


        // Overrides
        public override string ToString()
        {
            return String.Format("{0} to \"{1}\" on {2}: {3} @ ${4} of \"{5}\"", type, CustomerName, date.ToShortDateString(), quantity, price, ItemFullName);
        }
    }
}
