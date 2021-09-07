using Florist.Business.Abstract;
using Florist.DataAccessLayer.DataTransferObject.CustomerDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Florist.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        [Route("CustomerAdd")]
        public async Task<ActionResult<string>> AddCustomer(CustomerAddDTO customer)
        {
            var result = await _customerService.AddCustomer(customer);

            if (result > 0)
            {
                return Ok(new { code = StatusCode(1000), message = "Müşteri ekleme başarılı!", type = "success" });
            }
            return BadRequest("Müşteri ekleme başarısız!");
        }

        [HttpGet]
        [Route("CustomerList")]
        public async Task<ActionResult<List<CustomerListDTO>>> ListCustomer()
        {
            var customerList = await _customerService.ListCustomer();
            if (customerList == null)
            {
                return BadRequest("Müşteri listesi bulunamadı!");
            }
            return Ok(customerList);
        }

        [HttpGet]
        [Route("CustomerIdList/{id}")]
        public async Task<ActionResult<List<CustomerGetDTO>>> GetCustomerById(int Id)
        {
            var customerList = await _customerService.GetCustomerById(Id);
            if (customerList == null)
            {
                return BadRequest("Id listesi bulunamadı!");
            }
            return Ok(customerList);
        }


        [HttpPut]
        [Route("CustomerUpdate")]
        public async Task<ActionResult<string>> UpdateCustomer(CustomerUpdateDTO customer)
        {
            var result = await _customerService.UpdateCustomer(customer);
            if (result > 0)
            {
                return Ok(new { code = StatusCode(1000), message = "Müşteri güncelleme başarılı!", type = "success" });
            }
            return BadRequest("Müşteri güncelleme başarısız!");
        }

        [HttpDelete]
        [Route("CustomerDelete/{id}")]
        public async Task<ActionResult<string>> DeleteCustomer(int id)
        {
            var result = await _customerService.DeleteCustomer(id);
            if (result > 0)
            {
                return Ok(new { code = StatusCode(1000), message = "Müşteri silme başarılı!", type = "success" });
            }
            return BadRequest("Müşteri silme başarısız!");
        }

    }
}
