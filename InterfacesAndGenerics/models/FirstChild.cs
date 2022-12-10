namespace InterfacesAndGenerics.models
{
    public class FirstChild: IChild
    {
        public FirstChild(string name = "", bool isOk = true)
        {
            Name = name;
            IsOk = isOk;
        }

        public string Name { get; set; }
        public bool IsOk { get; set; }

        public string FirstChildName { get => $"1st-Child-{Name}"; }
    }
}
