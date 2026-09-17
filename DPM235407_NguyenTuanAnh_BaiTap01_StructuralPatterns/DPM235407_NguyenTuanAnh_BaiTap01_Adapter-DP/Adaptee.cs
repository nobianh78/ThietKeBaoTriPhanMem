namespace DPM235407_NguyenTuanAnh_BaiTap01_Adapter_DP
{
    // The Adaptee contains some useful behavior, but its interface is
    // incompatible with the existing client code. The Adaptee needs some
    // adaptation before the client code can use it.
    public class Adaptee
    {
        public string GetSpecificRequest()
        {
            return "Specific request.";
        }
    }
}
