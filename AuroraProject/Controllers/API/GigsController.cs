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

        [HttpDelete]
        public IHttpActionResult Disable(int id)
        {
            var userId = User.Identity.GetUserId();
            var gig = context.Gigs
                .Include(g => g.Influencer)
                .Single(g => g.ID == id && g.UserID == userId && g.Influencer.User.Id == userId);

            if (gig.IsDisabled)
                gig.Enable();
            else
                gig.Disable();

            context.SaveChanges();

            return Ok();
        }
    }
}
