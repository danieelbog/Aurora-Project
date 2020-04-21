using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using AuroraProject.Persistence;
using AuroraProject.Core;
using AuroraProject.Core.ViewModels;
using AuroraProject.Core.Models;

namespace AuroraProject.Controllers
{
    public class GigController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public GigController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        //SEARCH GIGS
        [HttpPost]
        public ActionResult Search(GigsViewModel gigsViewModel)
        {
            return RedirectToAction("Index", new { query = gigsViewModel.SearchTerm });
        }

        //GET: THE DETAILS OF A GIG
        [Authorize]
        public ActionResult Details(int gigID)
        {
            var gig = unitOfWork.GigsRepository.GetGigForDetails(gigID);

            if (gig == null)
                return HttpNotFound("No gig was Found");

            var viewModel = new GigDetailsViewModel(gig, $"{gig.GigName}");

            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();

                viewModel.ShowActions = true;

                viewModel.isFavourited = unitOfWork.FavouriteGigRepository.GetFavouriteGig(gigID, userId) != null;

                viewModel.isFollowing = unitOfWork.FavouriteInfluencerRepository.GetFavouriteInfluencer(gig.InfluencerID, userId) != null;
            }

            return View("Details", viewModel);
        }

        // GET: ALL GIGS
        public ActionResult Index(int? specificIndustryID, string query = null)
        {
            if (specificIndustryID == null && String.IsNullOrEmpty(query))
            {
                // SEND IT ELSEWHERE
                return RedirectToAction("Mine");
            }

            var gigs = unitOfWork.GigsRepository.GetGigsForIndexWithSearch(specificIndustryID, query);

            // SEND GIGS TO THE VIEW
            var viewModel = new GigsViewModel(gigs, User.Identity.IsAuthenticated,
                specificIndustryID == null ? $"Following Gigs were Found" : $"All {unitOfWork.SpecificIndustryRepository.GetSpecificIndustry(specificIndustryID).Name} Gigs", query);

            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();

                viewModel.FavouriteGigs = unitOfWork.FavouriteGigRepository.GetFavouriteGigs(userId)
                    .ToList()
                    .ToLookup(f => f.GigID);

                viewModel.FavouriteInfluencers = unitOfWork.FavouriteInfluencerRepository.GetFavouriteInfluencers(userId)
                    .ToList()
                    .ToLookup(f => f.InfluencerID);
            }

            //SEND THE SORTED LIST TO THE VIEW
            return View(viewModel);
        }               

        // MY POSTED GIGS
        [Authorize]
        public ActionResult Mine()
        {
            var userId = User.Identity.GetUserId();

            var gigs = unitOfWork.GigsRepository.GetGigsForMine(userId);            

            // CREATE THE VIEW THAT WE WILL SEND
            var viewModel = new GigsViewModel(gigs, User.Identity.IsAuthenticated,
               $"All {ApplicationUser.FullName(unitOfWork.ApplicationUserRepository.GetUser(userId))} Gigs", null);

            // SEND GIGS TO THE VIEW          
            return View(viewModel);
        }

        // MY FAVOURITE GIGS
        [Authorize]
        public ActionResult Favourites()
        {
            var userId = User.Identity.GetUserId();

            var gigs = unitOfWork.FavouriteGigRepository.GetFavouriteGigsFullInfo(userId);

            // CREATE THE VIEW THAT WE WILL SEND
            var viewModel = new GigsViewModel(gigs, User.Identity.IsAuthenticated,
               "My Favorite Gigs", null);

            if (User.Identity.IsAuthenticated)
            {
                viewModel.FavouriteGigs = unitOfWork.FavouriteGigRepository.GetFavouriteGigs(userId)
                    .ToList()
                    .ToLookup(f => f.GigID);

                viewModel.FavouriteInfluencers = unitOfWork.FavouriteInfluencerRepository.GetFavouriteInfluencers(userId)
                    .ToList()
                    .ToLookup(f => f.InfluencerID);
            }

            // SEND GIGS TO THE VIEW          
            return View("Index", viewModel);
        }

        // GET: Gig
        public ActionResult Create()
        {
            // CREATE VIEW MODEL TO SEND IT TO THE VIEW
            var viewModel = GigFormViewModel.CreateFormViewModel(null, unitOfWork.SpecificIndustryRepository.GetSpecificIndustries().ToList(), "Create New Gig", "Save");

            return View("GigForm", viewModel);
        }

        //GET: GIG FOR EDIT
        [Authorize]
        public ActionResult Edit(int gigID)
        {
            var userId = User.Identity.GetUserId();

            // BRING GIG FROM DB WITH ALL ITS FOLLOWINGS
            var gig = unitOfWork.GigsRepository.GetGigForForm(gigID);

            //CHECK IF THE GIG EXIST
            if (gig == null)
                return HttpNotFound();

            if(gig.UserID != userId)
                return new HttpUnauthorizedResult();

            var viewModel = GigFormViewModel.CreateFormViewModel(gig, unitOfWork.SpecificIndustryRepository.GetSpecificIndustries().ToList(), "Update your Gig", "Update");

            // GO TO CREATE VIEW
            return View("GigForm", viewModel);
        }

        //POST: ADD A GIG, OR SEND FOR UPDATE - DELETE
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GigFormViewModel gigFormViewModel, HttpPostedFileBase upload)
        {
            // CHECK IF MODEL IS VALID
            if (!ModelState.IsValid)
                return View(gigFormViewModel);

            var userId = User.Identity.GetUserId();
            // CREATE NEW GIG

            //Create a Basic Selling Package
            var basicPackage = new BasicPackage(gigFormViewModel);
            unitOfWork.BasicPackageRepository.AddBasicPackage(basicPackage);

            //Create an Advanced Selling Package
            var advancedPackage = new AdvancedPackage(gigFormViewModel);
            unitOfWork.AdvancedPackageRepository.AddAdvancedPackage(advancedPackage);

            //Create a Premium Selling Package
            var premiumPackage = new PremiumPackage(gigFormViewModel);
            unitOfWork.PremiumPackageRepository.AddPremiumPackage(premiumPackage);

            //Get the user Id in order to bind everything together
            var infleuncer = unitOfWork.InfluencerRepository.GetInfluencerForUser(userId);
            if (infleuncer == null)
                return HttpNotFound();

            // Create a Gig                    
            var gig = new Gig(gigFormViewModel, userId, infleuncer.ID);


            //IF THERE IS NEW FILE UPLOADED
            if (upload != null && upload.ContentLength > 0)
            {
                //WE WILL CREATE A NEW FILE WITH THE TYPE OF AVATAR (THIS IS WHAT I NEED HERE)
                var background = FileUpload.GiveGigBackground(System.IO.Path.GetFileName(upload.FileName), upload.ContentType, null, FileType.Photo, gig.ID);

                //BLACK MAGIC
                using (var reader = new System.IO.BinaryReader(upload.InputStream))
                {
                    background.Content = reader.ReadBytes(upload.ContentLength);
                }

                // GIVE INFLUENCER THE LIST OF FILES WITH THE AVATAR FILE
                gig.FileUploads = new List<FileUpload> { background };
            }

            unitOfWork.GigsRepository.AddGig(gig);

            unitOfWork.Complete();

            // WHEN EVERYTHING IS DONE GO TO INDEX
            return RedirectToAction("Index");
        }

        //POST: UPDATE A GIG
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(GigFormViewModel updatedViewModel, HttpPostedFileBase upload)
        {
            var userId = User.Identity.GetUserId();

            //GET THE EXISTING GIG FOR UPDATE
            var gigDB = unitOfWork.GigsRepository.GetGigForForm(updatedViewModel.GigID);

            //CHECK IF THE GIG EXIST
            if (gigDB == null)
                return HttpNotFound();

            if (gigDB.UserID != userId)
                return new HttpUnauthorizedResult();

            gigDB.Modify(updatedViewModel);

            // IF THERE IS MEW FILE UPLOADED THEN WE WILL DELETE THE GIG FILE FOR NACKGROUND FROM HIS FILES
            if (upload != null && upload.ContentLength > 0)
            {
                if (gigDB.FileUploads.Any(f => f.FileType == FileType.Photo))
                    unitOfWork.FileUploadRepository.RemoveGigPhotoFileUpload(gigDB);

                // THEN WE WILL CREATE NEW FILE AND GIVE IT TO THE USER
                var background = FileUpload.GiveGigBackground(System.IO.Path.GetFileName(upload.FileName), upload.ContentType, null, FileType.Photo, gigDB.ID);

                // BLACK MAGIC
                using (var reader = new System.IO.BinaryReader(upload.InputStream))
                {
                    background.Content = reader.ReadBytes(upload.ContentLength);
                }

                // WE ADD THE LIST WITH THE NEW AVATAR FILE TO THE INFLUENCER LIST
                gigDB.FileUploads = new List<FileUpload> { background };
            }

            // GO TO DB AND SAVE CHANGES
            unitOfWork.Complete();

            // WHEN EVERYTHING IS DONE GO TO INDEX
            return RedirectToAction("Index");
        }

        ////DELETE: DELETE A GIG
        //[Authorize]
        //[HttpDelete]
        //[ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(GigFormViewModel gigFormViewModel)
        //{
        //    // BRING THE GIG FROM DB WITH ITS CONTAININGS
        //    var gig = context.Gigs
        //    .Include(g => g.BasicPackage)
        //    .Include(g => g.AdvancedPackage)
        //    .Include(g => g.PremiumPackage)
        //    .Include(i => i.FileUploads)
        //    .SingleOrDefault(g => g.ID == gigFormViewModel.GigID);

        //    // CHECK IF GIG EXIST
        //    if (gig == null)
        //        return HttpNotFound();

        //    // INITIALIZE THE OTHER ENTITIES FOR DELATION
        //    var basicPackage = gig.BasicPackage;
        //    var advancedPackage = gig.AdvancedPackage;
        //    var premiumPackage = gig.PremiumPackage;

        //    // DELETE EVERYTHING RELATED TO THE GIG
        //    context.Gigs.Remove(gig);
        //    context.BasicPackages.Remove(basicPackage);
        //    context.AdvancedPackages.Remove(advancedPackage);
        //    context.PremiumPackages.Remove(premiumPackage);

        //    // GO TO DB AND SAVE CHANGES
        //    context.SaveChanges();

        //    // WHEN EVERYTHING IS DONE GO TO INDEX
        //    return RedirectToAction("Index");
        //}
    }
}