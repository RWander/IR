namespace IR.Core
{
    public interface IService
    {
        string Authorize();
        void GetOrders();
    }

    public sealed class Service: IService
    {
        public string Authorize()
        {
            return "OK!";
        }

        public void GetOrders()
        {

        }
    }
}