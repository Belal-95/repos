using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CvMakerWebsiteApp.Models
{
    public class PhotoModel
    {
        public string FullName { get; set; }
        public HttpPostedFileWrapper ImageFile { get; set; }

    }
}