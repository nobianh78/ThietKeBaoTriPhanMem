using System;
using System.Text;

namespace DPM235407_NguyenTuanAnh_BaiTap01_Facade_DP
{
    class Program
    {
        static void ClientCode(Facade facade)
        {
            Console.Write(facade.Operation());
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("=== MẪU THIẾT KẾ FACADE (CONCEPTUAL - REFACTORING.GURU) ===\n");

            // The client code may have some of the subsystem's objects already
            // created. In this case, it might be worthwhile to initialize the
            // Facade with these objects instead of letting the Facade create
            // new instances.
            Subsystem1 subsystem1 = new Subsystem1();
            Subsystem2 subsystem2 = new Subsystem2();
            Facade facade = new Facade(subsystem1, subsystem2);
            ClientCode(facade);
        }
    }
}
