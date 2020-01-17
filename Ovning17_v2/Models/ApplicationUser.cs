using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ovning17_v2.Models
{
    public class ApplicationUser : IdentityUser
    {
        public IEnumerable<ApplicationUserGymClass> AttendedClasses { get; set; }
    }
}
