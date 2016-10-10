using DersaneOtomasyon.Core.Infrastructure;
using DersaneOtomasyon.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var bolum = _alanRepository.GetAll().ToList();
            return View(bolum);
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
    }
}