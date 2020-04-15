using AuroraProject.Core;
using AuroraProject.Core.Models;
using AuroraProject.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuroraProject.Controllers
{
    public class IndustryController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public IndustryController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public ActionResult AuroraProIndustries()
        {
            var industries = unitOfWork.IndustryRepository.GetIndustries();

            return View("AuroraProIndustries", industries);
        }
    }
}