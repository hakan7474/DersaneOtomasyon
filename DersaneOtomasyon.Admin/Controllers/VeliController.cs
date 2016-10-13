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
        public VeliController(IVeliRepository veliRepository)
        {
            _veliRepository = veliRepository;
        }

        public ActionResult Index()
        {
            var list = _veliRepository.GetAll().ToList();
            return View(list);
        }

        public ActionResult Create()
        {
            AlanDoldur();
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Create(Veli veli)
        {
            _veliRepository.Insert(veli);
            _veliRepository.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var find = _veliRepository.GetById(id.Value);

            if (find==null)
            {
                return HttpNotFound();
            }

            return View(find);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Edit(Veli veli)
        {
            _veliRepository.Update(veli);
            _veliRepository.Save();

            return RedirectToAction("Index");
        }


        public ActionResult Details(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var find = _veliRepository.GetById(id.Value);
            return View(find);
        }

     
        private void AlanDoldur(object nesne = null)
        {
            var alanList = _veliRepository.GetAll().ToList();
            var selectList = new SelectList(alanList, "OgrenciId", "OgrenciAdi", nesne);

            ViewData.Add("OgrenciId", selectList);
        }
    }
}