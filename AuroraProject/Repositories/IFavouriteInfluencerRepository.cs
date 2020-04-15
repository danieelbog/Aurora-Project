﻿using AuroraProject.Models;
using System.Collections.Generic;

namespace AuroraProject.Repositories
{
    public interface IFavouriteInfluencerRepository
    {
        void AddFavouriteInfluencer(FavouriteInfluencer favouriteInfluencer);
        FavouriteInfluencer GetFavouriteInfluencer(int influencerId, string userId);
        IEnumerable<FavouriteInfluencer> GetFavouriteInfluencers(string userId);
        IEnumerable<Influencer> GetFavouriteInfluencersWithProperties(string userId);
        void RemoveFavouriteInfluencer(FavouriteInfluencer favouriteInfluencer);
    }
}