using CaseMgmtPortal.Models;

namespace CaseMgmtPortal.ViewModels
{
    public class CaseViewModel
    {
        public Value Value { get; }

        public CaseViewModel(Value value)
        {
            Value = value;
        }
    }
}
