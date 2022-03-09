using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Entity
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }

        public string Address { get; set; }

        public DateTime HireDate { get; set; }
        public bool IsActive { get; set; }

        //public string PhotoName { get; set; }



    }
}
