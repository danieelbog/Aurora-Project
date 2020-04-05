using AuroraProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace AuroraProject.Controllers
{
    public class SpecificIndustryController : Controller
    {
        private ApplicationDbContext context;
        public SpecificIndustryController()
        {
            context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        // GET: SpecificIndustry
        public ActionResult AuroraProSpecificIndustries(int industryID)
        {
            var specificIndustries = context.SpecificIndustries
                .Where(sp => sp.IndustryID == industryID)
                .ToList();

            return View("AuroraProSpecificIndustries", specificIndustries);
        }

        public ActionResult Index()
        {
            var specificIndustry = context.SpecificIndustries
                .Include(sp => sp.Industry)
                .ToList();

            return PartialView("_Index", specificIndustry);
        }
        public ActionResult GigsPerIndustry(int specificIndustryID)
        {
            return RedirectToAction("Index", "Gig", new { specificIndustryID = specificIndustryID });
        }
        
        // SEARCH
        public ActionResult Search()
        {
            return PartialView("_Search");
        }

    }
}