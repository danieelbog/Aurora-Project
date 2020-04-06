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
    [Authorize]
    public class InfluencerController : Controller
    {
        private ApplicationDbContext context;
        public InfluencerController()
        {
            context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }
        //GET: Influencer
        public ActionResult MineInfluencers()
        {
            var userId = User.Identity.GetUserId();

            var influencers = context.FavouriteInfluencers
                .Where(f => f.FollowerID == userId)
                .Select(f => f.Influencer).Include(i => i.Files)
                .Include(f => f.User)
                .Include(f => f.User.Gigs)
                .ToList();

            return View("MineInfluencers", influencers);
        }


        // GET: Details (MY PROFILE)
        public ActionResult Details()
        {
            var userId = User.Identity.GetUserId();
            var influencer = context.Influencers
                .Include(i => i.MembershipType)
                .Include(i => i.Files)
                .Include(i => i.User)
                .SingleOrDefault(i => i.User.Id == userId);

            //CHECK IF THE INFLUENCER EXIST
            if (influencer == null)
            {
                return RedirectToAction("Create");
            }
            else
            {
                var viewModel = InfluencerFormViewModel.CreateFormViewModel(influencer, context.MembershipTypes.ToList(), "My Profile", null, ApplicationUser.FullName(influencer.User));

                //TESIGN FILE
                viewModel.Files = influencer.Files;


                return View("MyProfile", viewModel);
            }
        }


        // GET: Create
        public ActionResult Create()
        {
            //GETTING USER ID
            var userId = User.Identity.GetUserId();

            // GETTING THE USER'S INFLUENCER
            var influencer = context.Influencers
                .Include(i => i.User)
                .Include(i => i.Files)
                .SingleOrDefault(i => i.User.Id == userId);

            // IF THE INFLUENCER ID IS NULL THEN WE WILL SEND IT TO THE CREATE
            if (influencer == null)
            {
                var viewModel = InfluencerFormViewModel.CreateFormViewModel(influencer, context.MembershipTypes.ToList(), "Add new Influencer", "Add", null);
                return View("InfluencerForm", viewModel);
            }
            // ELSE WE WILL UPLOAD ALL HIS PROPERTIES AND SEND THE VIEW MODEL TO CREATE FOR UPDATE
            else
            {
                var viewModel = InfluencerFormViewModel.CreateFormViewModel(influencer, context.MembershipTypes.ToList(), "Edit Influencer Info", "Update", null);
                return View("InfluencerForm", viewModel);
            }

        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InfluencerFormViewModel viewModel, HttpPostedFileBase upload)
        {
            // BAD SCENARIO IF THE MODEL IS INVALID
            if (!ModelState.IsValid)
            {
                //viewModel.MembershipTypes = context.MembershipTypes.ToList();
                return RedirectToAction("Create");
            }
            
            // GET USER ID AND USER
            var userId = User.Identity.GetUserId();
            var user = context.Users
                .Include(u => u.Wallet)
                .Single(u => u.Id == userId);

            var auroraWallet = context.AuroraWallets.Single(a => a.ID == 1);
            if (auroraWallet == null)
                return HttpNotFound();

            // THIS TRY CATCH CHECKS IF THE PAYMENT CAN BE DONE, AND IN GENERAL IF SOMETHING GOES WRONG
            try
            {
                //CREATE THE INFLUENCER
                var influencer = Influencer.CreateInflunecerWithPayment(viewModel, user, auroraWallet);

                if (upload != null && upload.ContentLength > 0)
                {

                    var avatar = new File(System.IO.Path.GetFileName(upload.FileName), upload.ContentType, null, FileType.Avatar, influencer.ID);

                    //var avatar = new File()
                    //{
                    //    FileName = System.IO.Path.GetFileName(upload.FileName),
                    //    FileType = FileType.Avatar,
                    //    ContentType = upload.ContentType
                    //};

                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        avatar.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    influencer.Files = new List<File> { avatar };
                }

                context.Influencers.Add(influencer);
                // SAVE CHANGES TO DB
                context.SaveChanges();
            }
            catch (Exception)
            {
                return RedirectToAction("Create");
            }

            // REDIRECT TO ADD A GIG (USER EXPIRIENCE)
            return RedirectToAction("Create", "Gig", null);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Update(InfluencerFormViewModel viewModel)
        {
            // REFACTOR V1        
            var userId = User.Identity.GetUserId();

            var influencerDb = context.Influencers
                .Include(i => i.MembershipType)
                .Include(i => i.User)
                .Include(i => i.User.Wallet)
                .Include(i => i.Files)
                .SingleOrDefault(i => i.ID == viewModel.ID && i.User.Id == userId);
            if (influencerDb == null)
                return HttpNotFound();

            var auroraWallet = context.AuroraWallets.Single(a => a.ID == 1);
            if (auroraWallet == null)
                return HttpNotFound();

            // THIS TRY CATCH CHECKS IF THE PAYMENT CAN BE DONE, AND IN GENERAL IF SOMETHING GOES WRONG
            try
            {
                influencerDb.Modify(viewModel, influencerDb, auroraWallet);
            }
            catch (Exception)
            {
                return RedirectToAction("Update", viewModel);
            }

            // SAVE CHANGES TO DB
            context.SaveChanges();

            // REDIRECT TO ADD A GIG (USER EXPIRIENCE)
            return RedirectToAction("Create", "Gig", null);
        }
    }
}