using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PVMSClientApp.Models.DAO
{
    public class passport
    {
        
        public string userId { get; set; }
        public string country { get; set; }
        [Required(ErrorMessage = "State can’t be left blank")]
        public string state { get; set; }
        [Required(ErrorMessage = "City can’t be left blank")]
        public string city { get; set; }
        [Required(ErrorMessage = "Pin can’t be left blank.")]
        [RegularExpression("^[0-9]{6}$", ErrorMessage = "Only 6 numeric values are allowed")]
        public int pin { get; set; }
        [Required(ErrorMessage = "Service type can’t be left blank.")]
        public string typeOfService { get; set; }
        [Required(ErrorMessage = "Booklet type can’t be left blank.")]
        public string bookletType { get; set; }
        public System.DateTime issueDate { get; set; }

        //[Required(ErrorMessage = "PassportId Cannot be blank")]
        //[RegularExpression(pattern: @"^FPS-(30|60) [0-9]{4}$")]
        public string passportId { get; set; }
        public System.DateTime expiryDate { get; set; }
        public System.Double amount { get; set; }
        public string status { get; set; }

        public virtual user_registration2 user_registration2 { get; set; }
    }
}