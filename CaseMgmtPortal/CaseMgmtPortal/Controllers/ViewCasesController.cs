using CaseMgmtPortal.Models;
using CaseMgmtPortal.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace CaseMgmtPortal.Controllers
{
    public class ViewCasesController : Controller
    {
        public Value? WantedCase { get; set; }
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

        public IActionResult ViewCase(int id)
        {
            string url = "https://localhost:7060/api/Cases";

            var client = new RestClient(url);

            var request = new RestRequest();

            var response = client.Get(request);

            var childCases = JsonConvert.DeserializeObject<Root>(response.Content);

            var newestCase = childCases.value.OrderByDescending(c => c.id == id).FirstOrDefault();

            CaseViewModel caseViewModel = new CaseViewModel(newestCase);

            return View(caseViewModel);
        }

        public IActionResult EditCase(int id)
        {
            string url = "https://localhost:7060/api/Cases";

            var client = new RestClient(url);

            var request = new RestRequest();

            var response = client.Get(request);

            var childCases = JsonConvert.DeserializeObject<Root>(response.Content);

            var newestCase = childCases.value.OrderByDescending(c => c.id == id).FirstOrDefault();

            CaseViewModel caseViewModel = new CaseViewModel(newestCase);

            return View(caseViewModel);
        }

        [HttpPost]
        public IActionResult EditCase(CaseViewModel childCase)
        {
            if (ModelState.IsValid)
            {
                string url = "https://localhost:7060/api/cases/";

                //url = url + childCase.id.ToString();

                var client = new RestClient(url);

                var request = new RestRequest();

                request.AddJsonBody(childCase);

                var response = client.Post(request);

                return RedirectToAction("ViewCases", "ViewCase");
            }

            return View();
        }
    }
}
