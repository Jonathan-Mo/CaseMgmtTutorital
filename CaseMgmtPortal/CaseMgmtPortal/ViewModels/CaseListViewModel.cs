using CaseMgmtPortal.Models;

namespace CaseMgmtPortal.ViewModels
{
    public class CaseListViewModel
    {
        public List<Value> Value { get; }

        public CaseListViewModel(List<Value> value)
        {
            Value = value;
        }
    }
}
