using AuroraProject.Core;
using AuroraProject.Core.Models;
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

        private readonly IUnitOfWork unitOfWork;
        public FileController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: File
        public ActionResult Index(int id)
        {
            var fileToRetrieve = unitOfWork.FileUploadRepository.GetFile(id);
            return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
        }
    }
}