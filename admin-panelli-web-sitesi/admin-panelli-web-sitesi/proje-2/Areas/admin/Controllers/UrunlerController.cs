using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proje_2.Controllers;
using proje_2.Models;


namespace proje_2.Areas.admin.Controllers
{
    [Authorize]
    public class UrunlerController : Controller
    {
        // GET: admin/Urunler
        public ActionResult Index()
        {

            using (kahve2020Entities db = new kahve2020Entities())
            {
                var model = db.urunler.ToList();
                return View(model);
            }

        }
        public ActionResult Yeni()
        {
            var model = new urunler();
            return View("UrunForm", model);

        }
        public ActionResult Guncelle(int id)
        {
            using (kahve2020Entities db = new kahve2020Entities())
            {
                var model = db.urunler.Find(id);
                if(model==null)
                {
                    return HttpNotFound();
                }
                return View("UrunForm",model);
            }
        }
        public ActionResult Kaydet(urunler gelenUrun)
        {
            if(!ModelState.IsValid)
            {
                return View("UrunForm", gelenUrun);
            }
            using (kahve2020Entities db = new kahve2020Entities())
            {
                if(gelenUrun.Id==0) //yeni ürün kayıt
                {
                    if(gelenUrun.fotofile==null)
                    {
                        ViewBag.HataFoto = "Lütfen Resim Yükleyin";
                        return View("UrunForm", gelenUrun);
                    }

                    string fotoAdi = Seo.DosyaAdiDuzenle(gelenUrun.fotofile.FileName);
                    gelenUrun.foto = fotoAdi;
                    db.urunler.Add(gelenUrun);
                    gelenUrun.fotofile.SaveAs(Path.Combine(Server.MapPath("~/Content/img"), Path.GetFileName(fotoAdi)));
                    TempData["urun"] = "Ürün Başarılı Bir Şekilde Eklendi.";
                }
                else           //güncelleme
                {
                    var GuncellenecekVeri = db.urunler.Find(gelenUrun.Id);
                    if(gelenUrun.fotofile!=null)
                    {
                        string fotoAdi = Seo.DosyaAdiDuzenle(gelenUrun.fotofile.FileName);
                        gelenUrun.foto = fotoAdi;
                        gelenUrun.fotofile.SaveAs(Path.Combine(Server.MapPath("~/Content/img"), Path.GetFileName(fotoAdi)));
                    }

                    db.Entry(GuncellenecekVeri).CurrentValues.SetValues(gelenUrun);
                    TempData["urun"] = "Ürün Başarılı Bir Şekilde Güncellendi.";
                }
                db.SaveChanges();
                return RedirectToAction("index");
            }
            
        }

        public ActionResult Sil(int Id)
        {
            using(kahve2020Entities db=new kahve2020Entities())
            {
                var silinecekUrun = db.urunler.Find(Id);
                if(silinecekUrun==null)
                {
                    return HttpNotFound();
                }

                db.urunler.Remove(silinecekUrun);
                db.SaveChanges();
                TempData["urun"] = "Ürün Başarılı Bir Şekilde Silindi.";
                return RedirectToAction("index");
            }
        }
    }

}