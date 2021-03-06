﻿using Mooolien.Models;
using System.ComponentModel.DataAnnotations;

namespace MoooLien.Models
{
    public class FilePath
    {
        public int FilePathId { get; set; }
        [StringLength(255)]
        public string FileName { get; set; }
        public FileType FileType { get; set; }
        public int PersonID { get; set; }
        //public virtual Person Person { get; set; }
    }
}