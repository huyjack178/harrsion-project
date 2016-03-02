using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTML.Helper
{
    public interface IHtmlHelper
    {

        string GetHtmlString();

        void AddAtribute(string name, string value);

        void AddStyle(string name, string value);

        void AddText(string text);

        void BeginTag(string tag);

        void EndTag();
    }
}
