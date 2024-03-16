using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMSIntegrations.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            SMSServiceNSP.Service1Client client = new SMSServiceNSP.Service1Client();

            //client.GetSMSData("9911382964", "Dear Customer, The Initial work order for the claim Number CO2201770 under Policy Number for Vehicle Number MH-01-SDG-2345 has been provided to the workshop subject to policy terms and conditions. For More details, please contact our  surveyor Mr.  PAVAN KUMAR N, Mobile Number 8050726358 Team Universal Sompo");

            client.GetSMSData("9911382964", "Dear Customer, Greetings from Universal Sompo General Insurance. Claim no. CO2201786 has been registered under policy no. 2312/67179755/00/000.Please use it for future communication. For any assistance, reach us at 9742522748");
            // Use the 'client' variable to call operations on the service.

            // Always close the client.
            client.Close();


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}