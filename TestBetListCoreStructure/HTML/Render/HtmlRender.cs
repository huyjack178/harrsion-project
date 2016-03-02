namespace HTML.Render
{
    using BetList.Core.Entity;
    using BetList.Core.Render;
    using Helper;
    using System.Web.UI;

    public class HtmlRender : IRender
    {
        private IHtmlHelper _htmlHelper = null;

        public HtmlRender()
        {
            _htmlHelper = new HtmlHelper();
        }

        public object Render(IElement element)
        {
            RenderAttribute(element);

            RenderBeginTag(element);

            RenderStyle(element);

            RenderText(element);

            RenderChildren(element);

            RenderEndTag();

            return _htmlHelper.GetHtmlString();
        }

        private void RenderAttribute(IElement element)
        {
            ////Render class attribute
            _htmlHelper.AddAtribute(HtmlTextWriterAttribute.Class.ToString(), element.Name);
        }

        private void RenderBeginTag(IElement element)
        {
            if (element.IsBlock)
            {
                _htmlHelper.BeginTag(HtmlTextWriterTag.Div.ToString());
            }
            else
            {
                _htmlHelper.BeginTag(HtmlTextWriterTag.Span.ToString());
            }
        }

        private void RenderStyle(IElement element)
        {
            foreach (var style in element.Formats)
            {
                _htmlHelper.AddStyle(style.Key, style.Value);
            }
        }

        private void RenderText(IElement element)
        {
            _htmlHelper.AddText(element.Text);
        }

        private void RenderChildren(IElement element)
        {
            if (element.Children.Count == 0)
            {
                return;
            }

            foreach (IElement child in element.Children)
            {
                Render(child);
            }
        }

        private void RenderEndTag()
        {
            _htmlHelper.EndTag();
        }
    }
}