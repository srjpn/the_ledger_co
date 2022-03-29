using System.Collections.Generic;
using System.Linq;
using TheLedgerCompany.Queries;

namespace TheLedgerCompany
{
    public class ActionSelector
    {
        private readonly IEnumerable<IAction> actions;
        public ActionSelector(IEnumerable<IAction> actions)
        {
            this.actions = actions;

        }

        public IAction GetAction(string command)
        {
            IAction action = actions.ToList().FirstOrDefault(x => ActionAttribute.GetActionAttribute(x) == command.ToUpper());
            if (action == null)
            {
                return new HelpQuery();
            }
            return action;
        }
    }
}