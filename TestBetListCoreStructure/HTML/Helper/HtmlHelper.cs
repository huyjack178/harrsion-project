namespace HTML
{
    using System.IO;
    using System.Web.UI;

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