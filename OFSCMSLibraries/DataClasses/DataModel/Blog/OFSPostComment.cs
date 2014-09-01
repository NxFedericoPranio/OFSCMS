using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DataClasses.DataModel.Blog
{
    public class OFSPostComment
    {

        [Required]
        [Display(Name = "Content")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Content")]
        public string Comment { get; set; }

        [Required]
        [Display(Name = "Content")]
        public string Email { get; set; }

        [Display(Name = "Content")]
        public string WebSite { get; set; }

        public string IPAddress { get; set; }
        public bool Approved { get; set; }
        public bool Banned { get; set; }
    }
}
