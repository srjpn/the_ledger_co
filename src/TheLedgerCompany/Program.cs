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
            Console.WriteLine("Welcome to The Ledger company");
            while (true)
            {
                var arguments = new List<string>(Console.ReadLine().Split(" "));
                string command = arguments[0];
                var action = serviceProvider.GetService<ActionSelector>().GetAction(command);
                var result = action.Execute(arguments.Skip(1).ToArray());
                if (action is IQuery)
                {
                    Console.WriteLine(result.ToString());
                }
            }
        }

        private static ServiceProvider ConfigureServices()
        {
            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddTransient<IAction, LoanCommand>()
                .AddTransient<IAction, PaymentCommand>()
                .AddTransient<IAction, BalanceQuery>()
                .AddTransient<IAction, QuitCommand>()
                .AddSingleton<ActionSelector>()
                .AddSingleton<PaymentService>()
                .AddSingleton<LoanService>()
                .AddSingleton<BalanceService>()
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
