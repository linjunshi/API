using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApplicationApi.Models;
using ApplicationApi.Repositories;

namespace ApplicationApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ApplyController : Controller
    {
        ICustomersRepo _repo = new CustomersRepo();
        // GET api/values
        [HttpGet]
        public ICollection<Customer> Get()
        {
            return _repo.get_all_customers();
        }

        // GET api/values/5
        [HttpGet("{email}")]
        public Customer Get(string email)
        {
            return _repo.get_customer(email);
        }

        // helper method
        private bool customer_exists(string email)
        {
            return _repo.get_customer(email) != null;
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> register(CustomerViewModel custView)
        {
            custView.contact.Replace(" ", "");
            if (ModelState.IsValid)
            {

                custView.PostTime = DateTime.Now;
                if (customer_exists(custView.email))
                {
                    return await this.update_user(custView);
                }
                else
                {
                    _repo.create_customer(custView);
                }
                return Ok(custView);
            }
            return BadRequest(ModelState);
        }

        // PUT api/values/5
        [HttpPut("{CustomerViewModel}")]
        public async Task<IActionResult> update_user(CustomerViewModel custView)
        {
            // TO-DO
            if (ModelState.IsValid)
            {
                Customer c = _repo.get_customer(custView.email);
                // if the request is less than 60s
                if (c.PostTime.AddSeconds(10) > DateTime.Now)
                {
                    return BadRequest($"Please try submit the form later!");
                }
                await _repo.update_customer(custView);
                return Ok(custView);
            }
            return BadRequest(ModelState);
        }

        // DELETE api/values/5
        [HttpDelete("{email}")]
        public void Delete(string email)
        {
        }
    }
}
