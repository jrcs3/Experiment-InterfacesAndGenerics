namespace InterfacesAndGenerics.models
{
    public class ImplicitChild : IChild
    {
        public ImplicitChild(string name = "", bool isOk = true)
        {
            Name = name;
            IsOk = isOk;
        }

        #region IChild Implementation Implicitly
        public string Name { get; set; }
        public bool IsOk { get; set; }
        #endregion IChild Implementation Implicitly

        public string SecondChildName { get => $"2nd-Child-{Name}"; }
    }
}
