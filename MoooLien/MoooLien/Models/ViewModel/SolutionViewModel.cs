using MoooLien.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoooLien.Models.ViewModel
{
    public class SolutionViewModel
    {
        public List<Solution> solutions { get; set; }
        public Solution solution { get; set; }
    }
}