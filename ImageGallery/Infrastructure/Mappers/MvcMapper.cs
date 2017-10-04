using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImageGallery.Models;
using ImageGallery.ORM;

namespace ImageGallery.Infrastructure.Mappers
{
    public static class MvcMapper
    {
        public static ImageViewModel ToMvcImage(this ImageEntity image)
        {
            return new ImageViewModel
            {
                Id = image.Id,
                SmallSizeImage = image.SmallSizeImage,
                FullSizeImage = image.FullSizeImage,
                Description = image.Description
            };
        }

        public static ImageEntity ToOrmImage(this ImageViewModel image)
        {
            return new ImageEntity
            {
                Id = image.Id,
                SmallSizeImage = image.SmallSizeImage,
                FullSizeImage = image.FullSizeImage,
                Description = image.Description
            };
        }
    }
}