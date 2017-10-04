using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ImageGallery.ORM
{
    public class ImagesContext: DbContext
    {
        public ImagesContext() : base("name=ImagesContext") { }

        private DbSet<ImageEntity> Images { get; set; }
    }
}