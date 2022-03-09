using AutoMapper;
using Demo.BL.Model;
using Demo.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Employee, EmployeeVM>()
                .ReverseMap();

        }
    }
}
