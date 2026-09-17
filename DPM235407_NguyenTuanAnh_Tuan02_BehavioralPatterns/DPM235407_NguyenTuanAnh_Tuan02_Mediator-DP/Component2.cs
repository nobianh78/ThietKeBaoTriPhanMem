using System;

namespace DPM235407_NguyenTuanAnh_Tuan02_Mediator_DP
{
    public class Component2 : BaseComponent
    {
        public void DoC()
        {
            Console.WriteLine("Component 2 does C.");

            this._mediator?.Notify(this, "C");
        }

        public void DoD()
        {
            Console.WriteLine("Component 2 does D.");

            this._mediator?.Notify(this, "D");
        }
    }
}
