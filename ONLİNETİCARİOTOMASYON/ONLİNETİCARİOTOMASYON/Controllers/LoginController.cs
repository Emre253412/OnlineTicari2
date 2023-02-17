using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ONLİNETİCARİOTOMASYON.Models.Sınıflar;
namespace ONLİNETİCARİOTOMASYON.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        Context c = new Context();

        public object Formsauthentication { get; private set; }

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult Partial1 ()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Partial1(Cari p)
        {
            c.caris.Add(p);
            c.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public ActionResult carilogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult carilogin(Cari s)
        {
            var bilgiler = c.caris.FirstOrDefault(x => x.carimail == s.carimail && x.sifre == s.sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.carimail, false);
                Session["carimail"] = bilgiler.carimail.ToString();
                return RedirectToAction("Index", "CariPanel");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult adminlogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult adminlogin(Admin s)
        {
            var bilgiler = c.admins.FirstOrDefault(x => x.kullanıcıad== s.kullanıcıad && x.sifre == s.sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.kullanıcıad, false);
                Session["kullanıcıad"] = bilgiler.kullanıcıad.ToString();
                return RedirectToAction("Index", "kategori");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}