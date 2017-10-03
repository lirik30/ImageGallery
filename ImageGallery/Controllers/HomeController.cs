using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImageGallery.Models;

namespace ImageGallery.Controllers
{
    public class HomeController : Controller
    {
        private readonly List<ImageViewModel> _images = new List<ImageViewModel>();

        public HomeController()
        {
            _images.Add(new ImageViewModel
            {
                Path = "http://images4.fanpop.com/image/polls/688000/688167_1302700202936_full.jpg?v=1302701626"/*Server.MapPath("~/App_Data/Images/barniAndWine.jpg")*/,
                Description = ""}
            );
            _images.Add(new ImageViewModel
            {
                Path = "https://i.ytimg.com/vi/LyfT-kjD5Hg/maxresdefault.jpg",
                Description = ""
            });
            _images.Add(new ImageViewModel
            {
                Path = "http://4.bp.blogspot.com/-q9Wy2AQybsg/UQ9qFzJ_oeI/AAAAAAAAAbU/l6fq2_JWbCo/s1600/21c.jpg",
                Description = ""
            });
            _images.Add(new ImageViewModel
            {
                Path = "https://i.pinimg.com/736x/f7/a8/93/f7a89300a469ce4669cad445fc85fcfb--watercolour-paintings-watercolour-fox.jpg",
                Description = ""
            });
            _images.Add(new ImageViewModel
            {
                Path = "https://pp.userapi.com/c313330/v313330464/620a/cy2ylqLhS8A.jpg",
                Description = ""
            });
            _images.Add(new ImageViewModel
            {
                Path = "http://cdn.movieweb.com/img.news.tops/NE1l9J3ZbSjf43_1_b/It-Movie-Director-Pennywise-Details-Weird-New-Photos.jpg",
                Description = ""
            });
            _images.Add(new ImageViewModel
            {
                Path = "http://i.dailymail.co.uk/i/pix/2015/07/31/10/2AFC358800000578-0-image-a-17_1438333683477.jpg",
                Description = ""
            });
            _images.Add(new ImageViewModel
            {
                Path = "https://dingo.care2.com/pictures/greenliving/1407/1406075.large.jpg",
                Description = ""
            });
            _images.Add(new ImageViewModel
            {
                Path = "http://img0.liveinternet.ru/images/attach/c/0/40/101/40101492_1235391568_brut_star14_by_ma_zaika.jpg",
                Description = ""
            });
        }

        public ActionResult Index()
        {
            return View(_images);
        }   

        public ActionResult Image(string path)
        {
            return File(path, "image/jpg");
        }
    }
}