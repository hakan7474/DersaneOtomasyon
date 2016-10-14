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
        private readonly IOdemeRepository _odemeRepository;

        private readonly IOgrenciRepository _ogrenciRepository;

        public VeliController(IOdemeRepository odemeRepository, IOgrenciRepository ogrenciRepository)
        {
            _odemeRepository = odemeRepository;
            _ogrenciRepository = ogrenciRepository;
        }

        public ActionResult Index(int? id)
        {
            if (id ==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var ogrenci = OgrenciGet(id.Value);

            var OgrenciOdeme = ogrenci.Odeme;

            ViewBag.SelectedOgrenci = ogrenci;

            return View(OgrenciOdeme);
        }


        private Ogrenci OgrenciGet(int? id)
        {
            var ogrenci = _ogrenciRepository.GetById(id.Value);
            return ogrenci;
        }
    }
}