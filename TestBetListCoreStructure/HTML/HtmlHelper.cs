using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace HTML
{
    public class HtmlHelper
    {
        private StringWriter _stringWriter;

        public HtmlTextWriter HtmlWriter { get; set; }


        public HtmlHelper()
        {
            _stringWriter = new StringWriter();
            HtmlWriter = new HtmlTextWriter(_stringWriter);
        }

        public string GetHtmlString()
        {
            return _stringWriter.ToString();
        }
    }
}