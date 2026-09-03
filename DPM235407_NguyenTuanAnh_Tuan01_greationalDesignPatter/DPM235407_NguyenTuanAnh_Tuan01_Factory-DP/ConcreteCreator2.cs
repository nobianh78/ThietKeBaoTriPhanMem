using System;

namespace DPM235407_NguyenTuanAnh_Tuan01_Factory_DP
{
    public class ConcreteCreator2 : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new ConcreteProduct2();
        }
    }
}
