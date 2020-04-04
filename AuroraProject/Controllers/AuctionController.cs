using AuroraProject.Models;
using AuroraProject.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace AuroraProject.Controllers
{
    public class AuctionController : Controller
    {

        private ApplicationDbContext context;
        public AuctionController()
        {
            context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        // GET: Auction
        public ActionResult Create()
        {
            var userId = User.Identity.GetUserId();

            var gigs = context.Gigs.Where(g => g.UserID == userId).ToList();
            var specificIndustries = context.SpecificIndustries.ToList();

            // CREATE VIEW MODEL TO SEND IT TO THE VIEW
            var viewModel = new AuctionFormViewModel(0, 0, gigs);

            return PartialView("_Auction", viewModel);
        }
    }
}