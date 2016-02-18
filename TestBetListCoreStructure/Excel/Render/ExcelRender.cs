using System;
using BetList.Core.Entity;
using BetList.Core.Render;
using Excel.Helper;
using NPOI.SS.UserModel;
using NPOI.HSSF.Util;
using NPOI.HSSF.UserModel;
using System.Drawing;

namespace Excel.Render
{
    public class ExcelRender : IRender
    {
        private RTFHelper _rtfHelper;

        public ExcelRender(object excelHelper)
        {
            _rtfHelper = (RTFHelper)excelHelper;
        }

        public object Render(IElement element)
        {
            _rtfHelper.MakeColor();
            if (!string.IsNullOrEmpty(element.Text))
            {
                IFont format = _rtfHelper.NormalFont;
                format.Color = 100;
                _rtfHelper.RTFRenderer.AddText(element.Text + "\n", format);
                
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
