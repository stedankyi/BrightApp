using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrightApp.Shared
{
    public class Bleet
    {
        public int Id { get; set; }

        [Required]
        [StringLength(64, ErrorMessage = "Bleet Title cannot be more than 64 characters")]
        public string BleetTitle { get; set; } = string.Empty;

        public string CreatorUsername { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        [Required]
        [StringLength(280, ErrorMessage = "Bleet cannot be more than 280 characters")]
        public string BleetText { get; set; } = string.Empty;
        //public string BleetURL { get; set; } = string.Empty;
    }
}
