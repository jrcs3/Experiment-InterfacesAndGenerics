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
            List<IParent> parents = MakeParentList();

            for (int i = 0; i < parents.Count; i++)
            {
                IParent parent = parents[i];
                EnumerateChildren(parent);

                if (!parent.IsOk)
                {
                    EnumerateNotOkChildren(i, parent);
                }
            }
            Console.ReadKey();
        }

        private static List<IParent> MakeParentList()
        {
            List<IParent> parents = new List<IParent>();
            parents.Add(new ExplicitParent("1", new List<ExplicitChild>() { new ExplicitChild("11"), new ExplicitChild("12") }));
            parents.Add(new ImplicitParent("2", new List<ImplicitChild>() { new ImplicitChild("21"), new ImplicitChild("22", false), new ImplicitChild("23") }, false));
            parents.Add(new ExplicitParent("3", new List<ExplicitChild>() { new ExplicitChild("31") }));
            parents.Add(new ExplicitParent("4", new List<ExplicitChild>() { new ExplicitChild("41"), new ExplicitChild("42", false), new ExplicitChild("43", false) }, false));
            parents.Add(new ImplicitParent("5", new List<ImplicitChild>() { new ImplicitChild("51"), new ImplicitChild("52", false), new ImplicitChild("53") }, false));
            parents.Add(new ExplicitParent("6", new List<ExplicitChild>() { new ExplicitChild("61") }));
            parents.Add(new MixedParent("7", new List<IChild>() { new ExplicitChild("71"), new ImplicitChild("72"), new ExplicitChild("73", false), new ImplicitChild("74", false) }));
            parents.Add(new MixedParent("8", new List<IChild>() { new ExplicitChild("81"), new ImplicitChild("82"), new ExplicitChild("83", false), new ImplicitChild("84", false) }, false));
            return parents;
        }

        private static void EnumerateChildren(IParent parent)
        {
            Console.Write($"{parent.Name}-{parent.IsOk}: ");
            foreach (var c in parent.Children)
            {
                Console.Write($"{c.Name}-{c.IsOk}, ");
            }
            Console.WriteLine();
        }

        private static void EnumerateNotOkChildren(int i, IParent parent)
        {
            for (int j = 0; j < parent.ChildCount; j++)
            {
                IChild child = parent.GetChildAt(j);
                if (!child.IsOk)
                {
                    RunClassSpecificCodeOnChild(child);
                    Console.WriteLine($"Not Ok {parent.Name}.{child.Name} at {i}.{j}");
                }
            }
        }

        private static void RunClassSpecificCodeOnChild(IChild child)
        {
            // Cast as a specific type with casting
            var fc = child as ExplicitChild;
            if (fc != null)
            {
                Console.Write($"{fc.ExplicitChildName}: ");
            }

            if (child.GetType() == typeof(ImplicitChild))
            {
                var sc = (ImplicitChild)child;
                Console.Write($"{sc.SecondChildName}: ");
            }
        }
    }
}
