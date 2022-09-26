using CaseMgmtPortal.Models;
using CaseMgmtPortal.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace CaseMgmtPortal.Controllers
{
    public class ViewCasesController : Controller
    {
        public IActionResult Index()
        {
            string url = "https://localhost:7060/api/Cases";

            var client = new RestClient(url);

            var request = new RestRequest();

            var response = client.Get(request);

            var childCases = JsonConvert.DeserializeObject<Root>(response.Content);

            var newestCase = childCases.value;

            CaseListViewModel caseListViewModel = new CaseListViewModel(newestCase);

            return View(caseListViewModel);
        }
    }
}
