using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using ImageGallery.Infrastructure.Mappers;
using ImageGallery.Models;
using ImageGallery.Services;

namespace ImageGallery.Controllers
{
    public class HomeController : Controller
    {
        private readonly ImageService _service = new ImageService();
        private int _imageNumbers = 4;

        public ActionResult Index()
        {
            if (TempData.Peek("ImagesWhenNotAjax") == null)
            {
                Debug.WriteLine("________________");
                TempData["ImagesWhenNotAjax"] = _service.GetAllImages().Take(_imageNumbers).
                    Select(i => i.ToMvcImage());
            }
                
            ViewBag.NumberOfImages = (int)Math.Ceiling((decimal)_service.GetAllImages().Count() / _imageNumbers);
            return View();
        }

        [HttpGet]
        public ActionResult AddImage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddImage(string description, HttpPostedFileBase[] uploadImages)
        {
            if (uploadImages != null)
            {
                foreach (var uploadImage in uploadImages)
                {
                    byte[] fullSizeImage;
                    using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                    {
                        fullSizeImage = binaryReader.ReadBytes(uploadImage.ContentLength);
                    }

                    var smallSizeImage = new WebImage(fullSizeImage).Resize(240, 285).GetBytes();
                    var image = new ImageViewModel
                    {
                        SmallSizeImage = smallSizeImage,
                        FullSizeImage = fullSizeImage,
                        Description = description??"NoDescription"
                    };

                    _service.Create(image.ToOrmImage());
                }
            }
            return RedirectToAction("Index");
        }
        
        public ActionResult List(int index = 1)
        {
            var images = _service.GetAllImages().Skip((index - 1) * _imageNumbers).Take(_imageNumbers)
                .Select(i => i.ToMvcImage());

            if (!Request.IsAjaxRequest())
            {
                Debug.WriteLine("_______________________");
                TempData["ImagesWhenNotAjax"] = images;
                return RedirectToAction("Index");
            }
            
            return PartialView("_GalleryItem", images);
        }
        
        public ActionResult SmallSizeImage(int id)
        {
            var image = _service.GetImageById(id).ToMvcImage();
            return File(image.SmallSizeImage, "image/jpg");
        }

        public ActionResult FullSizeImage(int id)
        {
            var image = _service.GetImageById(id).ToMvcImage();
            return File(image.FullSizeImage, "image/jpg");
        }
    }
}