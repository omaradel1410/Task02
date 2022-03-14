using AutoMapper;
using AutoMapper.QueryableExtensions;
using Demo.BL.Interface;
using Demo.BL.Model;
using Demo.DAL.Database;
using Demo.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Repo
{
    public class EmployeeRepo : IEmployeeRepo
    {

        #region Fields
        private readonly DemoContext db;
        private readonly IMapper mapper;
        #endregion


        #region CTOR
        public EmployeeRepo(DemoContext Db, IMapper mapper)
        {
            this.db = Db;
            this.mapper = mapper;
        }
        #endregion


        #region Actions

        #region GetAllEmployee
        public IEnumerable<EmployeeVM> GetAllEmployee(int paging)
        {
            var data = db.Employee.Select(e => e).ProjectTo<EmployeeVM>(mapper.ConfigurationProvider).Skip(paging * 10).Take(10); ;
            return data;
        }
        
        #endregion


        #region GetById
        public EmployeeVM GetById(int id)
        {
            var data = db.Employee
                .Where(e => e.Id == id)
                .ProjectTo<EmployeeVM>(mapper.ConfigurationProvider)
                .FirstOrDefault();
            return data;
        }

        #endregion


        #region Create
        public Employee Create(EmployeeVM obj)
        {
            var model = mapper.Map<Employee>(obj);
            var data = db.Employee.Add(model);
            db.SaveChanges();
            return db.Employee.OrderBy(x => x.Id).LastOrDefault();
        }
        #endregion


        #region Edit
        public dynamic Edit(EmployeeVM obj)
        {
            var model = mapper.Map<Employee>(obj);
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();
            return db.Employee.Find(obj.Id);
        }
        #endregion


        #region Delete
        /*     public EmployeeVM Delete(EmployeeVM obj)
             {
                 var model = mapper.Map<Employee>(obj);
                 var data = db.Employee.Remove(model);
                 db.SaveChanges();
                 return obj;
             }*/
        public void Delete(int id)
        {
            var data = db.Employee.Find(id);
            db.Employee.Remove(data);
            db.SaveChanges();
        }

        #endregion

        #endregion

    }
}
