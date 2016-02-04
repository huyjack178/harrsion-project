using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetList.Core
{
    public interface IRender
    {
        object Render(IElement element);
    }
}
