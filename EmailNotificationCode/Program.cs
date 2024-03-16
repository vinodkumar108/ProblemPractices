using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailNotificationCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //string IsEmailNotificationTest = ConfigurationManager.AppSettings["EmailNotificationTest"];
            //string emailTestData = ConfigurationManager.AppSettings["EmailTestData"];

            string IsEmailNotificationTest = "Y";
            string emailTestData = "dinesh.pawar@universalsompo.com,ramdas.bamane@universalsompo.com";

            List<string> lstEmails = new List<string>();

            if (IsEmailNotificationTest == "Y")
            {
                lstEmails = emailTestData.Split(',').ToList();
                //email.To = lstEmails;
            }
        }
    }
}
