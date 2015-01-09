using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using MsmqContract;

namespace MsmqClient
{
    class MsmqContractClient : ClientBase<IMsmqContract>, IMsmqContract
    {
        public MsmqContractClient(string endpoint)
            : base(endpoint)
        { }

        #region IMsmqContract Members

        public void SendMessage(string message)
        {
            Channel.SendMessage(message);
        }

        #endregion
    }
}
