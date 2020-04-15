using AuroraProject.Core;
using AuroraProject.Core.DTO;
using AuroraProject.Core.Models;
using AuroraProject.Persistence;
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
    public class FavouriteGigsController : ApiController
    {
        private readonly IUnitOfWork unitOfWork;
        public FavouriteGigsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        //FOLLOWER = ACTIONER
        //FOLOWEE = GIG

        //POST: api/favourites
        [HttpPost]
        [Authorize]
        public IHttpActionResult Favourite(FavouriteGigDto favouriteGigDto)
        {
            var userId = User.Identity.GetUserId();

            if (unitOfWork.FavouriteGigRepository.GetFavouriteGigs(userId).Any(f => f.ActionerID == userId && f.GigID == favouriteGigDto.GigID))
                return BadRequest("You already have it in your favourites");

            var favorite = new FavouriteGig
            {
                ActionerID = userId,
                GigID = favouriteGigDto.GigID
            };

            unitOfWork.FavouriteGigRepository.AddFavouriteGig(favorite);
            unitOfWork.Complete();

            return Ok();
        }

        [HttpDelete]
        [Authorize]
        public IHttpActionResult DeleteFavourite(FavouriteGigDto favouriteGigDto)
        {
            var userId = User.Identity.GetUserId();

            var favorite = unitOfWork.FavouriteGigRepository.GetFavouriteGig(favouriteGigDto.GigID, userId);

            if (favorite == null)
                return NotFound();

            unitOfWork.FavouriteGigRepository.RemoveFavouriteGig(favorite);
            unitOfWork.Complete();

            return Ok(favorite.GigID);
        }
    }
}
