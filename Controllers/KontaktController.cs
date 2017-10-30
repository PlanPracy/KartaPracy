using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KartaPracy.Controllers
{
    using Models;
    using ViewModels;

    public class KontaktController : Controller
    {
        private ApplicationDbContext _context;

        public KontaktController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Kontakt
        public ActionResult Index()
        {
            var kontakty = _context.Kontakts.ToList();
            return View(kontakty);
        }

        public ActionResult New()
        {
            var viewModel = new KontaktViewModel();

            return View("KontaktFormularz", viewModel);
            
        }

        [HttpPost]
        public ActionResult Edit(byte id)
        {
            var kontakt = _context.Kontakts.SingleOrDefault(c => c.Id == id);
            if (kontakt == null)
                return HttpNotFound();

            var viewModel = new KontaktViewModel
            {
                Kontakt = kontakt
            };
            return View("KontaktFormularz", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Kontakt kontakt)
        {
          
            if (kontakt.Id == 0)
            {
                _context.Kontakts.Add(kontakt);
            }
            else
            {
                var kontaktInDb = _context.Kontakts.SingleOrDefault(k => k.Id == kontakt.Id);
                if (kontaktInDb != null)
                {
                    kontaktInDb.Nazwisko = kontakt.Nazwisko;
                    kontaktInDb.Email = kontakt.Email;
                    kontaktInDb.Telefon = kontakt.Telefon;
                    kontaktInDb.Opis = kontakt.Opis;
                    kontaktInDb.OsobaDoKontaktu = kontakt.OsobaDoKontaktu;
                }
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Kontakt");
        }
    }
}