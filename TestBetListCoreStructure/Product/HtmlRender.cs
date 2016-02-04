using BetList.Core;
using HTML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product
{
    class HtmlRender : IRender
    {
        public object Render(IElement element)
        {
            HtmlHelper htmlHelper = new HtmlHelper();
            htmlHelper.HtmlWriter.AddAttribute("class", element.Text);

            return "htmlString";
        }
    }
}
