using Moolien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Moolien.Services
{
    public class SubmissionService
    {
        private ApplicationDbContext _db;
        public SubmissionService()
        {
            _db = new ApplicationDbContext();
        }
    }
}