namespace HTML.Helper
{
    using System;
    using System.IO;
    using System.Web.UI;

    public class HtmlHelper : IHtmlHelper
    {
        private StringWriter _stringWriter;
        private HtmlTextWriter _htmlWriter;

        public HtmlHelper()
        {
            _stringWriter = new StringWriter();
            _htmlWriter = new HtmlTextWriter(_stringWriter);
        }

        public string GetHtmlString()
        {
            return _stringWriter.ToString();
        }

        public void AddAtribute(string name, string value)
        {
            _htmlWriter.AddAttribute(name, value);
        }

        public void AddStyle(string name, string value)
        {
            _htmlWriter.AddStyleAttribute(name, value);
        }

        public void AddText(string text)
        {
            _htmlWriter.Write(text);
        }

        public void BeginTag(string tag)
        {
            _htmlWriter.RenderBeginTag(tag);
        }

        public void EndTag()
        {
            _htmlWriter.RenderEndTag();
        }
    }
}