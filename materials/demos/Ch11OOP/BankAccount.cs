namespace IntroCSCS
{
    public class BankAccount
    {
     
        // private decimal balance;

        // public decimal Balance              // Balance property; a special method with
        // {                                   // getter and setter
        //     get { return balance; }
        //     set { balance = value; }
        // }
    
     
        private decimal balance;                        // private field 

        public BankAccount(decimal initialBalance)      // constructor 
        {
            balance = initialBalance;
        }

        public decimal GetBalance()
        {
            return balance;
        }

        public void Deposit(decimal amount)
        {
            balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            balance -= amount;
        }
    }

}