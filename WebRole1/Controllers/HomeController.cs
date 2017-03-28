using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pocketCloud;

namespace pocketCloud.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult Account()
        {
            ViewBag.Title = "Storage Account";
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Title = "Contact Page";
            return View();
        }
        FileStorageServices _fileStorageService = new FileStorageServices();
        public ActionResult Upload()
        {
            CloudBlobContainer.blobContainer = _fileStorageService.GetCloudBlobContainer();
            List<string> blobs = new List<string>();
            foreach (var blobItem in blobContainer.ListBlobs())
            {
                blobs.Add(blobItem.Uri.ToString());
            }
            return View(blobs);
        }
    }
    [HttpPost]
    public ActionResult Upload_Images(HttpPostedFileBase Images)
    {
        if (Images.ContentLength > 0)
        {   
            CloudBlobContainer blobContainer = FileStorageServices.GetCloudBlobContainer();
            CloudBlockBlob blob = blobContainer.GetBlockBlobReference(Images.FileName);
            blob.UploadFromStream(Images.InputStream);
        }
        return RedirectToAction("Upload");
    }

    [HttpPost]
    public string Delete_Images(string Name)
    {
        Uri uri = new Uri(Name);
        string filename = System.IO.Path.GetFileName(uri.LocalPath);
        CloudBlobContainer blobContainer = _fileStorageService.GetCloudContainer();
        CloudBlockBlob blob = blobContainer.GetBlockBlobReference(filename);
        blob.Delete();
        return "File Deleted";
    }
}
}