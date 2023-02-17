using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ONLİNETİCARİOTOMASYON.Models.Sınıflar;
namespace ONLİNETİCARİOTOMASYON.Controllers
{
    public class CariController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.caris.Where(x=> x.durum==true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult CariEkle()
        {
            return View();
        }
        public ActionResult CariEkle(Cari k)
        {
            k.durum = true;
            c.caris.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSil(int id)
        {
            var dpr = c.caris.Find(id);
            dpr.durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariGetir(int id)
        {
            var dep = c.caris.Find(id);
            return View("CariGetir", dep);
        }
        public ActionResult CariGuncelle(Cari d)
        {
            var depa = c.caris.Find(d.cariid);
            depa.cariad = d.cariad;
            depa.carisoyad = d.carisoyad;
            depa.carisehir = d.carisehir;
            depa.carimail = d.carimail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriSatis(int id)
        {
            var degerler = c.satışhareketis.Where(x => x.cariid == id).ToList();
            var cari1 = c.caris.Where(x => x.cariid == id).Select(y => y.cariad + " " + y.carisoyad).FirstOrDefault();
            ViewBag.cari = cari1;
            return View(degerler);
        }
    }
}