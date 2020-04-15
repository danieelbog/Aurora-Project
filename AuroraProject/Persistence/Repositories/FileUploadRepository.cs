using AuroraProject.Core.Models;
using AuroraProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuroraProject.Persistence.Repositories
{
    public class FileUploadRepository : IFileUploadRepository
    {
        private readonly ApplicationDbContext _context;
        public FileUploadRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public FileUpload GetFile(int id)
        {
            return _context.FileUploads.Find(id);
        }

        public void RemoveGigPhotoFileUpload(Gig gigDB)
        {
            var file = _context.FileUploads.Remove(gigDB.FileUploads.First(f => f.FileType == FileType.Photo));

            _context.FileUploads.Remove(file);
        }

        public void RemoveGigAvatarFileUpload(Influencer influencerDb)
        {
            var file = _context.FileUploads.Remove(influencerDb.FileUploads.First(f => f.FileType == FileType.Avatar));

            _context.FileUploads.Remove(file);
        }


    }
}