using AuroraProject.Models;
using AuroraProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

namespace AuroraProject.Controllers
{
    public class GigController : Controller
    {
        private ApplicationDbContext context;
        public GigController()
        {
            context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        //GET: THE DETAILS OF A GIG
        public ActionResult Details(int gigID)
        {
            var gigs = context.Gigs
                .Include(g => g.User)
                .Include(g => g.BasicPackage)
                .Include(g => g.AdvancedPackage)
                .Include(g => g.PremiumPackage)
                .Include(g => g.SpecificIndustry)
                .Include(g => g.Influencer)

                //I CREATE A LIST OF ONE GIG SO I CAN USE MY OLD VIEW MODEL
                //DONT KNOW IF THIS IS OK OR NOT BUT IT WORKS FOR NOW
                //SURELLY THERE ARE NO GIGS WITH THE SAME ID
                .Where(g => g.ID == gigID)
                .ToList();

            var viewModel = new GigsViewModel(gigs, User.Identity.IsAuthenticated,
                                $"{gigs[0].GigName}", null);

            return View("Details", viewModel);
        }

        // GET: ALL GIGS
        public ActionResult Index(int? specificIndustryID, string query = null)
        {
            // BRING THE GIGS WITH THE DATA I WANT
            var gigs = context.Gigs
                .Include(g => g.User)
                .Include(g => g.BasicPackage)
                .Include(g => g.SpecificIndustry)
                .Include(g => g.SpecificIndustry.Industry)
                .Include(g => g.Influencer)
                .ToList();

            if (specificIndustryID != null)
                gigs = gigs.Where(g => g.SpecificIndustryID == specificIndustryID).ToList();

            if (!String.IsNullOrWhiteSpace(query))
            {
                gigs = gigs
                    .Where(g =>
                                g.User.FirstName.Contains(query) ||
                                g.User.LastName.Contains(query) ||
                                g.User.UserFullName.Contains(query) ||
                                g.SpecificIndustry.Name.Contains(query) ||
                                g.GigName.Contains(query)).ToList();
            }

            if (specificIndustryID == null && String.IsNullOrEmpty(query))
            {
                return RedirectToAction("Mine");
            }

            // SORT THE GIG WITH THE CORRECT SORTER
            Sorter.SortLogic(gigs);

            // SEND GIGS TO THE VIEW
            var viewModel = new GigsViewModel(gigs, User.Identity.IsAuthenticated,
                specificIndustryID == null ? "No Gigs were Found" : $"All {context.SpecificIndustries.SingleOrDefault(sp => sp.ID == specificIndustryID).Name} Gigs", query);

            //SEND THE SORTED LIST TO THE VIEW
            return View(viewModel);
        }

        //SEARCH GIGS
        [HttpPost]
        public ActionResult Search(GigsViewModel gigsViewModel)
        {
            return RedirectToAction("Index", new { query = gigsViewModel.SearchTerm });
        }

        // MY POSTED GIGS
        [Authorize]
        public ActionResult Mine()
        {
            var userId = User.Identity.GetUserId();

            var gigs = context.Gigs
                .Where(g => g.UserID == userId)
                .Include(g => g.User)
                .Include(g => g.BasicPackage)
                .Include(g => g.SpecificIndustry)
                .Include(g => g.Influencer)
                .ToList();

            // SORT THE GIG WITH THE CORRECT SORTER
            Sorter.SortLogic(gigs);

            // CREATE THE VIEW THAT WE WILL SEND
            var viewModel = new GigsViewModel(gigs, User.Identity.IsAuthenticated,
               $"All {ApplicationUser.FullName(context.Users.SingleOrDefault(u => u.Id == userId))} Gigs", null);

            // SEND GIGS TO THE VIEW          
            return View(viewModel);
        }

        // MY FAVOURITE GIGS
        [Authorize]
        public ActionResult Favourites()
        {
            var userId = User.Identity.GetUserId();

            var gigs = context.FavouriteGigs
                .Where(f => f.ActionerID == userId)
                .Select(f => f.Gig)
                .Include(g => g.User)
                .Include(g => g.BasicPackage)
                .Include(g => g.SpecificIndustry)
                .Include(g => g.Influencer)
                .ToList();

            // SORT THE GIG WITH THE CORRECT SORTER
            Sorter.SortLogic(gigs);

            // CREATE THE VIEW THAT WE WILL SEND
            var viewModel = new GigsViewModel(gigs, User.Identity.IsAuthenticated,
               "My Favourite Gigs", null);

            // SEND GIGS TO THE VIEW          
            return View("Index", viewModel);
        }

        // GET: Gig
        public ActionResult Create()
        {
            // CREATE VIEW MODEL TO SEND IT TO THE VIEW
            var viewModel = GigFormViewModel.CreateFormViewModel(null, context.SpecificIndustries.ToList(), "Create New Gig", "Save");

            return View("GigForm", viewModel);
        }

        //GET: GIG FOR EDIT
        [Authorize]
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();

            // BRING GIG FROM DB WITH ALL ITS FOLLOWINGS
            var gig = context.Gigs
                .Include(g => g.BasicPackage)
                .Include(g => g.AdvancedPackage)
                .Include(g => g.PremiumPackage)
                .Include(g => g.SpecificIndustry)
                .Include(g => g.Influencer)
                .SingleOrDefault(g => g.ID == id && g.User.Id == userId);

            //CHECK IF THE GIG EXIST
            if (gig == null)
                return HttpNotFound();

            var viewModel = GigFormViewModel.CreateFormViewModel(gig, context.SpecificIndustries.ToList(), "Update your Gig", "Update");

            // GO TO CREATE VIEW
            return View("GigForm", viewModel);
        }

