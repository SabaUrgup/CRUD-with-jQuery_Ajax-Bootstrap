using Management.Business.Abstract;
using Management.DataAccessLayer.DataTransferObject.EmployerDTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Management.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        public IEmployerService _employerService;
        public EmployerController(IEmployerService employerService)
        {
            _employerService = employerService;
        }

        [HttpPost]
        [Route("EmployerAdd")]
        public ActionResult<string> AddEmployer(EmployerAddDTO employer)
        {
            var result = _employerService.AddEmployer(employer);

                if (result > 0)
                {
                    return Ok(new { code = StatusCode(1000), message = "İş veren ekleme başarılı!", type = "success"});
                }
                return BadRequest("İş veren ekleme başarısız!");
        }

        [HttpGet]
        [Route("EmployerList")]
        public ActionResult<List<EmployerListDTO>> ListEmployer()
        {
            var employerList = _employerService.ListEmployer();
            if (employerList == null)
            {
                return BadRequest("İş veren listesi bulunamadı!");
            }
            return Ok(employerList);
        }

        [HttpGet]
        [Route("EmployerGet/{id}")]
        public ActionResult<EmployerListDTO> GetEmployerById(int id)
        {
            var employer = _employerService.GetEmployerById(id);
            if (employer == null)
            {
                return BadRequest("İş veren listesi güncellenmedi!");
            }
            return Ok(employer);
        }

        [HttpPut]
        [Route("EmployerUpdate")]
        public ActionResult<string> UpdateEmployer(EmployerUpdateDTO employer)
        {
            var result = _employerService.UpdateEmployer(employer);
                if (result > 0)
            {
                return Ok(new { code = StatusCode(1000), message = "İş veren güncelleme başarılı!!", type = "success" });
            }
            return BadRequest("İş veren güncelleme başarısız!");
        }

        [HttpDelete]
        [Route("EmployerDelete/{id}")]
        public ActionResult<string> DeleteEmployer(int id)
        {
            var result = _employerService.DeleteEmployer(id);
                if (result> 0)
            {
                return Ok(new { code = StatusCode(1000), message = "İş veren silme başarılı!!", type = "success" });
            }
            return BadRequest("İş veren silme başarısız!");
        }

    }
}
