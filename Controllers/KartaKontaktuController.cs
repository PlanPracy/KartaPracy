using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;

namespace KartaPracy.Controllers
{
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using ClosedXML.Excel;
    using Repozytorium.Models;
    using ViewModels;

    public class KartaKontaktuController : Controller
    {
        private KartaDbContext _context;

        public KartaKontaktuController()
        {
            _context = new KartaDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: KartaKontaktu
        public ActionResult Index()
        {
            var plan = _context.KartaKontaktus.Include(c => c.Sklep).ToList();
            return View(plan);
        }

        public ActionResult ExportData()
        {
            String constring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            string query = "select k.Id, k.DataSpotkania, k.FormaKontaktu, k.Notatki, s.Nazwa, s.Miejscowosc, s.Ulica, s.NrLokalu, w.Nazwisko, w.Telefon From KartaKontaktus as k, Sklep as s, Kontakty as w where k.SklepId = s.SklepId and s.SklepId = w.SklepId";
            DataTable dt = new DataTable();
            dt.TableName = "KartaKOntaktus";

            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.Fill(dt);
            con.Close();

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                wb.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                wb.Style.Font.Bold = true;

                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= KartaPracyRaport.xlsx");

                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
            return RedirectToAction("Index", "KartaKontaktu");
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }
        public ActionResult Details(int id)
        {
            var wizyta = _context.KartaKontaktus.Include(c => c.Sklep).SingleOrDefault(c => c.Id == id);
            if (wizyta == null)
                HttpNotFound();
            return View(wizyta);
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

            //select Count (SklepId) from KartaKontaktus where SklepId=1
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
                int obecneIdSklepu = kartaKontaktu.SklepId;
                int count = 0;
                foreach (var item in _context.KartaKontaktus.ToList())
                {
                    int id = obecneIdSklepu;
                    count = _context.KartaKontaktus.Where(x => x.Sklep.SklepId == id).Count();
                }
                kartaKontaktu.NrSpotkania = ++count;

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