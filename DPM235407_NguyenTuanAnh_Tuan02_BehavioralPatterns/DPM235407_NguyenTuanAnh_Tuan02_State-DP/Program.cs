using System;

namespace DPM235407_NguyenTuanAnh_Tuan02_State_DP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== REFACTORING.GURU: STATE PATTERN ===");

            // The client code.
            var context = new Context(new ConcreteStateA());
            context.Request1();
            context.Request2();
        }
    }
}
