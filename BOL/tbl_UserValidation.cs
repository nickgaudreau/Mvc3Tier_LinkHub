using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    // convention - suffix it with Attribute
    public class UniqueEmailAttribute : ValidationAttribute
    {
        // param value = the user input
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Mvc3TierEntities ctx = new Mvc3TierEntities();
            string userValue = value.ToString();
            int count = ctx.tbl_User.Count(x => x.c_UserEmail == userValue);
            if (count != 0)
            {
                return new ValidationResult("User Already Exist with this email ID!");
            }
            //return base.IsValid(value, validationContext);
            return ValidationResult.Success;
        }

    }

    public class tbl_UserValidation
    {
        [Required, EmailAddress,UniqueEmail, ]
        public string c_UserEmail { get; set; }
        
        [Required]
        public string c_Password { get; set; }

        [Required, Compare("c_Password")]
        public string c_ConfirmPassword { get; set; }

    }

    [MetadataType(typeof(tbl_UserValidation))]
    public partial class tbl_User {

        public string c_ConfirmPassword { get; set; } // will add to model
    }

}
