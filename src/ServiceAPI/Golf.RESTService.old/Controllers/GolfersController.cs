using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Golf.ServiceLayer.Interfaces;
using Golf.Model;

namespace Golf.RESTService.Controllers
{
    [Route("api/[controller]")]
    public class GolfersController : Controller
    {
        IGolferService _golferService;

        public GolfersController(IGolferService golferService)
        {
            _golferService = golferService;
        }

        // GET: api/golfers
        [HttpGet]
        public IEnumerable<Golfer> Get()
        {
            return _golferService.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
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
