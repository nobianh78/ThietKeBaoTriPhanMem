using System;

namespace DPM235407_NguyenTuanAnh_Tuan01_Factory_DP
{
    // Concrete Products provide various implementations of the Product
    // interface.
    public class ConcreteProduct1 : IProduct
    {
        public string Operation()
        {
            return "{Result of ConcreteProduct1}";
        }
    }
}
