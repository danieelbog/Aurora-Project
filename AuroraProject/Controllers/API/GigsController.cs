using AuroraProject.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;


namespace AuroraProject.Controllers.API
{
    [Authorize]
    public class GigsController : ApiController
    {
        private ApplicationDbContext context;
        public GigsController()
        {
            context = new ApplicationDbContext();
        }


        //POST: api/favourites
        [HttpPost]
        [Authorize]
        public IHttpActionResult Enable(int id)
        {
            var userId = User.Identity.GetUserId();

            var gig = context.Gigs.SingleOrDefault(g => g.ID == id);

            if (gig == null)
                return BadRequest("The Gig Was not Found");

            gig.Enable();

            context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Disable(int id)
        {
            var userId = User.Identity.GetUserId();
            var gig = context.Gigs
                .Include(g => g.Influencer)
                .Single(g => g.ID == id && g.UserID == userId && g.Influencer.User.Id == userId);

            gig.Disable();

            context.SaveChanges();

            return Ok();
        }

    }
}
