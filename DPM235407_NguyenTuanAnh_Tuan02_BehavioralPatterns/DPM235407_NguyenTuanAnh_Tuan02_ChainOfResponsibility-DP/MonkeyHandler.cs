namespace DPM235407_NguyenTuanAnh_Tuan02_ChainOfResponsibility_DP
{
    public class MonkeyHandler : AbstractHandler
    {
        public override object? Handle(object request)
        {
            if ((request as string) == "Banana")
            {
                return $"Monkey: I'll eat the {request.ToString()}.\n";
            }
            else
            {
                return base.Handle(request);
            }
        }
    }
}
