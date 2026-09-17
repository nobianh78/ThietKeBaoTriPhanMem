using System;

namespace DPM235407_NguyenTuanAnh_Tuan02_Memento_DP
{
    // The Memento interface provides a way to retrieve the memento's metadata,
    // such as creation date or name. However, it doesn't expose the
    // Originator's state.
    public interface IMemento
    {
        string GetName();
        string GetState();
        DateTime GetDate();
    }
}
