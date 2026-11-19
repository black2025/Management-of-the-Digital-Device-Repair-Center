namespace CustomerAccount.Models
{
    interface IPaymentOperations
    {
        void Deposit(decimal amount);
        bool Pay(decimal amount);
        decimal GetBalance();
    }



    internal class CustomerAccount: IPaymentOperations
    {
        private decimal balance;

        public string Owner { get; set; }
        public int AccountNumber { get; set; }
        public decimal Balance
        {
            get { return balance; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Balance Can\'t Be Negative.");
                }
                balance = value;
            }
        }

        public CustomerAccount (decimal thisBalance, string owner, int accountNumber )
        {
            Balance = thisBalance;
            Owner = owner;
            AccountNumber = accountNumber;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Deposit Amount Should Be More Than 0");
            }
            Balance += amount;
            Console.WriteLine("Deposit Was Successfull!");
        }

        public bool Pay(decimal amount)
        {
            if (amount > Balance || amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Either Your Balance Is Lower Than Your Amount Pay Or Amount Is Lower Than 1");
            }
            Console.WriteLine("Payment Was Successfull!");
            return true;
        }

        public decimal GetBalance()
        {
            return Balance;
        }
    }
}
