using System;

namespace TheLedgerCompany
{
    [Serializable]
    internal class InvalidCommandException : Exception
    {
        private const string message = "Invalid command provided";
        public InvalidCommandException() : base(message) { }
    }
}