using PVMSClientApp.Models.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PVMSClientApp.Models.DAO
{
    public class user_registration2
    {
        public string userId { get; set; }
        [Required(ErrorMessage = "FirstName Cannot be blank")]
        public string firstName { get; set; }
        [Required(ErrorMessage = "LastName Cannot be blank")]
        public string lastName { get; set; }
        [DobValidation(ErrorMessage = "Date must not be greater than today's date")]
        public System.DateTime dob { get; set; }
        [Required(ErrorMessage = "Address Cannot be blank")]
        public string address { get; set; }
        [Required(ErrorMessage = "ContactNo Cannot be blank")]
        [StringLength(10,ErrorMessage="must be 10 digits")]
        public string contactNo { get; set; }
        [Required(ErrorMessage = "Email Cannot be blank")]
        public string email { get; set; }
        [Required(ErrorMessage = "Qualification Cannot be blank")]
        public string qualification { get; set; }
        [Required(ErrorMessage = "Gender Cannot be blank")]
        public string gender { get; set; }
        [Required(ErrorMessage = "HintQuestion Cannot be blank")]
        public string hintQuestion { get; set; }
        [Required(ErrorMessage = "HintAnswer Cannot be blank")]
        public string hintAnswer { get; set; }
        public string citizenType { get; set; }
        public string password { get; set; }
        public string status { get; set; }

        
        public virtual ICollection<passport> passports { get; set; }
        
        public virtual ICollection<visa> visas { get; set; }
    }
}