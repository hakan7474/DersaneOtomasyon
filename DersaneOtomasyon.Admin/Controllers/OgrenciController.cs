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
        public OgrenciController(IOgrenciRepository ogrenciRepository, IAlanRepository alanRepository)
        {
            _OgrenciRepository = ogrenciRepository;
            _AlanRepository = alanRepository;
        }

        public ActionResult Index()
        {
            var school = _OgrenciRepository.GetAll().ToList().OrderBy(x => x.OgrenciAdi).ToList();
            return View(school);
        }

        public ActionResult Create()
        {
            AlanDoldur();
            return View();
        }
        [HttpPost
            , ValidateAntiForgeryToken]
        public ActionResult Create(Ogrenci ogrenci)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            _OgrenciRepository.Insert(ogrenci);
            _OgrenciRepository.Save();
            return RedirectToAction("Index");
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var query = _OgrenciRepository.GetById(id.Value);


            if (query == null)
                return HttpNotFound();

            return View(query);

        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var edit = _OgrenciRepository.GetById(id.Value);

            if (edit==null)
            {
                return HttpNotFound();
            }
            AlanDoldur(edit.AlanId);
            return View(edit);
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Edit(Ogrenci ogr)
        {
            if (ModelState.IsValid)
            {
                _OgrenciRepository.Update(ogr);
                _OgrenciRepository.Save();
            }
            else
            {
                return new  HttpStatusCodeResult(HttpStatusCode.BadRequest);
            } 
            return RedirectToAction("Index");
        }



        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var find = _OgrenciRepository.GetById(id.Value);

            if (find == null)
            {
                return HttpNotFound();
            }

            return View(find);
        }

        [HttpPost,ValidateAntiForgeryToken,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            _OgrenciRepository.Delete(id.Value);
            _OgrenciRepository.Save();

            return RedirectToAction("Index");
        }
      

        #region Alanları getir
        private void AlanDoldur(object nesne = null)
        {
            var alanList = _AlanRepository.GetAll().ToList();
            var selectList = new SelectList(alanList, "AlanId", "AlanAdi", nesne);

            ViewData.Add("AlanId", selectList);
        }
        #endregion
    }
}