using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetList.Core
{
    public class Element : IElement
    {
        public Dictionary<string, IElement> Children
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string Text
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public void AddChildren(IElement element)
        {
            throw new NotImplementedException();
        }

        public virtual void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}
