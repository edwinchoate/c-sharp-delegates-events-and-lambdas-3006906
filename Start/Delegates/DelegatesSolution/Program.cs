using System;
using System.Collections.Generic;

namespace DelegatesSolution
{

    public delegate void FeeDelegate(string zone, decimal itemPrice, ref decimal totalFees);

    class Program
    {
        const string exitCommand = "exit";
        const decimal highRiskFee = 25.00m;

        static Dictionary<string, decimal> percentFees = new Dictionary<string, decimal>()
        {
            {"zone1", 0.25m},
            {"zone2", 0.12m},
            {"zone3", 0.08m},
            {"zone4", 0.04m},
            {"zone5", 0.15m},
        };

        static string[] dangerZones = {"zone2", "zone4"};
        

        static void Main(string[] args)
        {
            bool progRunning = true;

            do
            {
                Console.WriteLine("What is the destination zone?");
                string zoneInput = Console.ReadLine().ToLower();

                if (zoneInput == exitCommand)
                {
                    progRunning = false;
                    break;
                }

                Console.WriteLine("What is the item price?");
                string priceInput = Console.ReadLine().ToLower();

                if (priceInput == exitCommand)
                {
                    progRunning = false;
                    break;
                }

                decimal itemPrice = 0m, totalFees = 0m;
                
                Decimal.TryParse(priceInput, out itemPrice);

                FeeDelegate applyFees = ApplyPercentageFee;

                if (Array.IndexOf(dangerZones, zoneInput) != -1)
                    applyFees += ApplyFixedFee;

                applyFees(zoneInput, itemPrice, ref totalFees);

                Console.WriteLine($"The shipping fees are: {totalFees}");
            }
            while (progRunning);

        }

        static void ApplyPercentageFee (string zone, decimal itemPrice, ref decimal totalFees)
        {
            totalFees += itemPrice * percentFees[zone];
        }

        static void ApplyFixedFee (string zone, decimal itemPrice, ref decimal totalFees)
        {
            totalFees += highRiskFee;
        }

    }
}
