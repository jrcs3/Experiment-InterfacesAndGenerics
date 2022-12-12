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
            List<IParent> parents = new List<IParent>() 
            {
                new ExplicitParent("1", new List<ExplicitChild>() 
                {
                    new ExplicitChild("11"),
                    new ExplicitChild("12")
                }),
                new ImplicitParent("2", new List<ImplicitChild>() 
                {
                    new ImplicitChild("21"),
                    new ImplicitChild("22", false),
                    new ImplicitChild("23")
                }, false),
                new ExplicitParent("3", new List<ExplicitChild>() {
                    new ExplicitChild("31")
                }),
                new ExplicitParent("4", new List<ExplicitChild>() 
                {
                    new ExplicitChild("41"),
                    new ExplicitChild("42", false),
                    new ExplicitChild("43", false)
                }, false),
                new ImplicitParent("5", new List<ImplicitChild>() 
                {
                    new ImplicitChild("51"),
                    new ImplicitChild("52", false),
                    new ImplicitChild("53")
                }, false),
                new ExplicitParent("6", new List<ExplicitChild>() 
                {
                    new ExplicitChild("61")
                }),
                new MixedParent("7", new List<IChild>() 
                {
                    new ExplicitChild("71"),
                    new ImplicitChild("72"),
                    new ExplicitChild("73", false),
                    new ImplicitChild("74", false)
                }),
                new MixedParent("8", new List<IChild>() 
                {
                    new ExplicitChild("81"),
                    new ImplicitChild("82"),
                    new ExplicitChild("83", false),
                    new ImplicitChild("84", false)
                }, false)
            };
            return parents;
        }

        private static void EnumerateChildren(IParent parent)
        {
            Console.Write($"{parent.Name}-{parent.IsOk}: ");
            foreach (IChild c in parent.Children)
            {
                Console.Write($"{c.Name}-{c.IsOk}, ");
            }
            Console.WriteLine();
        }

        private static void EnumerateNotOkChildren(int parentI, IParent parent)
        {
            for (int childI = 0; childI < parent.ChildCount; childI++)
            {
                IChild child = parent.GetChildAt(childI);
                if (!child.IsOk)
                {
                    RunClassSpecificCodeOnChild(child);
                    Console.WriteLine($"Not Ok {parent.Name}.{child.Name} at {parentI}.{childI}");
                }
            }
        }

        private static void RunClassSpecificCodeOnChild(IChild child)
        {
            // Cast as a specific type with casting
            ExplicitChild explicitChild = child as ExplicitChild;
            if (explicitChild != null)
            {
                Console.Write($"{explicitChild.ExplicitChildName}: ");
            }

            if (child.GetType() == typeof(ImplicitChild))
            {
                ImplicitChild implicitChild = (ImplicitChild)child;
                Console.Write($"{implicitChild.ImplicitChildName}: ");
            }
        }
    }
}
