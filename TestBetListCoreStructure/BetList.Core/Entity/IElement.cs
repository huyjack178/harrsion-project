namespace BetList.Core.Entity
{
    using System.Collections.Generic;

    public interface IElement
    {
        string Text { get; set; }

        bool IsBlock { get; set; }

        string Name { get; set; }

        IDictionary<string, string> Formats { get; set; }

        IList<IElement> Children { get; set; }
    }
}