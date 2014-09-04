using DataClasses.DataModel.Generic;
using DataClasses.DataModel.Mail;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DataClasses.DataModel.Orders
{

    [XmlRootAttribute("ROOT", Namespace = "http://www.OfsCms.com", IsNullable = false)]
    public class Order : MailMessage
    {



        public class Quantity
        {
            public int QuantityNum { get; set; }
            public string Value { get; set; }
        }

        public Order()
        {
            QuantityVal = 1;
            Object = "Ordine";
        }

        public List<Quantity> Quantities =
            new List<Quantity>
        {
            new Quantity {QuantityNum = 1, Value = "1"},
            new Quantity {QuantityNum = 2, Value = "2"},
            new Quantity {QuantityNum = 3, Value = "3"},
            new Quantity {QuantityNum = 4, Value = "4"},
            new Quantity {QuantityNum = 5, Value = "5"},
            new Quantity {QuantityNum = 6, Value = "6"},
            new Quantity {QuantityNum = 7, Value = "7"},
            new Quantity {QuantityNum = 8, Value = "8"},
            new Quantity {QuantityNum = 9, Value = "9"},
            new Quantity {QuantityNum = 10, Value = "10"}
        };

        [Required]
        [Display(Name = "Quantità")]
        public int QuantityVal { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Cognome")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Indirizzo")]
        public string Address { get; set; }
        
        [Display(Name = "Civico")]
        public string CNumber { get; set; }

        [Required]
        [Display(Name = "Città")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Cap")]
        public string ZipCode { get; set; }

        [Required]
        [Display(Name = "Provincia/Nazione")]
        public string Country { get; set; }

        [Display(Name = "Nazione")]
        public string State { get; set; }

        [Display(Name = "Articolo")]
        public string ItemId { get; set; }

        [Required]
        [Display(Name = "Telefono")]
        public string TelephonNumber { get; set; }


        public string PaymentMethod { get; set; }

        [Required(ErrorMessage = "Occorre accettare la normativa della riservatezza dei dati personali (Privacy).")]
        [CustomValidation(typeof(PrivacyValidation), "ValidateCheckBox")]
        public bool PrivacyAccepted { get; set; }
    }
}
