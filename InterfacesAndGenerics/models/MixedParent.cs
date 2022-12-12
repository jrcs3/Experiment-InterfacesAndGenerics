using System.Collections.Generic;

namespace InterfacesAndGenerics.models
{
    public class MixedParent : IParent
    {
        public MixedParent(string name, List<IChild> children = null, bool isOk = true)
        {
            Name = name;
            Children = children;
            IsOk = isOk;
        }

        public List<IChild> Children { get; set; }

        public string Name {get; private set;}

        public bool IsOk { get; private set; }

        public int ChildCount { get => Children.Count; }

        IEnumerable<IChild> IParent.Children => Children;

        public IChild GetChildAt(int index)
        {
            return Children[index];
        }
    }
}
