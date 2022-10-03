using AutoMapper;
using CaseMgmtPortal.Models;
using CaseMgmtPortal.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Net.Http;

namespace CaseMgmtPortal.Controllers
{
    public class ViewCasesController : Controller
    {
        private readonly IMapper _mapper;

        public ViewCasesController(IMapper mapper)
        {
            _mapper = mapper;
        }
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

        public async Task<IActionResult> EditCase(int id)
        {
            string url = "https://localhost:7060/api/Cases";

            var client = new RestClient(url);

            var request = new RestRequest();

            var response = client.Get(request);

            var childCases = JsonConvert.DeserializeObject<Root>(response.Content);

            var tempCase = childCases.value.OrderByDescending(c => c.id == id).FirstOrDefault();

            Case newestCase = _mapper.Map<Case>(tempCase);

            //Case caseViewModel = new Case();

            return View(newestCase);
        }

        [HttpPost]
        public IActionResult EditCase(Case childCase)
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
