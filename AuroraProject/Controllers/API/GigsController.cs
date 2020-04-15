using AuroraProject.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using AuroraProject.Persistence;

namespace AuroraProject.Controllers.API
{
    [Authorize]
    public class GigsController : ApiController
    {
        private readonly IUnitOfWork unitOfWork;
        public GigsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        //POST: api/favourites
        [HttpPost]
        [Authorize]
        public IHttpActionResult Enable(int id)
        {
            var userId = User.Identity.GetUserId();

            var gig = unitOfWork.GigsRepository.GetGigForDetails(id);

            if (gig == null)
                return BadRequest("The Gig Was not Found");

            if (gig.UserID != userId)
                return Unauthorized();

            gig.Enable();

            unitOfWork.Complete();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Disable(int id)
        {
            var userId = User.Identity.GetUserId();

            var gig = unitOfWork.GigsRepository.GetGigForDetails(id);

            if (gig == null)
                return BadRequest("The Gig Was not Found");

            if (gig.UserID != userId)
                return Unauthorized();

            gig.Disable();

            unitOfWork.Complete();

            return Ok();
        }

    }
}
