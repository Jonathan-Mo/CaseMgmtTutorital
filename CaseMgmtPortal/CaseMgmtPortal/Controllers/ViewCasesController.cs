using AutoMapper;
using CaseMgmtPortal.ModelDTOs;
using CaseMgmtPortal.Models;
using CaseMgmtPortal.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReflectionIT.Mvc.Paging;
using RestSharp;
using System.Linq;
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
        public IActionResult Index(int page = 1)
        {
            string url = "https://localhost:7060/api/Cases";

            var client = new RestClient(url);

            var request = new RestRequest();

            var response = client.Get(request);

            var childCases = JsonConvert.DeserializeObject<Root>(response.Content);

            var newestCases = childCases?.value.OrderBy(c => c.updateDate);

            var model = new ListRecords();

            model.NumRecords = newestCases.Count();

            var extractedCases = newestCases.Skip((page-1)*10);

            model.ListOfRecords = extractedCases.Take(10);

            return View(model);
        }

        public IActionResult Index25(int page = 1)
        {
            string url = "https://localhost:7060/api/Cases";

            var client = new RestClient(url);

            var request = new RestRequest();

            var response = client.Get(request);

            var childCases = JsonConvert.DeserializeObject<Root>(response.Content);

            var newestCases = childCases?.value.OrderBy(c => c.updateDate);

            var model = new ListRecords();

            model.NumRecords = newestCases.Count();

            var extractedCases = newestCases.Skip((page - 1) * 25);

            model.ListOfRecords = extractedCases.Take(25);

            return View(model);
        }

        public IActionResult Index50(int page = 1)
        {
            string url = "https://localhost:7060/api/Cases";

            var client = new RestClient(url);

            var request = new RestRequest();

            var response = client.Get(request);

            var childCases = JsonConvert.DeserializeObject<Root>(response.Content);

            var newestCases = childCases?.value.OrderBy(c => c.updateDate);

            var model = new ListRecords();

            model.NumRecords = newestCases.Count();

            var extractedCases = newestCases.Skip((page - 1) * 50);

            model.ListOfRecords = extractedCases.Take(50);

            return View(model);
        }

        public IActionResult IndexAll()
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

        public IActionResult ViewCase(long id)
        {
            string[] subs;
            if (id == null || id == 0)
            {
                string myUrl = Microsoft.AspNetCore.Http.Extensions.UriHelper.GetDisplayUrl(Request);
                subs = myUrl.Split('=', '&');
                if (subs.Length > 1)
                    if (subs[1] != "")
                    {
                        id = long.Parse(subs[1]);

                        string url = "https://localhost:7060/api/Cases";

                        var client = new RestClient(url);

                        var request = new RestRequest();

                        var response = client.Get(request);

                        var childCases = JsonConvert.DeserializeObject<Root>(response.Content);

                        var tempCase = childCases.value.OrderByDescending(c => c.id == id).FirstOrDefault();

                        CaseDTO newestCase = _mapper.Map<CaseDTO>(tempCase);

                        return View(newestCase);
                    }
            }
            return View();
        }

        public IActionResult EditCase(int id)
        {
            string url = "https://localhost:7060/api/Cases";

            var client = new RestClient(url);

            var request = new RestRequest();

            var response = client.Get(request);

            var childCases = JsonConvert.DeserializeObject<Root>(response.Content);

            var tempCase = childCases.value.OrderByDescending(c => c.id == id).FirstOrDefault();

            CaseDTO newestCase = _mapper.Map<CaseDTO>(tempCase);

            Case caseViewModel = new Case();

            return View(newestCase);
        }

        [HttpPost]
        public IActionResult EditCase(CaseDTO childCase)
        {
            if (ModelState.IsValid)
            {
                if (childCase.Notes == "Entered in Error")
                    childCase.Status = "Request for Closure";
                else if (childCase.Notes == "Neglect Resolved")
                    childCase.Status = "Request for Closure";
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
