using Device.Business.Abstract;
using Device.DataAccessLayer.DataTransferObject.TvDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Device.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TvController : ControllerBase
    {
        public ITvService _tvService;
        public TvController(ITvService tvService)
        {
            _tvService = tvService;
        }

        [HttpGet]
        [Route("TvList")]
        public ActionResult<List<TvListDTO>> ListTv()
        {
            var tvList = _tvService.ListTv();
            if (tvList == null)
            {
                return BadRequest("Televizyon listesi bulunamadı!");
            }
            return Ok(tvList);
        }

        [HttpGet]
        [Route("TvIdList/{Id}")]
        public ActionResult<List<TvGetDTO>> GetTvById(int Id)
        {
            var tvList = _tvService.GetTvById(Id);
            if (tvList == null)
            {
                return BadRequest("Id listesi bulunamadı!");
            }
            return Ok(tvList);
        }

        [HttpDelete]
        [Route("TvDelete/{Id}")]
        public ActionResult<string> DeleteTv(int Id)
        {
            var result = _tvService.DeleteTv(Id);
            if (result > 0)
            {
                return Ok(new { code = StatusCode(1000), message = "Silinme başarılı!", type = "success" });
            }
            return BadRequest("Silinme başarısız!");
        }

        [HttpPost]
        [Route("TvAdd")]
        public ActionResult<string> AddTel(TvAddDTO tv)
        {
            var result = _tvService.AddTv(tv);
            if (result > 0)
            {
                return Ok(new { code = StatusCode(1000), message = "Ekleme başarılı!", type = "success" });
            }
            return BadRequest("Ekleme Başarısız!");
        }

        [HttpPut]
        [Route("TvUpdate")]
        public ActionResult<string> UpdateTv(TvUpdateDTO tv)
        {
            var result = _tvService.UpdateTv(tv);
            if (result > 0)
            {
                return Ok(new { code = StatusCode(1000), message = "Güncelleme başarılı!", type = "success" });
            }
            return BadRequest("Güncelleme Başarısız!");
        }
    }
}