        //POST: ADD A GIG, OR SEND FOR UPDATE - DELETE
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GigFormViewModel gigFormViewModel)
        {
            // CHECK IF MODEL IS VALID
            if (!ModelState.IsValid)
                return View(gigFormViewModel);

            var userId = User.Identity.GetUserId();
            // CREATE NEW GIG

            //Create a Basic Selling Package
            var basicPackage = new BasicPackage(gigFormViewModel);
            context.BasicPackages.Add(basicPackage);

            //Create an Advanced Selling Package
            var advancedPackage = new AdvancedPackage(gigFormViewModel);
            context.AdvancedPackages.Add(advancedPackage);

            //Create a Premium Selling Package
            var premiumPackage = new PremiumPackage(gigFormViewModel);
            context.PremiumPackages.Add(premiumPackage);

            //Get the user Id in order to bind everything together
            var infleuncer = context.Influencers.SingleOrDefault(i => i.User.Id == userId);
            if (infleuncer == null)
                return HttpNotFound();

            // Create a Gig                    
            var gig = new Gig(gigFormViewModel, userId, infleuncer.ID);
            context.Gigs.Add(gig);

            context.SaveChanges();

            // WHEN EVERYTHING IS DONE GO TO INDEX
            return RedirectToAction("Index");
        }

        //POST: UPDATE A GIG
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(GigFormViewModel updatedViewModel)
        {
            var userId = User.Identity.GetUserId();

            //GET THE EXISTING GIG FOR UPDATE
            var gigDB = context.Gigs
                .Include(g => g.PremiumPackage)
                .Include(g => g.AdvancedPackage)
                .Include(g => g.BasicPackage)
                .Include(g => g.Influencer)
                .SingleOrDefault(g => g.ID == updatedViewModel.GigID && g.UserID == userId);

            //CHECK IF THE GIG EXIST
            if (gigDB == null)
                return HttpNotFound();

            gigDB.Modify(updatedViewModel);

            // GO TO DB AND SAVE CHANGES
            context.SaveChanges();

            // WHEN EVERYTHING IS DONE GO TO INDEX
            return RedirectToAction("Index");
        }

        //DELETE: DELETE A GIG
        [Authorize]
        [HttpDelete]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(GigFormViewModel gigFormViewModel)
        {
            // BRING THE GIG FROM DB WITH ITS CONTAININGS
            var gig = context.Gigs
            .Include(g => g.BasicPackage)
            .Include(g => g.AdvancedPackage)
            .Include(g => g.PremiumPackage)
            .SingleOrDefault(g => g.ID == gigFormViewModel.GigID);

            // CHECK IF GIG EXIST
            if (gig == null)
                return HttpNotFound();

            // INITIALIZE THE OTHER ENTITIES FOR DELATION
            var basicPackage = gig.BasicPackage;
            var advancedPackage = gig.AdvancedPackage;
            var premiumPackage = gig.PremiumPackage;

            // DELETE EVERYTHING RELATED TO THE GIG
            context.Gigs.Remove(gig);
            context.BasicPackages.Remove(basicPackage);
            context.AdvancedPackages.Remove(advancedPackage);
            context.PremiumPackages.Remove(premiumPackage);

            // GO TO DB AND SAVE CHANGES
            context.SaveChanges();

            // WHEN EVERYTHING IS DONE GO TO INDEX
            return RedirectToAction("Index");
        }
    }
}