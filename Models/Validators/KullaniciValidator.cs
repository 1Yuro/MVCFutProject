using FluentValidation;
using Hafta10.Web.Models.ViewModels;

namespace Hafta10.Web.Models.Validators
{
    public class KullaniciValidator:AbstractValidator<KayitModel>
    {
        public KullaniciValidator() 
        {
            RuleFor(a => a.KullaniciAdi).NotNull().WithMessage("Kullanici Adi Zorunludur").
                NotEmpty().WithMessage("Kullanici Adi Bos Olamaz").
                MaximumLength(50).WithMessage("Kullanici Adi 50 karakterden fazla olamaz");
            RuleFor(a => a.KullaniciSoyadi).NotNull().WithMessage("Kullanici Soyadi Zorunludur").
                NotEmpty().WithMessage("Kullanici Soyadi Bos Olamaz").
                MaximumLength(50).WithMessage("Kullanici Soyadi 50 karakterden fazla olamaz");
            RuleFor(a => a.KullaniciEmail).NotNull().WithMessage("Kullanici Email Zorunludurz").
                NotEmpty().WithMessage("Kullanici Email Bos Olamaz").
                EmailAddress().WithMessage("E posta adresini doğru giriniz ornek:kullanici@gmail.com");
            RuleFor(a => a.KullaniciYas).NotNull().WithMessage("Kullanici Yasi Zorunludur").
                NotEmpty().WithMessage("Kullanici Yasi Bos Olamaz").
                LessThan(18).WithMessage("Yasiniz 18'den büyük olmalıdır");
            RuleFor(a => a.KullaniciSifre).NotNull().WithMessage("Kullanici Sifre Zorunludur").NotEmpty().WithMessage("Kullanici Sifre Bos Olamaz").
                MinimumLength(4).MaximumLength(8).WithMessage("Sifre 4 ve 8 karakter arasında olmalıdır");
        }
    }
}
