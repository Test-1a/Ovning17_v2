using Ovning17_v2.Models;
using System.Collections.Generic;

namespace Ovning17_v2.ViewModels
{
    public class IndexViewModel
    {
            public IEnumerable<GymClass> GymClasses { get; set; }

            public bool History { get; set; }
    }
}
