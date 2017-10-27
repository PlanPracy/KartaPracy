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


        public ActionResult Edit(byte id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Save(Kontakt kontakt)
        {
            if (kontakt.Id == 0)
            {
                _context.Kontakts.Add(kontakt);
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Kontakt");
        }
    }
}