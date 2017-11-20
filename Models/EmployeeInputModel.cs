using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Models
{
  
    public class EmployeeInputModel 
    {
        [Required]
        [Remote(action:"ValidateEmployeeNo", controller:"Home")]
        public string EmployeeNo { get; set; }
    }



}
