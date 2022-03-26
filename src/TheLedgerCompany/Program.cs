using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using TheLedgerCompany.Commands;
using TheLedgerCompany.Models;
using TheLedgerCompany.Queries;
using TheLedgerCompany.Services;

namespace TheLedgerCompany
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = ConfigureServices();
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
                        serviceProvider.GetService<LoanCommand>().Create(arguments[1], arguments[2], int.Parse(arguments[3]), int.Parse(arguments[4]), int.Parse(arguments[5]));
                        break;

                    case "PAYMENT":
                        serviceProvider.GetService<PaymentCommand>().MakePayment(arguments[1], arguments[2], int.Parse(arguments[3]), int.Parse(arguments[4]));
                        break;

                    case "BALANCE":
                        var balance = serviceProvider.GetService<BalanceQuery>().GetBalance(arguments[1], arguments[2], int.Parse(arguments[3]));
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

        private static ServiceProvider ConfigureServices()
        {
            var loans = new List<Loan>();
            var payments = new List<Payment>();
            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddTransient<LoanCommand>()
                .AddTransient<PaymentCommand>()
                .AddTransient<BalanceQuery>()
                .AddSingleton<PaymentService>()
                .AddSingleton<LoanService>()
                .AddSingleton<BalanceService>()
                .AddSingleton((IServiceProvider arg) => loans)
                .AddSingleton((IServiceProvider arg) => payments)
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
