namespace DPM235407_NguyenTuanAnh_Tuan02_Mediator_DP
{
    // The Base Component provides the basic functionality of storing a
    // mediator's instance inside component objects.
    public class BaseComponent
    {
        protected IMediator? _mediator;

        public BaseComponent(IMediator? mediator = null)
        {
            this._mediator = mediator;
        }

        public void SetMediator(IMediator mediator)
        {
            this._mediator = mediator;
        }
    }
}
