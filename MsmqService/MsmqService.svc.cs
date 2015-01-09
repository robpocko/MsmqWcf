using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MsmqContract;
using System.Diagnostics;

namespace MsmqService
{
    public class MsmqService : IMsmqContract
    {
        [OperationBehavior(TransactionScopeRequired = true)]
        public void SendMessage(string message)
        {
            if (message == "Bad")
            {
                throw new InvalidOperationException("Bad!");
            }

            Trace.WriteLine(String.Format("Received message at {0} : {1}", DateTime.Now, message));
        }
    }
}
