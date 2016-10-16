using DersaneOtomasyon.Admin.Model;
using DersaneOtomasyon.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DersaneOtomasyon.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOdemeRepository _odemeRepository;
       
        private readonly IOgrenciRepository _ogrenciRepository;
        private readonly IVeliRepository _veliRepository;
        public HomeController(IOdemeRepository odemeRepository, IVeliRepository VeliRepository , IOgrenciRepository OgrenciRepository)
        {
            _odemeRepository = odemeRepository;
          
            _ogrenciRepository = OgrenciRepository;
            _veliRepository = VeliRepository;
        }


        public ActionResult Index()
        {
            MainView context = new MainView {
                ToplamBolum = _odemeRepository.Count(),
                ToplamOgrenci = _ogrenciRepository.Count(),

                ToplamOdeme =_veliRepository.Count()
            };
            return View(context);
        }

    
    }
}