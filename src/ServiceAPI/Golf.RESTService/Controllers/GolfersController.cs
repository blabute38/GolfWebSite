using System.Collections.Generic;
using Golf.ServiceLayer.Interfaces;
using Golf.Model;
using System.Web.Http;
using System;
using Golf.ServiceLayer.Dto.Implementations;
using AutoMapper;
using System.Net.Http;
using System.Web.Http.Results;
using Newtonsoft.Json;
using System.Text;
using System.Net;

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

        public JsonResult<IEnumerable<GolferDto>> Get()
        {
            var golfers = _golferService.GetAll();

            return Json(
                Mapper.Map<IEnumerable<GolferDto>>(golfers),
                new JsonSerializerSettings(),
                Encoding.UTF8
            );
        }

        public JsonResult<GolferDto> Get(int id)
        {
            var golfer = _golferService.GetById(id);

            return Json(Mapper.Map<GolferDto>(golfer), new JsonSerializerSettings(), Encoding.UTF8);
        }

        // POST api/golfers
        public HttpResponseMessage Post([FromBody]GolferDto golferDto)
        {
            var golfer = Mapper.Map<Golfer>(golferDto);

            _golferService.Create(golfer);

            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        // PUT api/golfers/5
        public JsonResult<GolferDto> Put(int id, [FromBody]GolferDto golfer)
        {
            var golferToUpdate = _golferService.GetById(id);

            golferToUpdate = Mapper.Map(golfer, golferToUpdate);
            golferToUpdate.Id = id;

            _golferService.Update(golferToUpdate);

            return Json(Mapper.Map<GolferDto>(golferToUpdate), new JsonSerializerSettings(), Encoding.UTF8);
        }

        // DELETE api/golfers/5
        public HttpResponseMessage Delete(int id)
        {
            var golferToDelete = _golferService.GetById(id);

            _golferService.Delete(golferToDelete);

            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
