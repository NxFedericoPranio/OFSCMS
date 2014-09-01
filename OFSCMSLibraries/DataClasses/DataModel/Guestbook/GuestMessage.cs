using DataClasses.DataModel.Generic;
using DataClasses.DataModel.Users;
using DataClasses.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DataClasses.DataModel.Guestbook
{
    public class GuestMessage : OFSObject, INeedApprovation
    {

        [Required]
        [Display(Name = "Nome")]
        public string Nick
        {
            get;
            set;
        }

        [Required]
        [Display(Name = "Titolo")]
        public string Title
        {
            get;
            set;
        }


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


        [Display(Name = "Allegato")]
        public string Attachment
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

        public bool IsAapproved
        {
            get;
            set;
        }
    }
}
