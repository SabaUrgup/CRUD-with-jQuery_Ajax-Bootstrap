using Management.Business.Abstract;
using Management.DataAccessLayer.DataTransferObject.EmployeeDTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Management.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        [Route("EmployeeAdd")]
        public ActionResult<string> AddEmployee(EmployeeAddDTO employee)
        {
            var result = _employeeService.AddEmployee(employee);

            if (result > 0)
            {
                return Ok(new { code = StatusCode(1000), message = "İşçi ekleme başarılı!", type = "success" });
            }
            return BadRequest("İşçi ekleme başarısız!");
        }

        [HttpGet]
        [Route("EmployeeList")]
        public ActionResult<List<EmployeeListDTO>> ListEmployee()
        {
            var employeeList = _employeeService.ListEmployee();
            if (employeeList == null)
            {
                return BadRequest("İşçi listesi bulunamadı!");
            }
            return Ok(employeeList);
        }


        [HttpPut]
        [Route("EmployeeUpdate")]
        public ActionResult<string> UpdateEmployee(EmployeeUpdateDTO employee)
        {
            var result = _employeeService.UpdateEmployee(employee);
            if (result > 0)
            {
                return Ok(new { code = StatusCode(1000), message = "İşçi güncelleme başarılı!!", type = "success" });
            }
            return BadRequest("İşçi güncelleme başarısız!");
        }

        [HttpGet]
        [Route("EmployeeGet/{id}")]
        public ActionResult<EmployeeListDTO> GetEmployerById(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return BadRequest("İşçi listesi güncellenmedi!");
            }
            return Ok(employee);
        }

        [HttpDelete]
        [Route("EmployeeDelete/{id}")]
        public ActionResult<string> DeleteEmployee(int id)
        {
            var result = _employeeService.DeleteEmployee(id);
            if (result > 0)
            {
                return Ok(new { code = StatusCode(1000), message = "İşçi silme başarılı!!", type = "success" });
            }
            return BadRequest("İşçi silme başarısız!");
        }

    }
}
