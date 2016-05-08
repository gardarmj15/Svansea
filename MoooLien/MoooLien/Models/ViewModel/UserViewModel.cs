using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoooLien.Models.ViewModel
{
    public class UserViewModel
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public string username { get; set; }
        public string email { get; set; }
    }
}