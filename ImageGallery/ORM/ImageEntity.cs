using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageGallery.ORM
{
    public class ImageEntity
    {
        public int Id { get; set; }
        public byte[] SmallSizeImage { get; set; }
        public byte[] FullSizeImage { get; set; }
        public string Description { get; set; }
    }
}