namespace mini_task
{
    internal class Program
    {
        public class Account
        {
            public string Name { get; set; }
            public double Balance { get; set; }

            public Account(string name = "Unnamed Account", double balance = 0.0)
            {
                this.Name = name;
                this.Balance = balance;
            }

            public virtual bool Deposit(double amount)
            {
                if (amount <= 0)
                    return false;
                else
                {
                    Balance += amount;
                    return true;
                }
            }

            public virtual bool Withdraw(double amount)
            {
                if (amount <= 0 || amount > Balance)
                    return false;

                Balance -= amount;
                    return true;
                }
                
            }

          
        


            //SavingsAccount class 
            public class SavingsAccount : Account
            {
                public double InterestRate { get; set; }
                public SavingsAccount(string name = "Unnamed Savings Account", double balance = 0.0, double interestRate = 0.0)
                    : base(name, balance)
                {
                    this.InterestRate = interestRate;
                }

            public override bool Deposit(double amount)
            {
                  if (amount <= 0)
                    return false;

                double interest = amount * InterestRate / 100;
                // Call the base class Deposit method with the amount plus interest from the parent untile don't repeat writing the same code again and again
                return base.Deposit(amount + interest);
            }
              
            }

        //CheckingAccount class
        public class CheckingAccount : Account
        {
            private const double withdrawalFee = 1.50;
            public CheckingAccount(string name = "Unnamed Checking Account", double balance = 0.0)
                : base(name, balance)
            {
            }

            public override bool Withdraw(double amount)
            {
                if (amount <= 0)
                    return false;
                // Call the base class Withdraw method with the amount plus withdrawal fee from the parent until don't repeat writing the same code again and again
                return base.Withdraw(amount + withdrawalFee);
            }

        }
            //TrustAccount class
            public class TrustAccount : Account
            {
                public double InterestRate { get; set; }
                private int withdrawalsThisYear = 0;
                private int withdrawalYear=DateTime.Now.Year;
                public TrustAccount(string name = "Unnamed Trust Account", double balance = 0.0, double interestRate = 0)
                    : base(name, balance)
                {
                    InterestRate = interestRate;
                }
                public override bool Deposit(double amount)
                {
                    if (amount <= 0)
                        return false;
                    
                    double total = amount + (amount * InterestRate / 100);

                    if(amount >= 5000)
                    {
                        total += 50; // Add bonus for deposits of $5000 or more
                    }
                    return base.Deposit(total);
                }
        public override bool Withdraw(double amount)
        {
            int currentYear = DateTime.Now.Year;

            if (currentYear != withdrawalYear)
            {
                withdrawalYear = currentYear;
                withdrawalsThisYear = 0;
            }

            if (withdrawalsThisYear >= 3)
                return false;

            if (amount <= 0 || amount >= Balance * 0.20)
                return false;

            if (base.Withdraw(amount))
            {
                withdrawalsThisYear++;
                return true;
            }

            return false;
        }
    }

        //AccountUtil class
        public static class AccountUtil
        {
            public static void Deposit<T>(List<T> accounts, double amount)
                where T : Account
            {
                foreach (T account in accounts)
                {
                    bool result = account.Deposit(amount);

                    Console.WriteLine(
                        $"{account.Name}: Deposit {amount} - " +
                        $"{(result ? "Success" : "Failed")} - {account.Balance:C}");
                }
            }

            public static void Withdraw<T>(List<T> accounts, double amount)
                where T : Account
            {
                foreach (T account in accounts)
                {
                    bool result = account.Withdraw(amount);

                    Console.WriteLine(
                        $"{account.Name}: Withdraw {amount} - " +
                        $"{(result ? "Success" : "Failed")} - {account.Balance:C}");
                }
            }

            public static void DepositSavings(
                List<SavingsAccount> accounts, double amount)
                => Deposit(accounts, amount);

            public static void WithdrawSavings(
                List<SavingsAccount> accounts, double amount)
                => Withdraw(accounts, amount);

            public static void DepositChecking(
                List<CheckingAccount> accounts, double amount)
                => Deposit(accounts, amount);

            public static void WithdrawChecking(
                List<CheckingAccount> accounts, double amount)
                => Withdraw(accounts, amount);
        }



        static void Main(string[] args)
        {
            // Accounts
            Console.WriteLine("===========Accounts===========");
            var accounts = new List<Account>();
            accounts.Add(new Account());
            accounts.Add(new Account("Larry"));
            accounts.Add(new Account("Moe", 2000));
            accounts.Add(new Account("Curly", 5000));

            AccountUtil.Deposit(accounts, 1000);
            AccountUtil.Withdraw(accounts, 2000);

            // Savings
            Console.WriteLine("===========Savings Accounts===========");
            var savAccounts = new List<SavingsAccount>();
            savAccounts.Add(new SavingsAccount());
            savAccounts.Add(new SavingsAccount("Superman"));
            savAccounts.Add(new SavingsAccount("Batman", 2000));
            savAccounts.Add(new SavingsAccount("Wonderwoman", 5000, 5.0));

            AccountUtil.DepositSavings(savAccounts, 1000);
            AccountUtil.WithdrawSavings(savAccounts, 2000);

            // Checking
            Console.WriteLine("===========Checking Accounts===========");
            var checAccounts = new List<CheckingAccount>();
            checAccounts.Add(new CheckingAccount());
            checAccounts.Add(new CheckingAccount("Larry2"));
            checAccounts.Add(new CheckingAccount("Moe2", 2000));
            checAccounts.Add(new CheckingAccount("Curly2", 5000));

            AccountUtil.DepositChecking(checAccounts, 1000);
            AccountUtil.WithdrawChecking(checAccounts, 2000);
            AccountUtil.WithdrawChecking(checAccounts, 2000);


            // Trust
            Console.WriteLine("===========Trust Accounts===========");
            var trustAccounts = new List<TrustAccount>();
            trustAccounts.Add(new TrustAccount());
            trustAccounts.Add(new TrustAccount("Superman2"));
            trustAccounts.Add(new TrustAccount("Batman2", 2000));

            AccountUtil.Deposit(trustAccounts, 5000);
            AccountUtil.Withdraw(trustAccounts, 100);
        }
    }
}
