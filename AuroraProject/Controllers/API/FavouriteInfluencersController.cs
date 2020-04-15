﻿using AuroraProject.Core;
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
    public class FavouriteInfluencersController : ApiController
    {
        private readonly IUnitOfWork unitOfWork;
        public FavouriteInfluencersController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        //FOLLOWER = USER
        //FOLOWEE = INFLUENCER
        // POST: api/favoriteInfluencers
        [HttpPost]
        public IHttpActionResult Follow(FavouriteInfluencerDto favouriteInfluencerDto)
        {
            var userId = User.Identity.GetUserId();

            if (unitOfWork.FavouriteInfluencerRepository.GetFavouriteInfluencers(userId).Any(f => f.FollowerID == userId && f.InfluencerID == favouriteInfluencerDto.InfluencerID))
                return BadRequest("You already have this Influencer as your favourite");

            var favorite = new FavouriteInfluencer
            {
                FollowerID = userId,
                InfluencerID = favouriteInfluencerDto.InfluencerID
            };

            unitOfWork.FavouriteInfluencerRepository.AddFavouriteInfluencer(favorite);
            unitOfWork.Complete();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteFollow(FavouriteInfluencerDto favouriteInfluencerDto)
        {
            var userId = User.Identity.GetUserId();

            var favorite = unitOfWork.FavouriteInfluencerRepository.GetFavouriteInfluencer(favouriteInfluencerDto.InfluencerID, userId);

            if (favorite == null)
                return NotFound();

            unitOfWork.FavouriteInfluencerRepository.RemoveFavouriteInfluencer(favorite);
            unitOfWork.Complete();

            return Ok(favouriteInfluencerDto.InfluencerID);
        }
    }
}
