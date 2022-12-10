using System.Collections.Generic;

namespace InterfacesAndGenerics.models
{
    public class SecondParent : IParent
    {
        public SecondParent(string name, List<SecondChild> children = null, bool isOk = true)
        {
            Name = name;
            Children = children;
            IsOk = isOk;
        }
        public string Name { get; set; }

        public List<SecondChild> Children { get; set; }

        public bool IsOk { get; set; }

        public int ChildCount { get => Children.Count; }

        public IChild GetChildAt(int index)
        {
            return Children[index];
        }

    }
}
