using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace DataClasses.DataModel.Users
{

    public class ChangePasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [System.Web.Mvc.Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LogOnModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
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

    public class RegisterModel : DataClasses.DataModel.Generic.OFSObject 
    {
        public static string PrivacyText()
        {
            string pathy = OFS.Folders.TextsFolder.EndsWith("\\") ? OFS.Folders.TextsFolder : OFS.Folders.TextsFolder+"\\";
            string fileName = string.Concat(pathy, "privacy.txt");
            if (System.IO.File.Exists(fileName))
            {
                return  System.IO.File.ReadAllText(fileName, System.Text.Encoding.UTF7);
            }
            return string.Empty;

        }

        [Required]
        [Display(Name = "Nome Utente")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Email non valida")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La {0} deve essere lunga almeno {2} caratteri.", MinimumLength = 6)]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Conferma password")]
        //[System.Web.Mvc.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [System.Web.Mvc.Compare("Password", ErrorMessage = "La password e la conferma non combaciano.")]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage = "Occorre accettare la normativa della riservatezza dei dati personali (Privacy).")]
        [CustomValidation(typeof(PrivacyValidation), "ValidateCheckBox")]
        public bool PrivacyAccepted { get; set; }


        public bool MailAccepted { get; set; }

        public string IpAddress { get; set; }

        public ArrayList Roles { get; set; }
    }
}
