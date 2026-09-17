using System;
using System.Text;

namespace DPM235407_NguyenTuanAnh_BaiTap01_Proxy_DP
{
    class Program
    {
        static void ClientCode(ISubject subject)
        {
            subject.Request();
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("=== MẪU THIẾT KẾ PROXY (CONCEPTUAL - REFACTORING.GURU) ===\n");

            Console.WriteLine("Client: Executing the client code with a real subject:");
            RealSubject realSubject = new RealSubject();
            ClientCode(realSubject);

            Console.WriteLine();

            Console.WriteLine("Client: Executing the same client code with a proxy:");
            Proxy proxy = new Proxy(realSubject);
            ClientCode(proxy);
        }
    }
}
