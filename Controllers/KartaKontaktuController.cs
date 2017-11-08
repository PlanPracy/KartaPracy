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

        public ActionResult Edit(int id)
        {
            var kartaKontaktu = _context.KartaKontaktus.SingleOrDefault(c => c.Id == id);
            if (kartaKontaktu == null)
                return HttpNotFound();

            var viewModel = new KartaKontaktuViewModel
            {
                KartaKontaktu = kartaKontaktu,
                Skleps = _context.Skleps.ToList()
            };
            return View("ZdarzenieFormularz", viewModel);
        }

        public ActionResult Save(KartaKontaktu kartaKontaktu)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new KartaKontaktuViewModel
                {
                    KartaKontaktu = kartaKontaktu,
                    Skleps = _context.Skleps.ToList()
                };
                return View("ZdarzenieFormularz", viewModel);
            }
            if (kartaKontaktu.Id == 0)
            {
                _context.KartaKontaktus.Add(kartaKontaktu);
            }
            else
            {
                var kartaInDb = _context.KartaKontaktus.Single(s => s.Id == kartaKontaktu.Id);
                kartaInDb.DataSpotkania = kartaKontaktu.DataSpotkania;
                kartaInDb.SklepId = kartaKontaktu.SklepId;
                kartaInDb.FormaKontaktu = kartaKontaktu.FormaKontaktu;
                kartaInDb.Notatki = kartaKontaktu.Notatki;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "KartaKontaktu");
        }
    }
}