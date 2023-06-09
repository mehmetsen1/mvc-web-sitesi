using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proje_2.Models;
using proje_2.Controllers;
using System.IO;

namespace proje_2.Areas.admin.Controllers
{   
    [Authorize]
    public class HakkimizdaController : Controller
    {
        // GET: admin/Hakkimizda
        public ActionResult Index()
        {
            using(kahve2020Entities db=new kahve2020Entities())
            {
                var model = db.hakkimizda.First();
                return View(model);
            }
            
        }
        public ActionResult HakkimizdaGuncelle()
        {
            using(kahve2020Entities db=new kahve2020Entities())
            {
                var model = db.hakkimizda.First();
                return View(model);
            }
        }

        [HttpPost]

        public ActionResult Kaydet(hakkimizda Gelenveri)
        {
            using(kahve2020Entities db=new kahve2020Entities())
            {
                var GuncellenecekVeri = db.hakkimizda.First();
                if(!ModelState.IsValid)
                {
                    return View("HakkimizdaGuncelle", Gelenveri);

                }
                if(Gelenveri.fotofile!=null)
                {
                    Gelenveri.foto = Seo.DosyaAdiDuzenle(Gelenveri.fotofile.FileName);
                    Gelenveri.fotofile.SaveAs(Path.Combine(Server.MapPath("~/Content/img"), Path.GetFileName(Gelenveri.foto)));

                }
                db.Entry(GuncellenecekVeri).CurrentValues.SetValues(Gelenveri);
                db.SaveChanges();
                TempData["hakkimdagüncelle"] = "Güncellendi";
                return RedirectToAction("index", "hakkimizda");
            }
        }
    }   


}