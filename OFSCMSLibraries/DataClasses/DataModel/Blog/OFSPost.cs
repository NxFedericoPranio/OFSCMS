using DataClasses.DataModel.Generic;
using DataClasses.DataModel.Pages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DataClasses.DataModel.Blog
{
    public class OFSPost : OFSPage
    {
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Content")]
        public string Content { get; set; }

        public ArrayList Categories { get; set; }
        public ArrayList Comments { get; set; }
    }
}
