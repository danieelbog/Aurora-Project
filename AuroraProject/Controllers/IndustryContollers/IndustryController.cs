using AuroraProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuroraProject.Controllers
{
    public class IndustryController : Controller
    {
        private ApplicationDbContext context;
        public IndustryController()
        {
            context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        public ActionResult AuroraProIndustries()
        {
            var industries = context.Industries
                .ToList();

            return View("AuroraProIndustries", industries);
        }
    }
}