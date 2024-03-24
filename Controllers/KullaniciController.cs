
using Hafta10.Web.Data;
using Hafta10.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace Hafta10.Web.Controllers
{

    public class KullaniciController : Controller
    {
        DataContext context = new DataContext();
        public KullaniciController(DataContext _context)
        {
            context = _context;
        }
        [HttpGet]
        [Route("~/kullanici/kayit")]
        public IActionResult Kayit()
        {
            KayitModel kisi = new KayitModel();
            return View(kisi);
        }
        [HttpPost]
        public IActionResult Kayit(KayitModel kisi)
        {
            if (!ModelState.IsValid)
            {
                return View(kisi);
            }

            // Aynı e mailden varmı kontrol et
            var userExists = context.kullanicilar.Any(u => u.KullaniciEmail == kisi.KullaniciEmail);

            if (userExists)
            {
                ModelState.AddModelError("", "Bu E-posta kullanılmaktadır adı zaten kullanılıyor");
                return View(kisi);
            }

            context.kullanicilar.Add(kisi);
            context.SaveChanges();

            return View(kisi);
        }
        [HttpGet]
        [Route("~/kullanici/giris")]
        public IActionResult Giris()
        {
            KayitModel kisi = new KayitModel();
            return View();
        }
        [HttpPost]
        public IActionResult Giris(KayitModel kisi)
        {
            var user = context.kullanicilar.Where(u => u.KullaniciEmail == kisi.KullaniciEmail && u.KullaniciSifre == kisi.KullaniciSifre).FirstOrDefault();

            if (user == null)
            {
                return View("Kayit");
            }
            else
            {
                return RedirectToAction("Index", "AnaSayfa");
            }
        }
        [Route("~/kullanici/kayit-SSS")]
        public IActionResult SSS()
        {
            return View();
        }
    }


    
}


