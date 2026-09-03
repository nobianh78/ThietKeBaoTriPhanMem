using System;

namespace DPM235407_NguyenTuanAnh_Tuan01_Abstract_DP
{
    // Concrete Products are created by corresponding Concrete Factories.
    public class ConcreteProductA1 : IAbstractProductA
    {
        public string UsefulFunctionA()
        {
            return "The result of the product A1.";
        }
    }
}
