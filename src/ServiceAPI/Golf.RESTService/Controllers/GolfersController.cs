using System.Collections.Generic;
using Golf.ServiceLayer.Interfaces;
using Golf.Model;
using System.Web.Http;
using System;
using Golf.ServiceLayer.Dto.Implementations;
using AutoMapper;

namespace Golf.RESTService.Controllers
{
    public class GolfersController : ApiController
    {
        IGolferService _golferService;

        public GolfersController(IGolferService golferService)
        {
            if (golferService == null)
            {
                throw new ArgumentNullException(nameof(golferService));
            }
            _golferService = golferService;
        }

        public IEnumerable<GolferDto> Get()
        {
            var golfers = _golferService.GetAll();

            return Mapper.Map<IEnumerable<GolferDto>>(golfers);
        }

        public GolferDto Get(int id)
        {
            var golfer = _golferService.GetById(id);

            return Mapper.Map<GolferDto>(golfer);
        }

        // POST api/golfers
        public void Post([FromBody]GolferDto golferDto)
        {
            var golfer = Mapper.Map<Golfer>(golferDto);

            _golferService.Create(golfer);
        }

        // PUT api/golfers/5
        public void Put(int id, [FromBody]GolferDto golfer)
        {
            var golferToUpdate = _golferService.GetById(id);

            golferToUpdate = Mapper.Map(golfer, golferToUpdate);
            golferToUpdate.Id = id;

            _golferService.Update(golferToUpdate);
        }

        // DELETE api/golfers/5
        public void Delete(int id)
        {
            var golferToDelete = _golferService.GetById(id);

            _golferService.Delete(golferToDelete);
        }
    }
}
