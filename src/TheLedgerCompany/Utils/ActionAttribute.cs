using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace TheLedgerCompany
{
    [ExcludeFromCodeCoverage]
    public class ActionAttribute : Attribute
    {
        private string name;

        public ActionAttribute(string name)
        {
            this.name = name;
        }

        public string Name => name;

        public static string GetActionAttribute(object obj)
        {
            var attributesArray = new List<object>(obj.GetType().GetCustomAttributes(true));

            return ((ActionAttribute)attributesArray.FirstOrDefault(x => x is ActionAttribute)).Name;
        }
    }
}