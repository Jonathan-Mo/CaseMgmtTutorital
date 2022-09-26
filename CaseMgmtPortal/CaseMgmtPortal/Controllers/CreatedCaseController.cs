using CaseMgmtPortal.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using static System.Net.WebRequestMethods;
using System.Linq;
using System.Text.Json;
using Newtonsoft.Json;
using CaseMgmtPortal.ViewModels;

namespace CaseMgmtPortal.Controllers
{
    public class CreatedCaseController : Controller
    {
        public IActionResult Index()
        {
            string url = "https://localhost:7060/api/Cases";

            var client = new RestClient(url);

            var request = new RestRequest();

            var response = client.Get(request);

            var childCases = JsonConvert.DeserializeObject<Root>(response.Content);

            var newestCase = childCases.value.OrderByDescending(c => c.id).FirstOrDefault();

            //Console.WriteLine($"{newestCase.id}, {newestCase.child.FirstName}");

            //Console.Read();

            CaseViewModel caseViewModel = new CaseViewModel(newestCase);

            return View(caseViewModel);
        }
    }
}
