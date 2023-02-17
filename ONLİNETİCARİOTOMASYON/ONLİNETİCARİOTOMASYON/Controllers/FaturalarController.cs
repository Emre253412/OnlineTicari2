using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ONLİNETİCARİOTOMASYON.Models.Sınıflar;
namespace ONLİNETİCARİOTOMASYON.Controllers
{
    public class FaturalarController : Controller
    {
        // GET: Faturalar
        Context c = new Context();
        public ActionResult Index()
        {
            var fatura = c.faturalars.ToList();
            return View(fatura);
        }
        [HttpGet]
        public ActionResult FaturaEkle()
        {
        
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Faturalar d)
        {
            c.faturalars.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaGetir(int id) { 
        
            var ürn1 = c.faturalars.Find(id);
            return View("FaturaGetir", ürn1);
        }
        public ActionResult FaturaGuncelle(Faturalar p)
        {
            var urnn = c.faturalars.Find(p.faturaid);
            urnn.faturaserino= p.faturaserino;
            urnn.faturasırano = p.faturasırano;
            urnn.saat = p.saat;
            urnn.tarih = p.tarih;
            urnn.vergidairesi = p.vergidairesi;
            urnn.teslimalan = p.teslimalan;
            urnn.teslimeden= p.teslimeden;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaDetay(int id)
        {
            var degerler = c.faturakalems.Where(x => x.Faturaid == id).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult FaturaKalemEkle()
        {

            return View();
        }
        public ActionResult FaturaKalemEkle(Faturakalem d)
        {
            c.faturakalems.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}