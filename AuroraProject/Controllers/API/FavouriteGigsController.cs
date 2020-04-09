﻿using AuroraProject.DTO;
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
    public class FavouriteGigsController : ApiController
    {
        private ApplicationDbContext context;
        public FavouriteGigsController()
        {
            context = new ApplicationDbContext();
        }

        //FOLLOWER = ACTIONER
        //FOLOWEE = GIG

        //POST: api/favourites
        [HttpPost]
        [Authorize]
        public IHttpActionResult Favourite(FavouriteGigDto favouriteGigDto)
        {
            var userId = User.Identity.GetUserId();

            if (context.FavouriteGigs.Any(f => f.ActionerID == userId && f.GigID == favouriteGigDto.GigID))
                return BadRequest("You already have it in your favourites");

            var favorite = new FavouriteGig
            {
                ActionerID = userId,
                GigID = favouriteGigDto.GigID
            };

            context.FavouriteGigs.Add(favorite);
            context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        [Authorize]
        public IHttpActionResult DeleteFavourite(FavouriteGigDto favouriteGigDto)
        {
            var userId = User.Identity.GetUserId();

            var favorite = context.FavouriteGigs
                .SingleOrDefault(a => a.GigID == favouriteGigDto.GigID && a.ActionerID == userId);

            if (favorite == null)
                return NotFound();

            context.FavouriteGigs.Remove(favorite);
            context.SaveChanges();

            return Ok(favorite.GigID);
        }
    }
}
