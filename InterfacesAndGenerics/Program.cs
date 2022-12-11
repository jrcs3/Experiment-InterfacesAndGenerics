using InterfacesAndGenerics.models;
using System;
using System.Collections.Generic;

namespace InterfacesAndGenerics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Make a list of items with children
            List<IParent> parents = new List<IParent>();
            parents.Add(new FirstParent("1", new List<FirstChild>() { new FirstChild("11"), new FirstChild("12") }));
            parents.Add(new SecondParent("2", new List<SecondChild>() { new SecondChild("21"), new SecondChild("22", false), new SecondChild("23") }, false));
            parents.Add(new FirstParent("3", new List<FirstChild>() { new FirstChild("31") }));
            parents.Add(new FirstParent("4", new List<FirstChild>() { new FirstChild("41"), new FirstChild("42", false), new FirstChild("43", false) }, false));
            parents.Add(new SecondParent("5", new List<SecondChild>() { new SecondChild("51"), new SecondChild("52", false), new SecondChild("53") }, false));
            parents.Add(new FirstParent("6", new List<FirstChild>() { new FirstChild("61") }));

            for (int i = 0; i < parents.Count; i++)
            {
                IParent parent = parents[i];
                Console.Write($"{parent.Name}-{parent.IsOk}: ");
                foreach (var c in parent.Children)
                {
                    Console.Write($"{c.Name}-{c.IsOk}, ");
                }
                Console.WriteLine();

                if (!parent.IsOk)
                {
                    for (int j = 0; j < parent.ChildCount; j++)
                    {
                        IChild child = parent.GetChildAt(j);
                        if (!child.IsOk)
                        {
                            // Cast as a specific type with casting
                            var fc = child as FirstChild;
                            if (fc != null)
                            {
                                Console.Write($"{fc.FirstChildName}: ");
                            }
                            
                            if (child.GetType() == typeof(SecondChild) )
                            {
                                var sc = (SecondChild)child;
                                Console.Write($"{sc.SecondChildName}: ");
                            }
                            Console.WriteLine($"Not Ok {parent.Name}.{child.Name} at {i}.{j}");
                        }
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
