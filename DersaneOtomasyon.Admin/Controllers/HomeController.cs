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
        private readonly IAlanRepository _alanRepository;
       
        private readonly IOgrenciRepository _ogrenciRepository;
        private readonly IVeliRepository _veliRepository;
        public HomeController(IAlanRepository AlanRepository, IVeliRepository VeliRepository , IOgrenciRepository OgrenciRepository)
        {
            _alanRepository = AlanRepository;
          
            _ogrenciRepository = OgrenciRepository;
            _veliRepository = VeliRepository;
        }


        public ActionResult Index()
        {
            MainView context = new MainView {
                ToplamBolum = _alanRepository.Count(),
                ToplamOgrenci = _ogrenciRepository.Count(),
                
                ToplamVeli=_veliRepository.Count()
            };
            return View(context);
        }

    
    }
}