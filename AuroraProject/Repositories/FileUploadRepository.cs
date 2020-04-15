using AuroraProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuroraProject.Repositories
{
    public class FileUploadRepository
    {
        private readonly ApplicationDbContext _context;
        public FileUploadRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddFileUpload(FileUpload fileUpload)
        {
            _context.FileUploads.Add(fileUpload);
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