using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using TheLedgerCompany.Commands;
using TheLedgerCompany.Queries;
using TheLedgerCompany.Services;

namespace TheLedgerCompany
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = ConfigureServices();
            var filePath = args[0];
            var response = new List<string>();
            foreach (string line in System.IO.File.ReadLines(filePath))
            {
                var arguments = new List<string>(line.Split(" "));
                string command = arguments[0];
                var action = serviceProvider.GetService<ActionSelector>().GetAction(command);
                var result = action.Execute(arguments.Skip(1).ToArray());
                if (result != null)
                {
                    response.Add(result.ToString());
                }
            }

            response.ForEach(x => Console.WriteLine(x));
        }

        private static ServiceProvider ConfigureServices()
        {
            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddTransient<IAction, LoanCommand>()
                .AddTransient<IAction, PaymentCommand>()
                .AddTransient<IAction, BalanceQuery>()
                .AddSingleton<ActionSelector>()
                .AddSingleton<IPaymentService, PaymentService>()
                .AddSingleton<ILoanService, LoanService>()
                .AddSingleton<IBalanceService, BalanceService>()
                .AddSingleton<IInterestChangeService, InterestChangeService>()
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
