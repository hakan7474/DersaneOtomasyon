using DersaneOtomasyon.Core.Infrastructure;
using DersaneOtomasyon.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DersaneOtomasyon.Admin.Controllers
{
    public class OdemeController : Controller
    {
        private readonly IOdemeRepository _odemeRepository;
        private readonly IOgrenciRepository _ogrenciRepository;
        public OdemeController(IOdemeRepository odemeRepository, IOgrenciRepository ogrenciRepository)
        {
            _ogrenciRepository = ogrenciRepository;
            _odemeRepository = odemeRepository;
        }

        public ActionResult OdemeListele()
        {
            var list = _odemeRepository.GetAll().OrderByDescending(x => x.Ogrenci.OgrenciTc).ToList();
          return View(list);
        }
        public ActionResult Index(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var ogrenci = _ogrenciRepository.GetById(id.Value);

            var OgrenciOdeme = ogrenci.Odeme;

            ViewBag.SelectedOgrenci = ogrenci;

            return View(OgrenciOdeme);
        }

        public ActionResult Create(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var ogrenci = _ogrenciRepository.GetById(id.Value);

           
            ViewBag.SelectedOgrenci = ogrenci;

            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Create(Odeme odeme,int? id)
        {
            odeme.OgrenciId = id.Value;
            _odemeRepository.Insert(odeme);
            _odemeRepository.Save();
            return RedirectToAction("Index",new {id=id.Value });
        }

        public ActionResult Details(int? ogrId, int? OdemeId)
        {
            if (ogrId == null && OdemeId== null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var ogr = _ogrenciRepository.GetById(ogrId.Value);

            ViewBag.SelectedOgrenci = ogr;

            var odeme = _odemeRepository.GetById(OdemeId.Value);

            if (odeme == null)
            {
                return HttpNotFound();
            }

            return View(odeme);
        }

        // Hata var

        public ActionResult Edit(int? odemeId, int? ogrId)
        {
            if (odemeId == null || ogrId == null)   /// odeme id null geliyor.
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var ogr = _ogrenciRepository.GetById(ogrId.Value);

            ViewBag.SelectedOgrenci = ogr;

            var odeme = _odemeRepository.GetById(odemeId.Value);
            if (odeme== null)
            {
                return HttpNotFound();
            }

            return View(odeme);
                        
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Edit(Odeme odeme)
        {
            if (!ModelState.IsValid)
            {
                return View(odeme);
            }

            _odemeRepository.Update(odeme);
            _odemeRepository.Save();

            return RedirectToAction("Index", new { id = odeme.OgrenciId });
        }

        public ActionResult Delete(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var odeme = _odemeRepository.GetById(id.Value);

            if (odeme==null)
            {
                return HttpNotFound();
            }

            return View(odeme);
        }

        [HttpPost,ValidateAntiForgeryToken,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id,FormCollection collection)
        { 

            _odemeRepository.Delete(id);
            _odemeRepository.Save();

            return RedirectToAction("Index",new {id=collection["ogrenciId"]});
        }


    }
}