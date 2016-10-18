using DersaneOtomasyon.Core.Infrastructure;
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

        public VeliController(IVeliRepository veliRepository,IOgrenciRepository ogrenciRepository)
        {
            _veliRepository = veliRepository;
            _ogrenciRepository = ogrenciRepository;
        }

        public ActionResult Index(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ogrenci = _ogrenciRepository.GetById(id.Value);

            ViewBag.SelectedOgrenci = ogrenci;

            return View(ogrenci);
        }
    }
}