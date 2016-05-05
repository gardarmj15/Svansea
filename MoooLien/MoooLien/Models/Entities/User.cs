using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoooLien.Models.Entities
{
    public class User
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string authorization { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int SNN { get; set; }
        public string email { get; set; }
    }
}