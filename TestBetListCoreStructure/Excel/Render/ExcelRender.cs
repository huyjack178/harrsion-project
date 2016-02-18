using System;
using BetList.Core.Entity;
using BetList.Core.Render;
using Excel.Helper;

namespace Excel.Render
{
    public class ExcelRender : IRender
    {
        private RTFHelper _rtfHelper;

        public ExcelRender()
        {
            _rtfHelper = new RTFHelper().Clone();
        }

        public object Render(IElement element)
        {
            if (!string.IsNullOrEmpty(element.Text))
            {
                _rtfHelper.RTFRenderer.AddText(element.Text);
            }

            RenderChildren(element);

            return _rtfHelper.RTFRenderer.Render();
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
    }
}
