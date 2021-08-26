using Device.Business.Abstract;
using Device.DataAccessLayer.DataTransferObject.TelDTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Device.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelController : ControllerBase
    {
        public ITelService _telService;
        public TelController(ITelService telService)
        {
            _telService = telService;
        }

        [HttpGet]
        [Route("TelList")]
        public ActionResult<List<TelListDTO>> ListTel()
        {
            var telList = _telService.ListTel();
            if (telList == null)
            {
                return BadRequest("Telefon listesi bulunamadı!");
            }
            return Ok(telList);
        }

        [HttpGet]
        [Route("TelIdList/{Id}")]
        public ActionResult<List<TelGetDTO>> GetTelById(int Id)
        {
            var telList = _telService.GetTelById(Id);
            if (telList == null)
            {
                return BadRequest("Id listesi bulunamadı!");
            }
            return Ok(telList);
        }

        [HttpDelete]
        [Route("TelDelete/{Id}")]
        public ActionResult<string> DeleteTel(int Id)
        {
            var result = _telService.DeleteTel(Id);
            if (result > 0)
            {
                return Ok(new { code = StatusCode(1000), message = "Silinme başarılı!", type = "success" });
            }
            return BadRequest("Silinme başarısız!");
        }

        [HttpPost]
        [Route("TelAdd")]
        public ActionResult<string> AddTel(TelAddDTO tel)
        {
            var result = _telService.AddTel(tel);
            if (result > 0)
            {
                return Ok(new { code = StatusCode(1000), message = "Ekleme başarılı!", type = "success" });
            }
            return BadRequest("Ekleme Başarısız!");
        }

        [HttpPut]
        [Route("TelUpdate")]
        public ActionResult<string> UpdateTel(TelUpdateDTO tel)
        {
            var result = _telService.UpdateTel(tel);
            if (result > 0)
            {
                return Ok(new { code = StatusCode(1000), message = "Güncelleme başarılı!", type = "success" });
            }
            return BadRequest("Güncelleme Başarısız!");
        }
    }
}
