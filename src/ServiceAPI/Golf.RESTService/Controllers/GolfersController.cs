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

        [HttpGet]
        public IEnumerable<Golfer> Get()
        {
            return _golferService.GetAll();
        }

        [HttpGet("{id}")]
        public Golfer Get(int id)
        {
            return _golferService.GetById(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Golfer golfer)
        {
            _golferService.Create(golfer);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Golfer golfer)
        {
            var golferToUpdate = _golferService.GetById(id);

            golferToUpdate.FirstName = golfer.FirstName;
            golferToUpdate.LastName = golfer.LastName;

            _golferService.Update(golferToUpdate);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var golferToDelete = _golferService.GetById(id);

            _golferService.Delete(golferToDelete);
        }
    }
}
