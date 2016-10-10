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

        public OgrenciController(IOgrenciRepository ogrenciRepository)
        {
            _OgrenciRepository = ogrenciRepository;
        }

        public ActionResult Index()
        {
            var school = _OgrenciRepository.GetAll().ToList();
            return View(school);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Create(Ogrenci ogrenci)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
         
            _OgrenciRepository.Insert(ogrenci);
            _OgrenciRepository.Save();
            return RedirectToAction("Index");
        }
    }
}