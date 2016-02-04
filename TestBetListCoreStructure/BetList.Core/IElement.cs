using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetList.Core
{
    public interface IElement
    {
        string Text { get; set; }
        Dictionary<string, IElement> Children { get; set; }

        void Initialize();

        void AddChildren(IElement element);
    }
}
