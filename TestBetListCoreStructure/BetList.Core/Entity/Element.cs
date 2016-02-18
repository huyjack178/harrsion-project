namespace BetList.Core.Entity
{
    using System.Collections.Generic;

    public class Element : IElement
    {
        public IList<IElement> Children { get; set; }

        public string Name { get; set; }

        public IDictionary<string, string> Formats { get; set; }

        public bool IsBlock { get; set; }

        public string Text { get; set; }

        public Element()
        {
            Formats = new Dictionary<string, string>();
            Children = new List<IElement>();
        }

        public void AddChild(IElement element)
        {
            this.Children.Add(element);
        }
    }
}