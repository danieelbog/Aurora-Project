using AuroraProject.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using AuroraProject.DTO;

namespace AuroraProject.Controllers.API
{
    [Authorize]
    public class InfluencersController : ApiController
    {
        private ApplicationDbContext context;

        public InfluencersController()
        {
            context = new ApplicationDbContext();
        }

        [HttpPut]
        public IHttpActionResult UpdateInfluencer(InfluencerDto influencerDto)
        {
            var userId = User.Identity.GetUserId();

            var influencerDb = context.Influencers
                .Include(i => i.MembershipType)
                .Include(i => i.User)
                .Include(i => i.User.Wallet)
                .SingleOrDefault(i => i.ID == influencerDto.InfluencerID && i.User.Id == userId);
            if (influencerDb == null)
                return BadRequest();

            var auroraWallet = context.AuroraWallets.Single(a => a.ID == 1);
            if (auroraWallet == null)
                return BadRequest();

            // THIS TRY CATCH CHECKS IF THE PAYMENT CAN BE DONE, AND IN GENERAL IF SOMETHING GOES WRONG            
            influencerDb.Modify(influencerDto, influencerDb, auroraWallet);


            // SAVE CHANGES TO DB
            context.SaveChanges();

            return Ok();
        }

    }
}
