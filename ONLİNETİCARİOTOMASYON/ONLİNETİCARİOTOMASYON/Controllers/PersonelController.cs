using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ONLİNETİCARİOTOMASYON.Models.Sınıflar;

namespace ONLİNETİCARİOTOMASYON.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.personels.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Departmens.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.departmanad,
                                               Value = x.departmanid.ToString()

                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel d)
        {
            c.personels.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Departmens.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.departmanad,
                                               Value = x.departmanid.ToString()

                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var ürn1 = c.personels.Find(id);
            return View("PersonelGetir", ürn1);
        }
        public ActionResult PersonelGuncelle(Personel p)
        {
            var urnn = c.personels.Find(p.personelid);
            urnn.personelad = p.personelad;
            urnn.personelsoyad = p.personelsoyad;
            urnn.personelgorsel = p.personelgorsel;
            urnn.departmanid= p.departmanid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}