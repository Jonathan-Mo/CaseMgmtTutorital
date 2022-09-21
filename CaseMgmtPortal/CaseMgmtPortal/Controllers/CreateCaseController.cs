using CaseMgmtPortal.Models;
using Microsoft.AspNetCore.Mvc;

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
                return RedirectToAction("Index", "CreatedCase");
            }

            return View(childCase);
        }
    }
}
   