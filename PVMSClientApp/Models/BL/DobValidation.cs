using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PVMSClientApp.Models.BL
{
    public class DobValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dt = Convert.ToDateTime(value);
            DateTime dt1 = DateTime.Now;
            if (dt1.CompareTo(dt) == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}