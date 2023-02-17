using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ONLİNETİCARİOTOMASYON.Models.Sınıflar;
namespace ONLİNETİCARİOTOMASYON.Controllers
{
    public class ÜrünController : Controller
    {
        Context c = new Context();
        public ActionResult Index(string p)
        {
            var urunler = from x in c.ürünlers select x;
            if (!String.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(y => y.ürünad.Contains(p));
            }
            return View(urunler.ToList());
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> deger1 = (from x in c.kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.kategorıad,
                                               Value = x.kategoriid.ToString()

                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(Ürünler u)
        {
            c.ürünlers.Add(u);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ÜrünSil(int id)
        {
            var ürn = c.ürünlers.Find(id);
            ürn.durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ÜrünGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.kategorıad,
                                               Value = x.kategoriid.ToString()

                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var ürn1 = c.ürünlers.Find(id);
            return View("ÜrünGetir", ürn1);
        }
        public ActionResult ÜrünGuncelle(Ürünler p)
        {
            var urnn = c.ürünlers.Find(p.ürünid);
            urnn.ürünad = p.ürünad;
            urnn.marka = p.marka;
            urnn.satışfiyat = p.satışfiyat;
            urnn.Kategoriid = p.Kategoriid;
            urnn.ürüngörsel = p.ürüngörsel;
            urnn.durum = p.durum;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Ürünlistesi()
        {

            var degerler = c.ürünlers.ToList();
            return View(degerler);
        }
    }
}