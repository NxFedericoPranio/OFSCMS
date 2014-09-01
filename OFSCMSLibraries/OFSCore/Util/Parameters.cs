using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace OFSCore.Util
{
    public static class Parameters
    {

        public static bool ErrorHandling{
            get { return Convert.ToBoolean(ConfigurationManager.AppSettings["ErrorHandling"]); }
       }

        public static string AdminMail
        {
            get { return ConfigurationManager.AppSettings["AdminMail"]; }
        }

        public static string MailSMTP
        {
            get { return ConfigurationManager.AppSettings["MailSMTP"]; }
        }

        public static string SmtpUserName
        {
            get { return ConfigurationManager.AppSettings["SmtpUserName"]; }
        }

        public static string SmtpPassword
        {
            get { return ConfigurationManager.AppSettings["SmtpPassword"]; }
        }

    }
}
