using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KartaPracy.Controllers.Api
{
    using Models;

    public class KartaKontaktuController : ApiController
    {
        private ApplicationDbContext _context;

        public KartaKontaktuController()
        {
            _context = new ApplicationDbContext();
        }


    }
   
}
