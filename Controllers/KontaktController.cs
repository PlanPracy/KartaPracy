using System.Linq;
using System.Web.Mvc;

namespace KartaPracy.Controllers
{
    using System.Net;
    using Models;
    using Repozytorium.Models;

    public class KontaktController : Controller
    {
        private KartaDbContext _context1;

        public KontaktController()
        {
            _context1 = new KartaDbContext();
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

        public ActionResult Edit(int id)
        {
            var kontakt = _context1.Kontakts.SingleOrDefault(c => c.Id == id);
            if (kontakt == null)
                return HttpNotFound();


            return View("KontaktFormularz", kontakt);
        }

        public ActionResult Save(Kontakt kontakt)
        {

            if (!ModelState.IsValid)
            {

                return View("KontaktFormularz", kontakt);
            }


            var kontaktInDb = _context1.Kontakts.Single(s => s.Id == kontakt.Id);
            kontaktInDb.Nazwisko = kontakt.Nazwisko;
            kontaktInDb.Telefon = kontakt.Telefon;
            kontaktInDb.Email = kontakt.Email;
            kontaktInDb.Imie = kontakt.Imie;
            kontaktInDb.Opis = kontakt.Opis;

            _context1.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult Create(int id)
        {
            Sklep car = _context1.Skleps.Single(a => a.SklepId == id);
            // Tworzymy nowy obiekt kontaktu
            Kontakt comm = new Kontakt();
            // Wypełniamy obiekt niezbędnymi informacjami
            comm.SklepId = id;
            return View(comm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SklepId,Nazwisko,Imie,Email,Opis,Telefon")] Kontakt kontakty)
        {
            if (ModelState.IsValid)
            {
                _context1.Kontakts.Add(kontakty);
                _context1.SaveChanges();
                return RedirectToAction("Index", "Sklep");
            }

            ViewBag.SklepId = new SelectList(_context1.Skleps, "Id", "Nazwa", kontakty.SklepId);
            return View(kontakty);
        }


        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kontakt kontakt = _context1.Kontakts.Find(id);
            if (kontakt == null)
            {
                return HttpNotFound();
            }
            return View(kontakt);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kontakt kontakt = _context1.Kontakts.Find(id);
            _context1.Kontakts.Remove(kontakt);
            _context1.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}