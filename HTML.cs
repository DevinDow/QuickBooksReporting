using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace QuickBooksReporting
{
    class HTML : HtmlTextWriter
    {
        // Constructor
        public HTML(StreamWriter streamWriter) : base(streamWriter)
        { }


        // Methods
        public void WriteHeading(HtmlTextWriterTag tag, string text)
        {
            RenderBeginTag(tag);
            WriteLine(text);
            RenderEndTag();
            WriteLine();
        }
    }
}
