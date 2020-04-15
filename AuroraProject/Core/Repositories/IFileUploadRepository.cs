using AuroraProject.Core.Models;

namespace AuroraProject.Core.Repositories
{
    public interface IFileUploadRepository
    {
        FileUpload GetFile(int id);
        void RemoveGigAvatarFileUpload(Influencer influencerDb);
        void RemoveGigPhotoFileUpload(Gig gigDB);
    }
}