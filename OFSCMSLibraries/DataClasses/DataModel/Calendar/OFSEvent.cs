using DataClasses.DataModel.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DataClasses.DataModel.Calendar
{
    public enum RepeatFrequency
    {
        Once,
        Daily,
        Weekly,
        Montly,
        Yearly
    }

    [XmlRootAttribute("ROOT", Namespace = "http://www.OfsCms.com", IsNullable = false)]
    public class OFSEvent: OFSObject
    {
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Required]
        [Display(Name = "Data")]
        public DateTime Date
        {
            get;
            set;
        }

        [DisplayFormat(DataFormatString = "{0:HH:mm}")]
        [Required]
        [Display(Name = "Time")]
        public DateTime Time
        {
            get;
            set;
        }

        [XmlIgnore]
        public String DateTime
        {
            get { DateTime dt = new DateTime(Date.Year, Date.Month, Date.Day, Time.Hour, Time.Second, 0);
                return  dt.ToString("D", new CultureInfo("it-IT")) + " alle ore " + dt.ToString("H:mm", new CultureInfo("it-IT"));
            }
        }

        public RepeatFrequency RepeatFrequency
        {
            get;
            set;
        }

        [Required]
        [Display(Name = "Title")]
        public string Title
        {
            get;
            set;
        }

        [Required]
        [Display(Name = "SeoTitle")]
        public string SeoTitle
        {
            get;
            set;
        }

        [Required]
        [Display(Name = "Title")]
        public string Description
        {
            get;
            set;
        }

        
    }
}
