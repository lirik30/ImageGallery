using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ImageGallery.ORM;

namespace ImageGallery.Services
{
    public class ImageService
    {
        private readonly DbContext _context = new ImagesContext();

        public IEnumerable<ImageEntity> GetAllImages()
        {
            return _context.Set<ImageEntity>();
        }

        public ImageEntity GetImageById(int id)
        {
            return _context.Set<ImageEntity>().SingleOrDefault(i => i.Id == id);
        }

        public void Create(ImageEntity image)
        {
            _context.Set<ImageEntity>().Add(image);
            _context.SaveChanges();
        }
    }
}