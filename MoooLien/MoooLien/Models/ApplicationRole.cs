﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class ApplicationRole : IdentityRole
{
    public ApplicationRole() : base() { }
    public ApplicationRole(string name) : base(name) { }
    public string Description { get; set; }

}