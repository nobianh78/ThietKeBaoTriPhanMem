namespace DPM235407_NguyenTuanAnh_Tuan02_ChainOfResponsibility_DP
{
    public class SquirrelHandler : AbstractHandler
    {
        public override object? Handle(object request)
        {
            if (request.ToString() == "Nut")
            {
                return $"Squirrel: I'll eat the {request.ToString()}.\n";
            }
            else
            {
                return base.Handle(request);
            }
        }
    }
}
