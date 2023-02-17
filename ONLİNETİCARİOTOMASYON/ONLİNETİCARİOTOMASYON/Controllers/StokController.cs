using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ONLİNETİCARİOTOMASYON.Models.Sınıflar;
namespace ONLİNETİCARİOTOMASYON.Controllers
{
    public class StokController : Controller
    {
        // GET: Stok
        Context c = new Context();
        public ActionResult Index()
        {
            var stok = c.stoks.ToList();
            return View(stok);
        }
        [HttpGet]
        public ActionResult YeniStok()
        {
            List<SelectListItem> deger1 = (from x in c.ürünlers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ürünad,
                                               Value = x.ürünid.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult YeniStok(Stok u)
        {
            c.stoks.Add(u);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult StokSil(int id)
        {
            var stok1 = c.stoks.Find(id);
            c.stoks.Remove(stok1);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult StokGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.ürünlers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ürünad,
                                               Value = x.ürünid.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var stok= c.stoks.Find(id);
            return View("StokGetir", stok);
        }
        public ActionResult StokGuncelle(Stok n)
        {
            var urnn = c.stoks.Find(n.stokid);
            urnn.ürünid = n.ürünid;
            urnn.adet = n.adet;
            urnn.arızalıürünsayısı = n.arızalıürünsayısı;
            urnn.ürünid = n.ürünid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}