using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Models
{
    public enum Gender { Male, Female}
    public class EmployeeInputModel : IValidatableObject
    {
        public int Id { get; set; }

        [Required]
        public string EmployeeNo { get; set; }

        [StringLength(10)]
        [MinLength(3)]
        public string Surname { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Url]
        public string BlogUrl { get; set; }

        [DataType(DataType.Date)]
        [AgeCheck]
        [Display(Name = "Date of Birth")]
        public DateTime BirthDate { get; set; }

        public Gender Gender { get; set; }

        [Range(0, 10000.00)]
        public decimal Salary { get; set; }

        public bool IsPartTime { get; set; }

        public AddressInputModel Address { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(!string.IsNullOrEmpty(BlogUrl) && BlogUrl.Contains("darren.com"))
            {
                yield return new ValidationResult("url already taken", new[] { "BlogUrl"});
            }
        }
    }

    public class AddressInputModel
    {
        [Required]
        [RegularExpression("[A-Za-z0-9].*")]
        public string Line { get; set; }
    }

    public class AgeCheck:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = validationContext.ObjectInstance as EmployeeInputModel;
            if (model == null)
                throw new ArgumentException("attribute not applied on Employee");
            if (model.BirthDate > DateTime.Now.Date)
                return new ValidationResult(GetErrorMessage(validationContext));
            return ValidationResult.Success;
        }

        private string GetErrorMessage(ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(this.ErrorMessage))
                return this.ErrorMessage;

            return $"{validationContext.DisplayName} can't be in future";
        }
    }
}
