using System;
using System.Diagnostics.CodeAnalysis;

namespace TheLedgerCompany
{
    [ExcludeFromCodeCoverage]
    [Serializable]
    internal class InvalidCommandException : Exception
    {
        private const string message = "Invalid command provided";
        public InvalidCommandException() : base(message) { }
    }
}