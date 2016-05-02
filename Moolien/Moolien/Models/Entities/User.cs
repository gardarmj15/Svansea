using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Moolien.Models.Entities
{
    public class User
    {
        private int ID { get; set; }
        private string authorization { get; set; }
        private string username { get; set; }
        private string password { get; set; }
        private string name { get; set; }
        private int SNN { get; set; }
        private string email { get; set; }
    }
}