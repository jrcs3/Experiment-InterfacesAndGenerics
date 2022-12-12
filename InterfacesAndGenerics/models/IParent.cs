using System.Collections.Generic;

namespace InterfacesAndGenerics.models
{
    public interface IParent
    {
        string Name { get; }
        bool IsOk { get; }
        IChild GetChildAt(int index);
        int ChildCount { get; }
        IEnumerable<IChild> Children { get; }
    }
}
