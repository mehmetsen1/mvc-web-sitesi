using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proje_2.Models;

namespace proje_2.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }



        [Route("hakkimizda")]
        public ActionResult Hakkimizda()
        {
            using (kahve2020Entities db = new kahve2020Entities())
            {

                var model = db.hakkimizda.Find(2);
                return View(model);
            }

        }



        [Route("urunler")]
        public ActionResult Urunler()
        {
            using (kahve2020Entities db = new kahve2020Entities())
            {
                var model = db.urunler.Where(x => x.aktif == true).OrderBy(x => x.sira).ToList();
                return View(model);

            }

        }

        [Route("urun/{id}/{baslik}")]
        public ActionResult Urundetay(int id)
        {
            using (kahve2020Entities db = new kahve2020Entities())
            {
                var model = db.urunler.Where(x => x.aktif == true && x.Id == id).FirstOrDefault();
                if(model==null)
                {
                    return HttpNotFound();

                }
                return View(model);
            }
        }

        [Route("magaza")]
        public ActionResult Magaza()
        {
            return View();
        }
        [Route("iletisim")]
        public ActionResult Iletisim()
        {
            return View();
        }
    }
}