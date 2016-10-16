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

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); 
            }

            var getir = _odemeRepository.GetById(id.Value);

            if (getir == null)
            {
                return HttpNotFound();
            }

            return View(getir);
        }
    }
}