using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ovning17_v2.Models
{
    public class ApplicationUserGymClass
    {
        //Foreign keys
        public int GymClassId { get; set; }
 
        //string, not int because AppUser inherits of IdentityUser which takes a string
        public string ApplicationUserId { get; set; }



        //NavigationProperties
        public GymClass GymClass { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
