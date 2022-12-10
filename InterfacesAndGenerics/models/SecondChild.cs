namespace InterfacesAndGenerics.models
{
    public class SecondChild : IChild
    {
        public SecondChild(string name = "", bool isOk = true)
        {
            Name = name;
            IsOk = isOk;
        }

        public string Name { get; set; }
        public bool IsOk { get; set; }

        public string SecondChildName { get => $"2nd-Child-{Name}"; }
    }
}
