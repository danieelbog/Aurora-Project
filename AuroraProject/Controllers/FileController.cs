using AuroraProject.Models;
using AuroraProject.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuroraProject.Controllers
{
    public class FileController : Controller
    {

        private readonly ApplicationDbContext context;
        private readonly UnitOfWork unitOfWork;
        public FileController()
        {
            context = new ApplicationDbContext();
            unitOfWork = new UnitOfWork(context);

        }

        // GET: File
        public ActionResult Index(int id)
        {
            var fileToRetrieve = unitOfWork.FileUploadRepository.GetFile(id);
            return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
        }
    }
}