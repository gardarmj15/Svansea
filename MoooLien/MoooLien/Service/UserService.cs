﻿using MoooLien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoooLien.Service
{
    public class UserService
    {
        private ApplicationDbContext db;
        public UserService()
        {
            db = new ApplicationDbContext();
        }

        
    }
}