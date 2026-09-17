using System;
using System.Text;

namespace DPM235407_NguyenTuanAnh_BaiTap01_Adapter_DP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("=== MẪU THIẾT KẾ ADAPTER (CONCEPTUAL - REFACTORING.GURU) ===\n");

            Adaptee adaptee = new Adaptee();
            ITarget target = new Adapter(adaptee);

            Console.WriteLine("Giao diện Adaptee không tương thích trực tiếp với Client.");
            Console.WriteLine("Nhưng thông qua Adapter, Client có thể gọi phương thức của nó:\n");

            Console.WriteLine(target.GetRequest());
        }
    }
}
