using System;

namespace DPM235407_NguyenTuanAnh_Tuan01_Builder_DP
{
    // The Builder interface specifies methods for creating the different parts
    // of the Product objects.
    public interface IBuilder
    {
        void BuildPartA();

        void BuildPartB();

        void BuildPartC();
    }
}
