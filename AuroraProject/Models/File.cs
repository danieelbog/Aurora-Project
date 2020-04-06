using AuroraProject.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuroraProject.Models
{
    public enum FileType
    {
        Avatar = 1, Photo
    }
    public class File
    {
        public int FileId { get; set; }
        [StringLength(255)]
        public string FileName { get; set; }
        [StringLength(100)]
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public FileType FileType { get; set; }

        // RELATION WITH INFLUENCER
        public int InfluencerID { get; set; }
        public Influencer Influencer { get; set; }

        protected File()
        {

        }

        public File(string fileName, string contentType, byte[] content, FileType fileType, int influencerID)
        {
            FileName = fileName;
            ContentType = contentType;
            Content = content;
            FileType = fileType;
            InfluencerID = influencerID;
        }
    }
}