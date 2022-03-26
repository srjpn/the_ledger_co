using System;
using System.Collections.Generic;
using TheLedgerCompany.Commands;
using TheLedgerCompany.Queries;

namespace TheLedgerCompany
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please provide the command");
            var response = new List<string>();
            string command;
            bool quitNow = false;
            while (!quitNow)
            {
                var arguments = Console.ReadLine().Split(" ");
                command = arguments[0];
                switch (command)
                {
                    case "LOAN":
                        new LoanCommand().Create(arguments[1], arguments[2], int.Parse(arguments[3]), int.Parse(arguments[4]), int.Parse(arguments[5]));
                        break;

                    case "PAYMENT":
                        new PaymentCommand().MakePayment(arguments[1], arguments[2], int.Parse(arguments[3]), int.Parse(arguments[4]));
                        break;

                    case "BALANCE":
                        var balance = new BalanceQuery().GetBalance(arguments[1], arguments[2], int.Parse(arguments[3]));
                        response.Add(balance.ToString());
                        break;

                    case "":
                        quitNow = true;
                        response.ForEach(x => Console.WriteLine(x));
                        break;

                    default:
                        Console.WriteLine("Unknown Command " + command);
                        break;
                }
            }
        }
    }
}
