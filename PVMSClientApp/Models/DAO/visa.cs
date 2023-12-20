using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PVMSClientApp.Models.DAO
{
    public class visa
    {
        


        public string userId { get; set; }
        public string country { get; set; }
        [Required(ErrorMessage = "Occupation Cannot be blank")]
        public string occupation { get; set; }
        public System.DateTime dateOfApplication { get; set; }
        
        public string visaId { get; set; }
        public System.DateTime dateOfIssue { get; set; }
        public System.DateTime dateOfExpiry { get; set; }
        public double cost { get; set; }
        //[Required(ErrorMessage = "PassportId Cannot be blank")]
        //[RegularExpression(pattern: @"^FPS-(30|60) [0-9]{4}$")]
        public string passportId { get; set; }
        public string status { get; set; }

        public virtual user_registration2 user_registration2 { get; set; }
    }
}