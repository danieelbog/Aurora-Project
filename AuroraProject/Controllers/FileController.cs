using AuroraProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuroraProject.Controllers
{
    public class FileController : Controller
    {
        private ApplicationDbContext context;
        public FileController()
        {
            context = new ApplicationDbContext();
        }

        // GET: File
        public ActionResult Index(int id)
        {
            var fileToRetrieve = context.FileUploads.Find(id);
            return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
        }
    }
}