using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace KartaPracy.Controllers.Api
{
    using AutoMapper;
    using Dtos;
    using Models;

    public class KartaKontaktuController : ApiController
    {
        private ApplicationDbContext _context;

        public KartaKontaktuController()
        {
            _context = new ApplicationDbContext();
        }

        //Get /api/kartakontaktu
        public IEnumerable<KartaKontaktu> GetZdarzenia()
        {
            return _context.KartaKontaktus.ToList();
        }
        //public IEnumerable<KartaKontaktuDto> GetZdarzenia()
        //{
        //    return _context.KartaKontaktus.ToList().Select(Mapper.Map<KartaKontaktu, KartaKontaktuDto>);
        //}

       
        //Get /api/kartakontaktu/1
        //public IHttpActionResult GetZdarzenia(int id)
        //{
        //    KartaKontaktu zdarzenie;
        //    zdarzenie = _context.KartaKontaktus.SingleOrDefault(c => c.Id == id);
        //    if (zdarzenie == null)
        //      //  return NotFound();
        //    throw new HttpResponseException(HttpStatusCode.NotFound);
        //    return zdarzenie;
        //}
        //Delete /api/kartakontaktu
        [HttpDelete]
        public void DeleteZdarzenie(int id)
        {
            var zdarzeniaInDb = _context.KartaKontaktus.SingleOrDefault(c => c.Id == id);
            if (zdarzeniaInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.KartaKontaktus.Remove(zdarzeniaInDb);
            _context.SaveChanges();
        }

    }
   
}
