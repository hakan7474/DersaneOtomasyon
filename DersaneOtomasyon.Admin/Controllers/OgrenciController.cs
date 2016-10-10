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
     
        private  void AlanDoldur(object nesne = null)
        {
            var alanList = _AlanRepository.GetAll().ToList();
            var selectList = new SelectList(alanList, "AlanId", "SinifAdi", nesne);

            ViewData.Add("AlanId", selectList);
        }
    }
}