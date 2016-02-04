using BetList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product
{
    class ChoiceBuilder
    {
        public string RenderHtml(IElement choiceElement, IRender htmlRender)
        {
            htmlRender = new HtmlRender();

            return htmlRender.Render(choiceElement).ToString();
        }


    }
}
