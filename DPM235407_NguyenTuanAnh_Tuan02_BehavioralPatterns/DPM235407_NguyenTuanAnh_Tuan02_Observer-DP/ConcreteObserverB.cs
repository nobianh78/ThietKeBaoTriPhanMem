using System;

namespace DPM235407_NguyenTuanAnh_Tuan02_Observer_DP
{
    class ConcreteObserverB : IObserver
    {
        public void Update(ISubject subject)
        {
            if ((subject as Subject)?.State == 0 || (subject as Subject)?.State >= 2)
            {
                Console.WriteLine("ConcreteObserverB: Reacted to the event.");
            }
        }
    }
}
