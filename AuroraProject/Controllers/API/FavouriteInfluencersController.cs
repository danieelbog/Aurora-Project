using AuroraProject.DTO;
using AuroraProject.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AuroraProject.Controllers.API
{
    [Authorize]
    public class FavouriteInfluencersController : ApiController
    {
        private ApplicationDbContext context;
        public FavouriteInfluencersController()
        {
            context = new ApplicationDbContext();
        }

        //FOLLOWER = USER
        //FOLOWEE = INFLUENCER
        // POST: api/favoriteInfluencers
        [HttpPost]
        public IHttpActionResult Follow(FavouriteInfluencerDto favouriteInfluencerDto)
        {
            var userId = User.Identity.GetUserId();

            if (context.FavouriteInfluencers.Any(f => f.FollowerID == userId && f.InfluencerID == favouriteInfluencerDto.InfluencerID))
                return BadRequest("You already have this Influencer in your favourites");

            var favorite = new FavouriteInfluencer
            {
                FollowerID = userId,
                InfluencerID = favouriteInfluencerDto.InfluencerID
            };

            context.FavouriteInfluencers.Add(favorite);
            context.SaveChanges();

            return Ok();
        }
    }
}
