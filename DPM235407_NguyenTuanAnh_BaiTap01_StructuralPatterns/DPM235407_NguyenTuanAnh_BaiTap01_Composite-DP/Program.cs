using System;
using System.Text;

namespace DPM235407_NguyenTuanAnh_BaiTap01_Composite_DP
{
    class Program
    {
        static void ClientCode(Component leaf)
        {
            Console.WriteLine($"RESULT: {leaf.Operation()}\n");
        }

        static void ClientCode2(Component component1, Component component2)
        {
            if (component1.IsComposite())
            {
                component1.Add(component2);
            }
            Console.WriteLine($"RESULT: {component1.Operation()}");
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("=== MẪU THIẾT KẾ COMPOSITE (CONCEPTUAL - REFACTORING.GURU) ===\n");

            // This way the client code can support the simple leaf
            // components...
            Leaf leaf = new Leaf();
            Console.WriteLine("Client: I get a simple component:");
            ClientCode(leaf);

            // ...as well as the complex composites.
            Composite tree = new Composite();
            Composite branch1 = new Composite();
            branch1.Add(new Leaf());
            branch1.Add(new Leaf());
            Composite branch2 = new Composite();
            branch2.Add(new Leaf());
            tree.Add(branch1);
            tree.Add(branch2);
            Console.WriteLine("Client: Now I've got a composite tree:");
            ClientCode(tree);

            Console.Write("Client: I don't need to check the components classes even when managing the tree:\n");
            ClientCode2(tree, leaf);
        }
    }
}
