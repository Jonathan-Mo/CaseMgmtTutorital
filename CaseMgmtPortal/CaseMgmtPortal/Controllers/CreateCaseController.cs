using CaseMgmtPortal.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace CaseMgmtPortal.Controllers
{
    public class CreateCaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Case childCase)
        {
            if (ModelState.IsValid)
            {
                childCase.Date = DateTime.Now;

                string url = "https://localhost:7060/api/cases";

                var client = new RestClient(url);

                var request = new RestRequest();

                request.AddJsonBody(childCase);

                var response = client.Post(request);

                return RedirectToAction("Index", "CreatedCase");
            }

            return View();
        }
    }
}
   