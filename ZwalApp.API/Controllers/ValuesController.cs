using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZwalApp.API.Data;

namespace ZwalApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;

        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult  Get()
        {
           var Values= _context.Values.ToList();
           return Ok(Values);
        }
       [AllowAnonymous]
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult  Get(int id)
        {
            var Value=_context.Values.FirstOrDefault(a=>a.id==id);
            return Ok(Value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
