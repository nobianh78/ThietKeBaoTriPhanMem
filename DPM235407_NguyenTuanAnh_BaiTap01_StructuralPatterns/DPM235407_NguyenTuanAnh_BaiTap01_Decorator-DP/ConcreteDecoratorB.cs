namespace DPM235407_NguyenTuanAnh_BaiTap01_Decorator_DP
{
    // Decorators can execute their behavior either before or after the call to
    // a wrapped object.
    public class ConcreteDecoratorB : Decorator
    {
        public ConcreteDecoratorB(Component comp) : base(comp)
        {
        }

        public override string Operation()
        {
            return $"ConcreteDecoratorB({base.Operation()})";
        }
    }
}
