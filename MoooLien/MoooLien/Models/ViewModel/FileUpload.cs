using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 
        namespace FileUpload.ViewModel
{
    public class FileUploadViewModel
    {
        public IEnumerable<HttpPostedFileBase> File { get; set; }
    }
}