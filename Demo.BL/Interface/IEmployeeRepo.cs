using Demo.BL.Model;
using Demo.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Interface
{
    public interface IEmployeeRepo
    {
        IEnumerable<EmployeeVM> GetAllEmployee(int paging);

        public EmployeeVM GetById(int id);

        public Employee Create(EmployeeVM obj);

        public dynamic Edit(EmployeeVM obj);

        public void Delete(int id);


    }
}
