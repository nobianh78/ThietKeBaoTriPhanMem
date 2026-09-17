using System;
using System.Text;

namespace DPM235407_NguyenTuanAnh_BaiTap01_Bridge_DP
{
    class Program
    {
        static void ClientCode(Abstraction abstraction)
        {
            Console.Write(abstraction.Operation());
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("=== MẪU THIẾT KẾ BRIDGE (CONCEPTUAL - REFACTORING.GURU) ===\n");

            Abstraction abstraction;
            // The client code should be able to work with any pre-configured
            // abstraction-implementation combination.
            abstraction = new Abstraction(new ConcreteImplementationA());
            ClientCode(abstraction);

            Console.WriteLine();

            abstraction = new ExtendedAbstraction(new ConcreteImplementationB());
            ClientCode(abstraction);
        }
    }
}
