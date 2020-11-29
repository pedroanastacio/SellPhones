using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellPhones.Celulares.Web.Identity
{
    public class CelularIdentityDbContext : IdentityDbContext<IdentityUser>
    {
        public CelularIdentityDbContext()
            : base("CelularDbContext")
        {

        }
    }
}