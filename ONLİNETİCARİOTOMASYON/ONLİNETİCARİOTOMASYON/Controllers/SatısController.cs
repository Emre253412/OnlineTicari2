using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ONLİNETİCARİOTOMASYON.Models.Sınıflar;
namespace ONLİNETİCARİOTOMASYON.Controllers
{
    public class SatısController : Controller
    {
        // GET: Satıs
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.satışhareketis.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult SatısEkle()
        {
            List<SelectListItem> deger1 = (from x in c.ürünlers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ürünad,
                                               Value = x.ürünid.ToString()

                                           }).ToList();
            List<SelectListItem> deger2 = (from x in c.caris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.cariad +" "+x.carisoyad,
                                               Value = x.cariid.ToString()

                                           }).ToList();
            List<SelectListItem> deger3 = (from x in c.personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.personelad+" "+x.personelsoyad,
                                               Value = x.personelid.ToString()

                                           }).ToList();
            ViewBag.dgr3 = deger3;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult SatısEkle(Satışhareketi d)
        {
            d.tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.satışhareketis.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatısGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.ürünlers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ürünad,
                                               Value = x.ürünid.ToString()

                                           }).ToList();
            List<SelectListItem> deger2 = (from x in c.caris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.cariad + " " + x.carisoyad,
                                               Value = x.cariid.ToString()

                                           }).ToList();
            List<SelectListItem> deger3 = (from x in c.personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.personelad + " " + x.personelsoyad,
                                               Value = x.personelid.ToString()

                                           }).ToList();
            ViewBag.dgr3 = deger3;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr1 = deger1;
            return View();
            var dep = c.satışhareketis.Find(id);
            return View("SatısGetir", dep);
        }
        public ActionResult SatısGuncelle(Satışhareketi d)
        {
            var depa = c.satışhareketis.Find(d.satısid);
            depa.cariid = d.cariid;
            depa.adet = d.adet;
            depa.fiyat = d.fiyat;
            depa.personelid = d.personelid;
            depa.toplamtutar = d.toplamtutar;
            depa.tarih = d.tarih;
            depa.ürünid = d.ürünid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatısDetay(int id)
        {
            var degerler = c.satışhareketis.Where(x => x.satısid == id).ToList();
            return View(degerler);
        }
        public ActionResult Ürünlistesi()
        {

            var degerler = c.satışhareketis.ToList();
            return View(degerler);
        }
    }
}