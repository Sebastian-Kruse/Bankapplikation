using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankapplikation
{
    class InvestmentAccount : Account
    {
        public InvestmentAccount(string accountNumber, string ownerName, decimal initialBalance)
            : base(accountNumber, ownerName, initialBalance)
        {
            AccountType = "InvestmentAccount";
        }
    }
}
