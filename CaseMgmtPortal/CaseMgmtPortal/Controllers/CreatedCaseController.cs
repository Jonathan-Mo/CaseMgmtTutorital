using CaseMgmtPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace CaseMgmtPortal.Controllers
{
    public class CreatedCaseController : Controller
    {
        public IActionResult Index(Case childCase)
        {
            Console.WriteLine("Here we are!");
            Console.WriteLine($"Child's name:{childCase.Reporter.FirstName}");
            return View();
        }
    }
}
