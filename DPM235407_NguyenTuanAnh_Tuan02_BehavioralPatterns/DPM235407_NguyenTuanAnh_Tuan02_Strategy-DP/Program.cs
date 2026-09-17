using System;

namespace DPM235407_NguyenTuanAnh_Tuan02_Strategy_DP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== REFACTORING.GURU: STRATEGY PATTERN ===");

            // The client code picks a concrete strategy and passes it to the
            // context. The client should be aware of the differences between
            // strategies in order to make the right choice.
            var context = new Context(new ConcreteStrategyA());
            Console.WriteLine("Client: Strategy is set to normal sorting.");
            context.DoSomeBusinessLogic();

            Console.WriteLine();

            Console.WriteLine("Client: Strategy is set to reverse sorting.");
            context.SetStrategy(new ConcreteStrategyB());
            context.DoSomeBusinessLogic();
        }
    }
}
