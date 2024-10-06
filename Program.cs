namespace Bankapplikation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                // Skapa en användare
                User användare = new User("Sebastian", "Sebastian@email.com");

                // Skapa konton för användaren
                användare.PersonalAccount = new PersonalAccount("111", användare.Name, 5000);
                användare.SavingsAccount = new SavingsAccount("222", användare.Name, 10000);
                användare.InvestmentAccount = new InvestmentAccount("333", användare.Name, 50000);

                bool körProgram = true;

                while (körProgram)
                {
                    Console.WriteLine("   Välkommen till Bankapplikation   ");
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("1. Sätt in pengar");
                    Console.WriteLine("2. Ta ut pengar");
                    Console.WriteLine("3. Överför pengar");
                    Console.WriteLine("4. Kontrollera saldo");
                    Console.WriteLine("5. Visa transaktionshistorik");
                    Console.WriteLine("6. Avsluta");
                    Console.Write("Välj ett alternativ (1-6): ");

                    string val = Console.ReadLine();

                    switch (val)
                    {
                        case "1":
                            DepositFunds(användare);
                            break;
                        case "2":
                            WithdrawFunds(användare);
                            break;
                        case "3":
                            TransferFunds(användare);
                            break;
                        case "4":
                            CheckBalance(användare);
                            break;
                        case "5":
                            ShowTransactionHistory(användare);
                            break;
                        case "6":
                            körProgram = false;
                            break;
                        default:
                            Console.WriteLine("Ogiltigt val. Försök igen.");
                            break;
                    }

                    Console.WriteLine();
                }

                Console.WriteLine("Tack för att du använde Bankapplikation.");
            }

            static void DepositFunds(User användare)
            {
                Account konto = GetAccountFromUser(användare, "Ange kontonummer att sätta in pengar på: ");
                if (konto == null) return;

                Console.Write("Ange belopp att sätta in: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal belopp) && belopp > 0)
                {
                    konto.Deposit(belopp);
                    Console.WriteLine($"Insättning lyckades. Nytt saldo: {konto.Balance} kr");
                }
                else
                {
                    Console.WriteLine("Ogiltigt belopp.");
                }
            }

            static void WithdrawFunds(User användare)
            {
                Account konto = GetAccountFromUser(användare, "Ange kontonummer att ta ut pengar från: ");
                if (konto == null) return;

                Console.Write("Ange belopp att ta ut: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal belopp) && belopp > 0)
                {
                    if (konto.Balance >= belopp)
                    {
                        konto.Withdraw(belopp);
                        Console.WriteLine($"Uttag lyckades. Nytt saldo: {konto.Balance} kr");
                    }
                    else
                    {
                        Console.WriteLine("Otillräckligt saldo.");
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltigt belopp.");
                }
            }

            static void TransferFunds(User användare)
            {
                Console.Write("Ange kontonummer att överföra från: ");
                Account frånKonto = GetAccountByNumber(användare, Console.ReadLine());
                if (frånKonto == null) return;

                Console.Write("Ange kontonummer att överföra till: ");
                Account tillKonto = GetAccountByNumber(användare, Console.ReadLine());
                if (tillKonto == null) return;

                Console.Write("Ange belopp att överföra: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal belopp) && belopp > 0)
                {
                    if (frånKonto.Balance >= belopp)
                    {
                        frånKonto.Withdraw(belopp);
                        tillKonto.Deposit(belopp);

                        frånKonto.TransactionHistory.AddTransaction($"Överföring till {tillKonto.AccountNumber}: -{belopp} kr");
                        tillKonto.TransactionHistory.AddTransaction($"Överföring från {frånKonto.AccountNumber}: +{belopp} kr");

                        Console.WriteLine("Överföring lyckades.");
                    }
                    else
                    {
                        Console.WriteLine("Otillräckligt saldo.");
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltigt belopp.");
                }
            }

            static void CheckBalance(User användare)
            {
                Account konto = GetAccountFromUser(användare, "Ange kontonummer att kontrollera saldo för: ");
                if (konto == null) return;

                Console.WriteLine($"Kontoinnehavare: {konto.OwnerName}");
                Console.WriteLine($"Kontotyp: {konto.AccountType}");
                Console.WriteLine($"Saldo: {konto.Balance} kr");
            }

            static void ShowTransactionHistory(User användare)
            {
                Account konto = GetAccountFromUser(användare, "Ange kontonummer för att visa transaktionshistorik: ");
                if (konto == null) return;

                Console.WriteLine($"Transaktionshistorik för konto {konto.AccountNumber}:");

                if (konto.TransactionHistory.FirstTransaction != null)
                {
                    Console.WriteLine($"Första transaktionen: {konto.TransactionHistory.FirstTransaction}");
                    Console.WriteLine($"Senaste transaktionen: {konto.TransactionHistory.LastTransaction}");
                }
                else
                {
                    Console.WriteLine("Inga transaktioner har gjorts på detta konto.");
                }
            }

            static Account GetAccountFromUser(User användare, string prompt)
            {
                Console.Write(prompt);
                string accountNumber = Console.ReadLine();
                Account konto = GetAccountByNumber(användare, accountNumber);

                if (konto == null)
                {
                    Console.WriteLine("Konto hittades inte.");
                }

                return konto;
            }

            static Account GetAccountByNumber(User användare, string accountNumber)
            {
                if (användare.PersonalAccount.AccountNumber == accountNumber)
                    return användare.PersonalAccount;
                else if (användare.SavingsAccount.AccountNumber == accountNumber)
                    return användare.SavingsAccount;
                else if (användare.InvestmentAccount.AccountNumber == accountNumber)
                    return användare.InvestmentAccount;
                else
                    return null;
            }
        }
    }
}
