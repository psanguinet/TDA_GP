using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApp.Helper
{
    public static class HelperImage
    {
        public static string ImagesConvert(byte[] image)
        {
            string imageBase64Data = string.Empty;
            if (image != null)
            {
                imageBase64Data = Convert.ToBase64String(image.ToArray());
            }
            else
            {
                string path = Path.Combine(HttpContext.Current.Server.MapPath("~/Images/"), "no_image.jpg");
                byte[] imageByteData = System.IO.File.ReadAllBytes(path);
                imageBase64Data = Convert.ToBase64String(imageByteData);
            }
            string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
            return imageDataURL;
        }
    }
}