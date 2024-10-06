using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankapplikation
{
    class User
    {
        public string Name { get; set; }
        public string Email { get; set; }   
        public PersonalAccount PersonalAccount { get; set; }
        public SavingsAccount SavingsAccount { get; set; }
        public InvestmentAccount InvestmentAccount { get; set; }

        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
