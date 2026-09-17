namespace DPM235407_NguyenTuanAnh_BaiTap01_Bridge_DP
{
    // Each Concrete Implementation corresponds to a specific platform and
    // implements the Implementation interface using that platform's API.
    public class ConcreteImplementationA : IImplementation
    {
        public string OperationImplementation()
        {
            return "ConcreteImplementationA: The result on the platform A.\n";
        }
    }
}
