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
        private ApplicationDbContext _context1;

        public KontaktController()
        {
            _context1 = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context1.Dispose();
        }

        // GET: Kontakt
        public ActionResult Index()
        {
            var kontakty = _context1.Kontakts.ToList();
            return View(kontakty);
        }

        public ActionResult New()
        {
            var viewModel = new KontaktViewModel
            {
                Kontakt = new Kontakt()
            };

            return View("KontaktFormularz", viewModel);
            
        }


        public ActionResult Edit(byte id)
        {
            var kontakt = _context1.Kontakts.SingleOrDefault(c => c.Id == id);
            if (kontakt == null)
                return HttpNotFound();

            var viewModel = new KontaktViewModel()
            {
              Kontakt = kontakt
            };
            return View("KontaktFormularz", viewModel);
        }

        public ActionResult Save(Kontakt kontakt)
        {
            var obecnyKontaktId = 1;
            

            if (_context1.Kontakts.Any())
            {
                obecnyKontaktId = _context1.Kontakts.Max(s => s.Id) + 1;

            }

            var obenyId = (byte)obecnyKontaktId;
            var kon = new Kontakt
            {
                Id = obenyId,
                Nazwisko = kontakt.Nazwisko,
                Telefon = kontakt.Telefon,
                Email = kontakt.Email,
                Opis = kontakt.Opis,
                OsobaDoKontaktu = kontakt.OsobaDoKontaktu
            };


            if (kontakt.Id == 0)
            {
                _context1.Kontakts.Add(kon);
            }
            else
            {
                var kontaktInDb = _context1.Kontakts.Single(s => s.Id == kontakt.Id);
                kontaktInDb.Nazwisko= kontakt.Nazwisko;
                kontaktInDb.Telefon = kontakt.Telefon;
                kontaktInDb.Email = kontakt.Email;
                kontaktInDb.OsobaDoKontaktu = kontakt.OsobaDoKontaktu;
            }
            
            _context1.SaveChanges();
            return RedirectToAction("Index", "Kontakt");
        }
    }
}