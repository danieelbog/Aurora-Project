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

        // INDEX HERE IS USED TO PRINT THE MEGANAVBAR - DONT TOUCH
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