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
        public IActionResult Index(int page = 1, int size = 10, int count = 10)
        {
            FilterSpecification filters = new FilterSpecification();
            //filters.Filters.Add("In Progress");
            //filters.Filters.Add("Assigned");
            filters.pageNumber = page;
            filters.pageSize = size;
            filters.Count = count;

            string url = "https://localhost:7060/api/Cases/partial";

            var client = new RestClient(url);

            var request = new RestRequest();

            //request.AddHeader("filter", filters.Filters);
            request.AddHeader("page", filters.pageNumber);
            request.AddHeader("size", filters.pageSize);
            request.AddHeader("count", filters.Count);

            var response = client.Get(request);

            var model = new ListRecords();

            var childCases = JsonConvert.DeserializeObject<Root>(response.Content);

            model.ListOfRecords = childCases.value;

            model.NumRecords = GetAllCasesCount();

            //string urlAll = "https://localhost:7060/api/Cases";

            //var clientAll = new RestClient(urlAll);

            //var requestAll = new RestRequest();

            //var responseAll = client.Get(requestAll);

            //var childCasesAll = JsonConvert.DeserializeObject<Root>(responseAll.Content);

            //var totalCount = childCases.value.Count();

            //model.NumRecords = totalCount;

            //CaseListViewModel caseListViewModel = new CaseListViewModel(newestCase);

            return View(model);

            //string[] subs;

            //string myUrl = Microsoft.AspNetCore.Http.Extensions.UriHelper.GetDisplayUrl(Request);
            //subs = myUrl.Split('=', 'x');
            //if (subs.Length > 1)
            //{
            //    bool conA = subs.AsQueryable().Contains("PendingReview");
            //    bool conB = subs.AsQueryable().Contains("InProgress");
            //    bool conC = subs.AsQueryable().Contains("Assigned");
            //    bool conD = subs.AsQueryable().Contains("Closed");
            //    bool conE = subs.AsQueryable().Contains("RequestforClosure");

            //    string conditionalUrl = "https://localhost:7060/api/Cases";

            //    var conditionalClient = new RestClient(conditionalUrl);

            //    var conditionalRequest = new RestRequest();

            //    var conditionalResponse = conditionalClient.Get(conditionalRequest);

            //    var conditionalChildCases = JsonConvert.DeserializeObject<Root>(conditionalResponse.Content);

            //    if (!conA)
            //    {
            //        foreach (var useCase in conditionalChildCases.value.ToList())
            //        {
            //            if (useCase.status == "Pending Review")
            //                conditionalChildCases.value.Remove(useCase);
            //        }
            //        Console.WriteLine(conditionalChildCases.value);
            //    }
            //    if (!conB)
            //    {
            //        foreach (var useCase in conditionalChildCases.value.ToList())
            //        {
            //            if (useCase.status == "In Progress")
            //                conditionalChildCases.value.Remove(useCase);
            //        }
            //        Console.WriteLine(conditionalChildCases.value);
            //    }
            //    if (!conC)
            //    {
            //        foreach (var useCase in conditionalChildCases.value.ToList())
            //        {
            //            if (useCase.status == "Assigned")
            //                conditionalChildCases.value.Remove(useCase);
            //        }
            //        Console.WriteLine(conditionalChildCases.value);
            //    }
            //    if (!conD)
            //    {
            //        foreach (var useCase in conditionalChildCases.value.ToList())
            //        {
            //            if (useCase.status == "Closed")
            //                conditionalChildCases.value.Remove(useCase);
            //        }
            //        Console.WriteLine(conditionalChildCases.value);
            //    }
            //    if (!conE)
            //    {
            //        foreach (var useCase in conditionalChildCases.value.ToList())
            //        {
            //            if (useCase.status == "Request for Closure")
            //                conditionalChildCases.value.Remove(useCase);
            //        }
            //        Console.WriteLine(conditionalChildCases.value);
            //    }

            //    var conditionalNewestCases = conditionalChildCases?.value.OrderBy(c => c.updateDate);

            //    var conditionalModel = new ListRecords();

            //    conditionalModel.NumRecords = conditionalNewestCases.Count();

            //    var conditionalExtractedCases = conditionalNewestCases.Skip((page - 1) * 10);

            //    conditionalModel.ListOfRecords = conditionalExtractedCases.Take(10);

            //    return View(conditionalModel);
            //}

            //string url = "https://localhost:7060/api/Cases";

            //var client = new RestClient(url);

            //var request = new RestRequest();

            //var response = client.Get(request);

            //var childCases = JsonConvert.DeserializeObject<Root>(response.Content);

            //var newestCases = childCases?.value.OrderBy(c => c.updateDate);

            //var model = new ListRecords();

            //model.NumRecords = newestCases.Count();

            //var extractedCases = newestCases.Skip((page - 1) * 10);

            // model.ListOfRecords = extractedCases.Take(10);

            //return View(newestCases);
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

                        string urlConditional = "https://localhost:7060/api/Cases";

                        var clientConditional = new RestClient(urlConditional);

                        var requestConditional = new RestRequest();

                        var responseConditional = clientConditional.Get(requestConditional);

                        var childCasesConditional = JsonConvert.DeserializeObject<Root>(responseConditional.Content);

                        var tempCaseConditional = childCasesConditional.value.OrderByDescending(c => c.id == id).FirstOrDefault();

                        CaseDTO newestCaseConditional = _mapper.Map<CaseDTO>(tempCaseConditional);

                        return View(newestCaseConditional);
                    }
                    else
                    {
                        if (subs[3] == "All")
                        {
                            return RedirectToAction("Index", "ViewCases");
                        }
                        else
                        {
                            string filters = "";
                            for (int i = 3; i <= subs.Length; i = (i + 2))
                            {
                                if(i == 3)
                                {
                                    filters = filters + subs[i] + "x";
                                }
                                else
                                {
                                    filters = filters + subs[i] + "x";
                                }
                            }
                            return RedirectToAction("Index", "ViewCases", new {filters});
                        }
                    }
            }

            string url = "https://localhost:7060/api/Cases";

            var client = new RestClient(url);

            var request = new RestRequest();

            var response = client.Get(request);

            var childCases = JsonConvert.DeserializeObject<Root>(response.Content);

            var tempCase = childCases.value.OrderByDescending(c => c.id == id).FirstOrDefault();

            CaseDTO newestCase = _mapper.Map<CaseDTO>(tempCase);

            return View(newestCase);
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

        public int GetAllCasesCount()
        {
            string url = "https://localhost:7060/api/Cases";

            var client = new RestClient(url);

            var request = new RestRequest();

            var response = client.Get(request);

            var childCases = JsonConvert.DeserializeObject<Root>(response.Content);

            var caseCount = childCases.value.Count();

            return caseCount;
        }
    }
}
