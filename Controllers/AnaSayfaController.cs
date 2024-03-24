using Microsoft.AspNetCore.Mvc;
using Hafta10.Web.Data;
using Hafta10.Web.Models.ViewModels;


namespace Hafta10.Web.Controllers
{
    public class AnaSayfaController : Controller
    {
        DataContext context = new DataContext();
        public AnaSayfaController(DataContext _context)
        {
            context = _context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Slider()
        {
            return View();
        }
        public IActionResult Pankart()
        {
            return View();
        }
        [Route("~/Anasayfa/SkorTablosu")]
        public IActionResult SkorTablosu()
        {

            List<SkorModel> skorlistesi = context.skorlar.ToList(); // Veri yükle

            return View(skorlistesi);
        }
        public IActionResult Fikstur()
        {
            return View();
        }
        [Route("~/Anasayfa/SSS")]
        public IActionResult SSS() 
        {
            return View();
        }
        [Route("~/Anasayfa/Hakkimizda")]
        public IActionResult Hakkimizda()
        {
            return View();
        }
        [Route("~/Anasayfa/Iletisim")]
        public IActionResult Iletisim()
        {
            return View();
        }
    }
}
