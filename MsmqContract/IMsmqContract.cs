using System.ServiceModel;

namespace MsmqContract
{
    [ServiceContract]
    public interface IMsmqContract
    {
        [OperationContract(IsOneWay = true)]
        void SendMessage(string message);
    }
}
