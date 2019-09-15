using WorkflowCore.Interface;

namespace IR.Core
{
    [System.Obsolete]
    public interface IService // TODO: remove?
    {
        string Authorize();
        void GetOrders();
    }

    [System.Obsolete]
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