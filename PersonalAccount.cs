using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankapplikation
{
    class PersonalAccount : Account
    {
        public PersonalAccount(string accountNumber, string ownerName, decimal initialBalance)
            : base(accountNumber, ownerName, initialBalance)
        {
            AccountType = "PersonalAccount";
        }
    }
}
