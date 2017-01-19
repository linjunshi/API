using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApplicationApi.Models;
using ApplicationApi.Repositories;
using Microsoft.AspNetCore.Http;

namespace ApplicationApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ApplyController : Controller
    {
        ICustomersRepo repo = new CustomersRepo();
        // GET api/values
        [HttpGet]
        public ICollection<Customer> Get()
        {
            return repo.get_all_customers();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            return repo.get_customer(id);
        }

        // POST api/values
        [HttpPost]
        public IActionResult register (CustomerViewModel custView)
        {
            if (ModelState.IsValid)
            {

                repo.create_customer(custView);
                return Ok(custView);
            }
            return BadRequest(ModelState);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
