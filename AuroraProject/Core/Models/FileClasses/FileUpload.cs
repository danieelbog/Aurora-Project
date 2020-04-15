using AuroraProject.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuroraProject.Core.Models
{
    public enum FileType
    {
        Avatar = 1, Photo
    }
    public class FileUpload
    {
        public int ID { get; set; }
        [StringLength(255)]
        public string FileName { get; set; }
        [StringLength(100)]
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public FileType FileType { get; set; }

        // RELATION WITH INFLUENCER
        public int? InfluencerID { get; set; }
        public Influencer Influencer { get; set; }

        // RELATION WITH INFLUENCER
        public int? GigID { get; set; }
        public Gig Gig { get; set; }

        protected FileUpload()
        {

        }

        private FileUpload(string fileName, string contentType, byte[] content, FileType fileType)
        {
            FileName = fileName;
            ContentType = contentType;
            Content = content;
            FileType = fileType;
        }

        public static FileUpload GiveInfluencerAvatar(string fileName, string contentType, byte[] content, FileType fileType, int influencerId)
        {
            var avatar = new FileUpload(fileName, contentType, content, fileType);
            avatar.InfluencerID = influencerId;

            return avatar;
        }

        public static FileUpload GiveGigBackground(string fileName, string contentType, byte[] content, FileType fileType, int gigId)
        {
            var background = new FileUpload(fileName, contentType, content, fileType);
            background.GigID = gigId;

            return background;
        }

    }
}