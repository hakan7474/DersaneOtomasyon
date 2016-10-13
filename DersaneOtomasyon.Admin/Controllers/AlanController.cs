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
    public class AlanController : Controller
    {
        private readonly IAlanRepository _alanRepository;

        public AlanController(IAlanRepository alanRepository)
        {
            _alanRepository = alanRepository;
        }


        public ActionResult Index()
        {
            var alanList = _alanRepository.GetAll().ToList();
            return View(alanList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Create(Alan alan)
        {
            _alanRepository.Insert(alan);
            _alanRepository.Save();
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int? id,Alan alan)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var find = _alanRepository.GetById(id.Value);

            if (find==null)
            {
               return HttpNotFound();
            }

            return View(find);
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Edit( Alan alan)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            _alanRepository.Update(alan);
            _alanRepository.Save();

            return RedirectToAction("Index");
             
        }
    }
}