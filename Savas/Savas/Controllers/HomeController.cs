using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Savas.Models;

namespace Savas.Controllers
{
    public class HomeController : Controller
    {
        CaseEntities db = new CaseEntities();
        public ActionResult Index()
        {
           CaseEntities db = new CaseEntities();
          ViewBag.ayarlar = db.ayarlars;
            return View();
        }
        //*******************************************************
        ayarlar c = new ayarlar();
        public ActionResult About()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.ayarlar = db.ayarlars;

            return View();
        }



        [HttpPost]
        public ActionResult Kaydet(ayarlar a, String SAVASCIADI, string CANPUAN)/*, string ATAK, string DEFANS, string UZUNMESAFE, string KISAMESAFE*/
        {
         
            db.ayarlars.Add(a);
            db.SaveChanges();
            return RedirectToAction("About");
        }
        [HttpPost]
        public ActionResult Duzenle(ayarlar d)
        {
          
            ayarlar KL = db.ayarlars.FirstOrDefault(x => x.ID == d.ID);
            KL.SAVASCIADI = d.SAVASCIADI;
            KL.CANPUAN = d.CANPUAN;
            //KL.KISAMESAFE = d.KISAMESAFE;
            //KL.UZUNMESAFE = d.UZUNMESAFE;
            //KL.ATAK = d.ATAK;
            //KL.DEFANS = d.DEFANS;
            db.SaveChanges();
            return RedirectToAction("About");
        }

        public ActionResult Sil(int id)
        {
          
            ayarlar silinecek = db.ayarlars.FirstOrDefault(x => x.ID == id);
            db.ayarlars.Remove(silinecek);
            db.SaveChanges();
            return RedirectToAction("About");
        }

        //****************************************************

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.ayarlar = db.ayarlars;
            return View();
        }
    }

    
}