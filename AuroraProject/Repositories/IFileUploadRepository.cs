using AuroraProject.Models;

namespace AuroraProject.Repositories
{
    public interface IFileUploadRepository
    {
        FileUpload GetFile(int id);
        void RemoveGigAvatarFileUpload(Influencer influencerDb);
        void RemoveGigPhotoFileUpload(Gig gigDB);
    }
}