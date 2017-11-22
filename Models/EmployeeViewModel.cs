using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Models
{
    public enum Gender { Male=1,Female=2}
    public class EmployeeViewModel
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Url]
        public string BlogUrl { get; set; }

        [Phone]
        public string MobileNo { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public double Salary { get; set; }

        [Display(Name ="Part Time?")]
        public bool IsPartTime { get; set; }

        public string Notes { get; set; }

        public string Title { get; set; }

        public IEnumerable<string> Interests { get; set; }
        public Gender Gender { get; set; }

        public List<SelectListItem> GetTitles()
        {
            return new List<SelectListItem> {
                new SelectListItem{Value="Mr", Text="Mr."},
                new SelectListItem{Value="Mrs", Text="Mrs."},
                new SelectListItem{Value="Dr",Text="Dr."}
            };
        }

        public List<SelectListItem> GetInterests()
        {
            return new List<SelectListItem>
            {
                new SelectListItem{Value="C", Text = "Coding"},
                new SelectListItem{Value="G",Text ="Gaming"},
                new SelectListItem{Value="M", Text="Watching Movies"},
                new SelectListItem{Value="S",Text="Sleeping"}
            };
        }
    }
}
