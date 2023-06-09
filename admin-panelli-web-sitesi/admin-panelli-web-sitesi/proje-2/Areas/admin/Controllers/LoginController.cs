using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proje_2.Models;
using System.Web.Security;



namespace proje_2.Areas.admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: admin/Login
        public ActionResult Index()
        {
            return View();
        } public ActionResult Alogin(kullanicilar kullaniciFormu)
        {
            using(kahve2020Entities db=new kahve2020Entities())
            {
                var KullaniciVarMi = db.kullanicilar.FirstOrDefault(x=>x.kad==kullaniciFormu.kad && x.sifre==kullaniciFormu.sifre);
                if(KullaniciVarMi!=null)
                {
                    FormsAuthentication.SetAuthCookie(KullaniciVarMi.kad, kullaniciFormu.BeniHatirla);

                    return RedirectToAction ("/index", "Urunler");

                }

                ViewBag.Hata = "Kullanıcı adı veya şifre hatalı!";
                return View("index");
            }
            
        }
    }
}