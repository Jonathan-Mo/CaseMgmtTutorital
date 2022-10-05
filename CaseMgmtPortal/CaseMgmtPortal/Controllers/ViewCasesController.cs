using AutoMapper;
using CaseMgmtPortal.ModelDTOs;
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

            var tempCase = childCases.value.OrderByDescending(c => c.id == id).FirstOrDefault();

            CaseDTO newestCase = _mapper.Map<CaseDTO>(tempCase);

            //CaseViewModel caseViewModel = new CaseViewModel(newestCase);

            return View(newestCase);
        }

        public async Task<IActionResult> EditCase(int id)
        {
            string url = "https://localhost:7060/api/Cases";

            var client = new RestClient(url);

            var request = new RestRequest();

            var response = client.Get(request);

            var childCases = JsonConvert.DeserializeObject<Root>(response.Content);

            var tempCase = childCases.value.OrderByDescending(c => c.id == id).FirstOrDefault();

            CaseDTO newestCase = _mapper.Map<CaseDTO>(tempCase);

            //Case caseViewModel = new Case();

            return View(newestCase);
        }

        [HttpPost]
        public IActionResult EditCase(CaseDTO childCase)
        {
            if (ModelState.IsValid)
            {
                if (childCase.Notes == "Entered in Error")
                    childCase.Status = "Request for Case Closure.";
                else if (childCase.Notes == "Neglect Resolved")
                    childCase.Status = "Request for Case Closure.";
                else
                    childCase.Status = childCase.Status;
                
                childCase.UpdateDate = DateTime.Now;

                string url = "https://localhost:7060/api/cases/";

                url = url + childCase.Id.ToString();

                var client = new RestClient(url);

                var request = new RestRequest();

                request.AddJsonBody(childCase);

                var response = client.Put(request);

                return RedirectToAction("UpdatedCase", "ViewCases", new { id = childCase.Id});
            }

            return View();
        }

        public IActionResult UpdatedCase(int id)
        {
            string url = "https://localhost:7060/api/Cases";

            var client = new RestClient(url);

            var request = new RestRequest();

            var response = client.Get(request);

            var childCases = JsonConvert.DeserializeObject<Root>(response.Content);

            var tempCase = childCases.value.OrderByDescending(c => c.id == id).FirstOrDefault();

            CaseDTO newestCase = _mapper.Map<CaseDTO>(tempCase);

            return View(newestCase);
        }

        public IActionResult CaseReport()
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
