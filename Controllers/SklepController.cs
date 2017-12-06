namespace KartaPracy.Controllers
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;
    using Repozytorium.Models;
    using ViewModels;

    public class SklepController : Controller
    {
        // GET: Sklep
        private KartaDbContext _context;

        public SklepController()
        {
            _context = new KartaDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var sklepy = _context.Skleps.Include(s => s.FormatSklepu).ToList();
            return View(sklepy);
        }

        public ActionResult Details(int? id)
        {
            var sklep = _context.Skleps.Include(c => c.FormatSklepu).SingleOrDefault(c => c.SklepId == id);
            if (sklep == null)
                HttpNotFound();
            return View(sklep);
        }

        public ActionResult New()
        {
            var format = _context.FormatSklepus.ToList();

            var viewModel = new SklepViewModel
            {
                Sklep = new Sklep(),
                FormatSklepus = format
            };
            return View("SklepFormularz", viewModel);
        }


        [HttpPost]
        public ActionResult Save(Sklep sklep)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new SklepViewModel
                {
                    Sklep = sklep,
                    FormatSklepus = _context.FormatSklepus.ToList()
                };
                return View("SklepFormularz", viewModel);
            }

            if (sklep.SklepId == 0)
            {
                sklep.DataUtworzeniaSklepu = DateTime.Now;
                _context.Skleps.Add(sklep);
            }
            else
            {
                var sklepInDb = _context.Skleps.Single(s => s.SklepId == sklep.SklepId);
                sklepInDb.Nazwa = sklep.Nazwa;
                sklepInDb.FormatSklepuId = sklep.FormatSklepuId;
                sklepInDb.Nip = sklep.Nip;
                sklepInDb.Miejscowosc = sklep.Miejscowosc;
                sklepInDb.Ulica = sklep.Ulica;
                sklepInDb.NrLokalu = sklep.NrLokalu;
                sklepInDb.Kod = sklep.Kod;
                sklepInDb.Uwagi = sklep.Uwagi;
                sklepInDb.CzyParking = sklep.CzyParking;
                sklepInDb.CzySieciowy = sklep.CzySieciowy;
                sklepInDb.Powierzchnia = sklep.Powierzchnia;
                sklepInDb.TypSklepu = sklep.TypSklepu;

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Sklep");
        }

        public ActionResult Edit(int id)
        {
            var sklep = _context.Skleps.SingleOrDefault(c => c.SklepId == id);
            if (sklep == null)
                return HttpNotFound();

            var viewModel = new SklepViewModel
            {
                Sklep = sklep,
                // Kontakts = _context.Kontakts.ToList(),
                FormatSklepus = _context.FormatSklepus.ToList()
            };
            return View("SklepFormularz", viewModel);
        }
    }
}