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
    public class OgrenciController : Controller
    {
        private readonly IOgrenciRepository _OgrenciRepository;

        private readonly IAlanRepository _AlanRepository;
        public OgrenciController(IOgrenciRepository ogrenciRepository,IAlanRepository alanRepository)
        {
            _OgrenciRepository = ogrenciRepository;
            _AlanRepository = alanRepository;
        }

        public ActionResult Index()
        {
            var school = _OgrenciRepository.GetAll().ToList().OrderBy(x=>x.OgrenciAdi).ToList();
            return View(school);
        }

        public ActionResult Create()
        {
            AlanDoldur();
            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Create(Ogrenci ogr)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            _OgrenciRepository.Insert(ogr);
            _OgrenciRepository.Save();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            AlanDoldur();
            var ogr = _OgrenciRepository.GetById(id.Value);

            if (ogr==null)
            {
                return HttpNotFound();
            }

            return View(ogr);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Edit(int? id,Ogrenci ogr)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var get = _OgrenciRepository.GetById(id.Value);
            if (get==null)
            {
                return HttpNotFound();
            }
            _OgrenciRepository.Update(ogr);
            _OgrenciRepository.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (id == null )
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var query = _OgrenciRepository.GetById(id.Value);
           

            if (query == null)
                return HttpNotFound();

            return View(query);

        }

        
        private  void AlanDoldur(object nesne = null)
        {
            var alanList = _AlanRepository.GetAll().ToList();
            var selectList = new SelectList(alanList, "AlanId", "SinifAdi", nesne);

            ViewData.Add("AlanId", selectList);
        }
    }
}