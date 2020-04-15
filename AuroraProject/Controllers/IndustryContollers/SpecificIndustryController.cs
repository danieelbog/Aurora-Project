using AuroraProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using AuroraProject.Persistence;
using AuroraProject.Core;

namespace AuroraProject.Controllers
{
    public class SpecificIndustryController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public SpecificIndustryController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: SpecificIndustry
        public ActionResult AuroraProSpecificIndustries(int industryID)
        {
            var specificIndustries = unitOfWork.SpecificIndustryRepository.GetSpecificIndustriesPerIndustry(industryID);

            return View("AuroraProSpecificIndustries", specificIndustries);
        }

        public ActionResult Index()
        {
            var specificIndustry = unitOfWork.SpecificIndustryRepository.GetSpecificIndustries()
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