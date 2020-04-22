using AuroraProject.Core.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using AuroraProject.Persistence;
using AuroraProject.Core.DTO;
using AuroraProject.Core;

namespace AuroraProject.Controllers.API
{
    [Authorize]
    public class InfluencersController : ApiController
    {
        private readonly IUnitOfWork unitOfWork;
        public InfluencersController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        //UPDATE INFLUENCER - FROM MY PROFILE
        [HttpPut]
        public IHttpActionResult UpdateInfluencer(InfluencerDto influencerDto)
        {
            var userId = User.Identity.GetUserId();

            var influencerDb = unitOfWork.InfluencerRepository.GetInfluencerForUpdate(influencerDto.InfluencerID);
            if (influencerDb == null)
                return BadRequest();

            if (influencerDb.User.Id != userId)
                return Unauthorized();

            var auroraWallet = unitOfWork.AuroraWalletRepository.GetAuroraWallet();
            if (auroraWallet == null)
                return BadRequest();

            // THIS TRY CATCH CHECKS IF THE PAYMENT CAN BE DONE, AND IN GENERAL IF SOMETHING GOES WRONG            
            influencerDb.Modify(influencerDto, influencerDb, auroraWallet);


            // SAVE CHANGES TO DB
            unitOfWork.Complete();

            return Ok();
        }

    }
}
