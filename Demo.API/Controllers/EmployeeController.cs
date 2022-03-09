using AutoMapper;
using Demo.BL.Helper;
using Demo.BL.Interface;
using Demo.BL.Model;
using Demo.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Mime;

namespace Demo.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        #region Field
        private readonly IEmployeeRepo iemployee;
        private readonly IMapper mapper;
        #endregion


        #region Ctor
        public EmployeeController(IEmployeeRepo iemployee, IMapper mapper)
        {
            this.iemployee = iemployee;
            this.mapper = mapper;
        }
        #endregion


        #region APIs

        #region GetEmployees
        [HttpGet]
        [Route("~/API/Employee/GetEmployees")]
        public IActionResult GetEmployees()
        {
            try
            {
                var data = iemployee.GetAllEmployee();
                return Ok(new ApiResponse<IEnumerable<EmployeeVM>>()
                {
                    Code = "200",
                    Status = "OK",
                    Success = true,
                    Message = "Data Retrived",
                    Data = data
                });
            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponse<string>()
                {
                    Code = "404",
                    Status = "NotFound!",
                    Success = false,
                    Message = "Data Not Retrived",
                    Error = ex.Message
                });
            }
        }
        #endregion


        #region GetEmployeeById
        [HttpGet]
        [Route("~/API/Employee/GetEmployeeById/{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            try
            {
                var data = iemployee.GetById(id);
                return Ok(new ApiResponse<EmployeeVM>()
                {
                    Code = "200",
                    Status = "OK",
                    Success = true,
                    Message = "Data Retrived",
                    Data = data
                });
            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponse<string>()
                {
                    Code = "404",
                    Status = "NotFound!",
                    Success = false,
                    Message = "Data Not Retrived",
                    Error = ex.Message
                });
            }
        }

        #endregion


        #region CreateEmployee
        [HttpPost, DisableRequestSizeLimit]
        [Route("~/API/Employee/CreateEmployee")]
        public IActionResult CreateEmployee(EmployeeVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = iemployee.Create(model);
                    return Ok(new ApiResponse<Employee>()
                    {
                        Code = "201",
                        Status = "Ok",
                        Success = true,
                        Message = "Data Modified",
                        Data = data
                    });
                }
                else
                {
                    return BadRequest(new ApiResponse<Employee>()
                    {
                        Code = "400",
                        Status = "Bad Request",
                        Message = "Not Modified"
                    });
                }
            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponse<string>()
                {
                    Code = "304",
                    Status = "NotFound!",
                    Success = false,
                    Message = "Not Modified!",
                    Error = ex.Message
                });
            }
        }

        #endregion


        #region UpdateEmployee
        [HttpPut]
        [Route("~/API/Employee/UpdateEmployee")]
        public IActionResult UpdateEmployee(EmployeeVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = iemployee.Edit(model);
                    return Ok(new ApiResponse<Employee>()
                    {
                        Code = "201",
                        Status = "Ok",
                        Success = true,
                        Message = "Data Modified",
                        Data = data
                    });
                }
                else
                {
                    return BadRequest(new ApiResponse<Employee>()
                    {
                        Code = "400",
                        Status = "Bad Request",
                        Success = false,
                        Message = "Not Modified"
                    });
                }
            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponse<string>()
                {
                    Code = "304",
                    Status = "NotFound",
                    Success = false,
                    Message = "Not Modified!",
                    Error = ex.Message
                });
            }
        }

        #endregion


        #region DeleteEmployee
        [HttpDelete]
        [Route("~/API/Employee/DeleteEmployee/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                iemployee.Delete(id);

                return Ok(new ApiResponse<EmployeeVM>()
                {
                    Code = "201",
                    Status = "Ok",
                    Success = true,
                    Message = "Data Deleted",

                });
            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponse<string>()
                {
                    Code = "304",
                    Status = "NotFound",
                    Success = false,
                    Message = "Not Deleted!",
                    Error = ex.Message
                });
            }
        }

        #endregion

        #endregion

    }
}
