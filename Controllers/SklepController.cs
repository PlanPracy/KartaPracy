namespace KartaPracy.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;
    using Models;
    using ViewModels;

    public class SklepController : Controller
    {
        // GET: Sklep
        private ApplicationDbContext _context;

        public SklepController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var sklepy = _context.Skleps.Include(s => s.Kontakt).Include(s=>s.FormatSklepu).ToList();
            return View(sklepy);
        }

        public ActionResult Details(int id)
        {
            var sklep = _context.Skleps.SingleOrDefault(c => c.Id == id);
            if (sklep == null)
                HttpNotFound();
            return View(sklep);
        }

        public ActionResult New()
        {
            var kontakt = _context.Kontakts.ToList();
            var format = _context.FormatSklepus.ToList();

            var viewModel = new SklepViewModel
            {
                Sklep = new Sklep(),
                Kontakts = kontakt,
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
                    Kontakts = _context.Kontakts.ToList(),
                    FormatSklepus = _context.FormatSklepus.ToList()
                };
                return View("SklepFormularz", viewModel);
            }

            if (sklep.Id == 0)
            {
                _context.Skleps.Add(sklep);
            }
            else
            {
                var sklepInDb = _context.Skleps.Single(s => s.Id == sklep.Id);
                sklepInDb.Nazwa = sklep.Nazwa;
                sklepInDb.KontaktId = sklep.KontaktId;
                sklepInDb.FormatSklepuId = sklep.FormatSklepuId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Sklep");
        }

        public ActionResult Edit(int id)
        {
            var sklep = _context.Skleps.SingleOrDefault(c => c.Id == id);
            if (sklep == null)
                return HttpNotFound();

            var viewModel = new SklepViewModel
            {
                Sklep = sklep,
                Kontakts = _context.Kontakts.ToList(),
                FormatSklepus = _context.FormatSklepus.ToList()
            };
            return View("SklepFormularz", viewModel);
        }

      
    }
}