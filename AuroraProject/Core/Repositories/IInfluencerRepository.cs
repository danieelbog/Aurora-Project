using AuroraProject.Core.Models;

namespace AuroraProject.Core.Repositories
{
    public interface IInfluencerRepository
    {
        void AddInfluencer(Influencer influencer);
        Influencer GetInfluencerForForm(string userId);
        Influencer GetInfluencerForUpdate(int influencerId);
        Influencer GetInfluencerForUser(string userId);
        void RemoveInfluencer(Influencer influencer);
    }
}