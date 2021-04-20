using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Models;

namespace Api.Domain.Services.Communication
{
    public class MoneyFlowResponce:BaseResponce
    {
        public MoneyFlow MoneyFlow { get; private set; }
        private MoneyFlowResponce(bool success, string message, MoneyFlow moneyFlow) : base(success, message)
        {
            MoneyFlow = moneyFlow;
        }

        public MoneyFlowResponce(MoneyFlow moneyFlow) : this(true, string.Empty, moneyFlow) { }

        public MoneyFlowResponce(string message) : this(false, message, null)
        {

        }
    }
}
