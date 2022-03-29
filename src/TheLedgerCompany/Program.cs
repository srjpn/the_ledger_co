using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using TheLedgerCompany.Commands;
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
            bool quitNow = false;
            while (!quitNow)
            {
                var arguments = new List<string>(Console.ReadLine().Split(" "));
                string command = arguments[0];
                switch (command)
                {
                    case "LOAN":
                        arguments.Skip(1);
                        serviceProvider.GetService<LoanCommand>().Execute(arguments.Skip(1).ToArray());
                        // (arguments[1], arguments[2], int.Parse(arguments[3]), int.Parse(arguments[4]), int.Parse(arguments[5]));
                        break;

                    case "PAYMENT":
                        serviceProvider.GetService<PaymentCommand>().Execute(arguments.Skip(1).ToArray());
                        // serviceProvider.GetService<PaymentCommand>().MakePayment(arguments[1], arguments[2], int.Parse(arguments[3]), int.Parse(arguments[4]));
                        break;

                    case "BALANCE":
                        var balance = serviceProvider.GetService<BalanceQuery>().Execute(arguments.Skip(1).ToArray());
                        // serviceProvider.GetService<BalanceQuery>().GetBalance(arguments[1], arguments[2], int.Parse(arguments[3]));
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
            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddTransient<LoanCommand>()
                .AddTransient<PaymentCommand>()
                .AddTransient<BalanceQuery>()
                .AddSingleton<PaymentService>()
                .AddSingleton<LoanService>()
                .AddSingleton<BalanceService>()
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
