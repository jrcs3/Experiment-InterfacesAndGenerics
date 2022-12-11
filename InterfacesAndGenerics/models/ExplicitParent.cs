using System.Collections.Generic;

namespace InterfacesAndGenerics.models
{
    public class ExplicitParent : IParent
    {
        private string _name;
        private bool _isOk;
        List<ExplicitChild> _children;
        public ExplicitParent(string name, List<ExplicitChild> children = null, bool isOk = true)
        {
            _name = name;
            _children = children;
            _isOk = isOk;
        }

        //public List<FirstChild> Children { get; set; }
        IEnumerable<IChild> IParent.Children => _children;

        #region IParent Implementation Explicitly
        string IParent.Name { get => _name; }

        bool IParent.IsOk { get => _isOk; }

        int IParent.ChildCount { get => _children.Count; }

        IChild IParent.GetChildAt(int index)
        {
            return _children[index];
        }
        #endregion IParent Implementation Explicitly
    }
}
