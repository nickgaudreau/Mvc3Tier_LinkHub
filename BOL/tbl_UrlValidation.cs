using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    // convention - suffix it with Attribute
    public class UniqueUrlAttribute : ValidationAttribute
    {
        // param value = the user input
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Mvc3TierEntities ctx = new Mvc3TierEntities();
            string urlValue = value.ToString();
            int count = ctx.tbl_Url.Count(x => x.c_Url == urlValue);
            if (count != 0)
            {
                return new ValidationResult("Url Already Exist - not allowed!");
            }
            //return base.IsValid(value, validationContext);
            return ValidationResult.Success;
        }

    }

    public class tbl_UrlValidation
    {
        [Required]
        public string c_UrlTitle { get; set; }

        // We want unique URL only - no dup - need Custom Validation
        [Required, Url, UniqueUrl]
        public string c_Url { get; set; }

        [Required]
        public string c_UrlDesc { get; set; }

    }

    [MetadataType(typeof(tbl_UrlValidation))]
    public partial class tbl_Url { }
}
