using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PVMSClientApp.Models.DAO
{
    public class userProfile
    {

        public string userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public System.DateTime dob { get; set; }
        public string address { get; set; }
        public string contactNo { get; set; }
        public string email { get; set; }
        public string qualification { get; set; }
        public string gender { get; set; }
        public string hintQuestion { get; set; }
        public string hintAnswer { get; set; }
        public string citizenType { get; set; }
        public string password { get; set; }
    }
}