using System;
using System.Collections.Generic;

namespace DPM235407_NguyenTuanAnh_Tuan02_Strategy_DP
{
    public class ConcreteStrategyB : IStrategy
    {
        public object DoAlgorithm(object data)
        {
            var list = data as List<string>;
            list?.Sort();
            list?.Reverse();

            return list!;
        }
    }
}
