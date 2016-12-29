using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Golf.ServiceLayer.Interfaces;
using Golf.Model;
using System;
using Golf.ServiceLayer.Dto.Implementations;
using AutoMapper;

namespace Golf.RESTService.Controllers
{
    [Route("api/[controller]")]
    public class GolfersController : Controller
    {
        IGolferService _golferService;

        public GolfersController(IGolferService golferService)
        {
            if(golferService == null)
            {
                throw new ArgumentNullException(nameof(golferService));
            }
            _golferService = golferService;
        }

        [HttpGet]
        public IEnumerable<GolferDto> Get()
        {
            var golfers = _golferService.GetAll();

            return Mapper.Map<IEnumerable<GolferDto>>(golfers);
        }

        [HttpGet("{id}")]
        public GolferDto Get(int id)
        {
            var golfer = _golferService.GetById(id);

            return Mapper.Map<GolferDto>(golfer);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]GolferDto golferDto)
        {
            var golfer = Mapper.Map<Golfer>(golferDto);

            _golferService.Create(golfer);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]GolferDto golfer)
        {
            var golferToUpdate = _golferService.GetById(id);

            golferToUpdate = Mapper.Map(golfer, golferToUpdate);
            golferToUpdate.Id = id;

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
