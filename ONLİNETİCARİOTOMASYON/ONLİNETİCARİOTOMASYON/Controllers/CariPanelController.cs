using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ONLİNETİCARİOTOMASYON.Models.Sınıflar;
namespace ONLİNETİCARİOTOMASYON.Controllers
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail = (String)Session["carimail"];
            var bilgiler = c.caris.FirstOrDefault(x => x.carimail ==mail);
            ViewBag.m = mail;
            return View(bilgiler);
        }
        public ActionResult Siparişlerim()
        {
            var mail = (String)Session["carimail"];
            var id = c.caris.Where(x => x.carimail == mail.ToString()).Select(y => y.cariid).FirstOrDefault();
            var degerler = c.caris.Where(x => x.cariid == id).ToList();
            return View(degerler);
        }
    }
}