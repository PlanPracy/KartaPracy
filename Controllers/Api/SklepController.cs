using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KartaPracy.Controllers.Api
{
    using AutoMapper;
    using Dtos;
    using Models;

    public class SklepController : ApiController
    {
        private ApplicationDbContext _context;

        public SklepController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<SklepDto> GetSklepy()
        {
            return _context.Skleps.ToList().Select(Mapper.Map<Sklep, SklepDto>);
        }

        //Get /api/sklep/1
        public IHttpActionResult GetSklepy(int id)
        {
            var customer = _context.Skleps.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();
            //  throw new HttpResponseException(HttpStatusCode.NotFound);
            return Ok(Mapper.Map<Sklep, SklepDto>(customer));
        }

        //Delete /api/sklep/1
        [HttpDelete]
        public void DeleteSklep(int id)
        {
            var sklepyInDb = _context.Skleps.SingleOrDefault(c => c.Id == id);
            if (sklepyInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Skleps.Remove(sklepyInDb);
            _context.SaveChanges();
        }
    }
}
