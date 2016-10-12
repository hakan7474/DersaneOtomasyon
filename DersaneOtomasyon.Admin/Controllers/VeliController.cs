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
    public class VeliController : Controller
    {
        private readonly IVeliRepository _veliRepository;
        private readonly IOgrenciRepository _ogrenciRepository;
        public VeliController(IVeliRepository veliRepository, IOgrenciRepository ogrenciRepository)
        {
            _veliRepository = veliRepository;
            _ogrenciRepository = ogrenciRepository;
        }


        public ActionResult Index()
        {
            var veli = _veliRepository.GetAll().ToList();
            return View(veli);
        }

        public ActionResult Create()
        {
            AlanDoldur();
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Create(Veli veli)
        {
            
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            _veliRepository.Insert(veli);
            _veliRepository.Save();

          
            return RedirectToAction("Index");

        }


        private void AlanDoldur(object nesne = null)
        {
            var ogrList = _ogrenciRepository.GetAll().ToList();
            var selectList = new SelectList(ogrList, "OgrenciId", "Tc", nesne);

            ViewData.Add("OgrenciId", selectList);
        }
    }
}