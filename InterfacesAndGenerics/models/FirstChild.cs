namespace InterfacesAndGenerics.models
{
    public class FirstChild: IChild
    {
        private string _name;
        private bool _isOk;
        public FirstChild(string name = "", bool isOk = true)
        {
            _name = name;
            _isOk = isOk;
        }

        public string FirstChildName { get => $"1st-Child-{_name}"; }

        #region IChild Implementation Explicitly
        string IChild.Name { get => _name; }
        public bool IsOk { get => _isOk; }
        #endregion IChild Implementation Explicitly
    }
}
