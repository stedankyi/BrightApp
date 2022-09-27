using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrightApp.Shared
{
    public class Bleet
    {
        public int Id { get; set; }
        public string BleetTitle { get; set; } = string.Empty;
        public string CreatorUsername { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public string BleetText { get; set; } = string.Empty;
        //public string BleetURL { get; set; } = string.Empty;
    }
}
