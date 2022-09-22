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
                string url = "https://localhost:7060/api/cases";

                var client = new RestClient(url);

                var request = new RestRequest();

                request.AddJsonBody(childCase);

                var response = client.Post(request);

                //Console.WriteLine(response.StatusCode.ToString() + "     " + response.Content.ToString());

                return RedirectToAction("Index", "CreatedCase", childCase);
            }

            return View(childCase);
        }
    }
}
   