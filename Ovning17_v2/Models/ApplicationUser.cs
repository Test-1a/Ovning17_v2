using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;    //[Required] etc
using System.Linq;
using System.Threading.Tasks;

namespace Ovning17_v2.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public DateTime TimeOfRegistration { get; set; }


        public IEnumerable<ApplicationUserGymClass> AttendedClasses { get; set; }
    }
}
