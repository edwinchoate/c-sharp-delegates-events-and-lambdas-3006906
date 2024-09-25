using System;

namespace EventsSolution
{
    class BankAccount 
    {
        
        private decimal _balance;
        
        public event EventHandler<BalanceUpdatedEventArgs> Deposited;
        public event EventHandler<BalanceUpdatedEventArgs> GoalReached;

        public decimal Balance 
        {
            get => _balance;
            set
            {
                _balance = value;

                var eventArgs = new BalanceUpdatedEventArgs() { newBalance = value };

                Deposited(this, eventArgs);

                if (value >= SavingsGoal)
                    GoalReached(this, eventArgs);
            }
        }

        public decimal SavingsGoal { get; set; } = decimal.MaxValue;

    }
}