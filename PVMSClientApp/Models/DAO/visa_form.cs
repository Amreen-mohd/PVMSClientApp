using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PVMSClientApp.Models.DAO
{
    public class Visa_form
    {
        public string Occupation { get; set; }
        public string Country { get; set; }
        public double Amount { get; set; }
        public double Validity { get; set; }
    }
}