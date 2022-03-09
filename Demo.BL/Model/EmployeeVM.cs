using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Model
{
    public class EmployeeVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required ")]
        [MaxLength(30, ErrorMessage = "Max Length is 30 Char")]
        [MinLength(3, ErrorMessage = "Min Length is 3 Char")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Salary is Required ")]
        [Range(1000, 50000, ErrorMessage = "Range Between 10000 : 50000")]
        public double Salary { get; set; }

        // 12-Street-CIty-Country
        [RegularExpression("[1-9]{1,5}-[a-zA-Z]{2,10}-[a-zA-Z]{2,10}-[a-zA-Z]{2,10}", ErrorMessage = "Like : 12-Street-CIty-Country")]
        public string Address { get; set; }

        public DateTime HireDate { get; set; }
        public bool IsActive { get; set; }

        public string PhotoName { get; set; }
        //public IFormFile Photo { get; set; }

    }
}
