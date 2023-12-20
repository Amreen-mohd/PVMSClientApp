using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PVMSClientApp.Models.DAO
{
    public class userLogin { 

        [Required(ErrorMessage = "UserId Cannot be blank")]
        public string userId { get; set; } 
        [Required(ErrorMessage = "ContactNo Cannot be blank")]
        [RegularExpression(pattern: "^[6-9][0-9]{9}", ErrorMessage = "Invalid PhoneNo")] 
        public string contactNo { get; set; } 
        [Required(ErrorMessage = "Password Cannot be blank")] 
        public string password { get; set; } 
    }
}