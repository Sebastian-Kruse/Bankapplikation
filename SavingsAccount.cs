using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Bankapplikation
{
    class SavingsAccount : Account
    {
        public SavingsAccount(string accountNumber, string ownerName, decimal initialBalance)
            : base(accountNumber, ownerName, initialBalance)
        {
            AccountType = "SavingsAccount";
        }
    }
}
