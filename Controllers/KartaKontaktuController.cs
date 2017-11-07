using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace KartaPracy.Controllers
{
    using Models;
    using ViewModels;

    public class KartaKontaktuController : Controller
    {
        private ApplicationDbContext _context;

        public KartaKontaktuController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: KartaKontaktu
        public ActionResult Index()
        {
            var plan = _context.KartaKontaktus.Include(c=>c.Sklep).ToList();
            return View(plan);
        }

        public ActionResult New()
        {
            var sklepy = _context.Skleps.ToList();
            var viewModel = new KartaKontaktuViewModel
            {
                KartaKontaktu = new KartaKontaktu(),
                Skleps = sklepy
                
            };
            return View("ZdarzenieFormularz", viewModel);
        }

        public ActionResult Edit()
        {
            throw new NotImplementedException();
        }

        public ActionResult Save(KartaKontaktu kartaKontaktu)
        {
            if (kartaKontaktu.Id == 0)
            {
                _context.KartaKontaktus.Add(kartaKontaktu);
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "KartaKontaktu");
        }
    }
}