using System;

namespace LambasSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount bankAcct = new BankAccount();
            bankAcct.SavingsGoal = 500m;

            bankAcct.Deposited += (object sender, BalanceUpdatedEventArgs e) =>
            {
                Console.WriteLine($"The balance amount is {e.newBalance}");
            };

            bankAcct.GoalReached += (object sender, BalanceUpdatedEventArgs e) =>
            {
                Console.WriteLine($"You've reached your savings goal! Goal: {bankAcct.SavingsGoal}, Balance: {e.newBalance}");
            };
            
            while(true)
            {
                Console.WriteLine("How much do you want to deposit?");
                decimal amount;

                Decimal.TryParse(Console.ReadLine(), out amount);

                bankAcct.Balance += amount;
            }
        }
    }
}
