using System.Collections.Generic;

namespace InterfacesAndGenerics.models
{
    public class FirstParent : IParent
    {
        public FirstParent(string name, List<FirstChild> children = null, bool isOk = true)
        {
            Name = name;
            Children = children;
            IsOk = isOk;
        }
        public string Name { get; set; }

        public List<FirstChild> Children { get; set; }

        public bool IsOk { get; private set; }

        public int ChildCount { get => Children.Count; }

        public IChild GetChildAt(int index)
        {
            return Children[index];
        }
    }
}
