using MoooLien.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoooLien.Models.ViewModel
{
    public class UserViewModel
    {
        public List<ApplicationUser> users { get; set; }
        public List<string> userName { get; set; }
    }
}