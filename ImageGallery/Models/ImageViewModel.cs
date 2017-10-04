using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageGallery.Models
{
    public class ImageViewModel
    {
        public int Id { get; set; }
        public byte[] SmallSizeImage { get; set; }
        public byte[] FullSizeImage { get; set; }
        public string Description { get; set; }
    }
}