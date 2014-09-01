using DataClasses.DataModel.Calendar;
using DataClasses.DataModel.Generic;
using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DataClasses.DataModel.Mail
{
    [XmlRootAttribute("ROOT", Namespace = "http://www.OfsCms.com", IsNullable = false)]
    public class MailMessage : OFSObject
    {
        [Required]
        [Display(Name = "Oggetto")]
        public string Object
        {
            get;
            set;
        }

        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Email non valida")]
        [Display(Name = "Mittente")]
        public string Sender
        {
            get;
            set;
        }

       
        public string Recipient
        {
            get;
            set;
        }


        public ArrayList Recipients
        {
            get;
            set;
        }

        [Display(Name = "Allegato")]
        public string Attachment
        {
            get;
            set;
        }
        public ArrayList Attachments
        {
            get;
            set;
        }

        [Required]
        [Display(Name = "Messaggio")]
        public string Message
        {
            get;
            set;
        }

        public static string PrivacyText()
        {
            string pathy = OFS.Folders.TextsFolder.EndsWith("\\") ? OFS.Folders.TextsFolder : OFS.Folders.TextsFolder + "\\";
            string fileName = string.Concat(pathy, "privacy.txt");
            if (System.IO.File.Exists(fileName))
            {
                return System.IO.File.ReadAllText(fileName, System.Text.Encoding.UTF7);
            }
            return string.Empty;

        }

        [Required(ErrorMessage = "Occorre accettare la normativa della riservatezza dei dati personali (Privacy).")]
        [CustomValidation(typeof(PrivacyValidation), "ValidateCheckBox")]
        public bool PrivacyAccepted { get; set; }


        public string IpAddress
        {
            get;
            set;
        }
    }

    public class PrivacyValidation
    {
        public static ValidationResult ValidateCheckBox(string value)
        {
            bool isValid;
            string ErrorMessage = "Occorre accettare la normativa della riservatezza dei dati personali (Privacy).";
            isValid = Convert.ToBoolean(value) == true;

            if (isValid)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(ErrorMessage);
            }
        }
    }
}
