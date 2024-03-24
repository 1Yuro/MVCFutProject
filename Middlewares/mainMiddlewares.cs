
namespace Hafta10.Web.Middlewares
{
    public class mainMiddlewares
    {
       
            private readonly RequestDelegate _rdIstek;
            public mainMiddlewares(RequestDelegate rdIstek)
            {
                _rdIstek = rdIstek;
            }
            public async Task Invoke(HttpContext httpContext)
            {
                string Ip = httpContext.Connection.RemoteIpAddress.ToString();
                string TarayiciBilgileri = httpContext.Request.Headers["User-Agent"];
                string RequestScheme = httpContext.Request.Scheme;
                string RequestHost = httpContext.Request.Host.ToString();
                string RequestPath = httpContext.Request.Path;
                string RequestQueryString = httpContext.Request.QueryString.ToString();
                string Path = "C:\\Users\\emndm\\source\\repos\\Hafta10\\Hafta10.Web\\Middlewares\\Log.txt";
                using (StreamWriter swYazici = System.IO.File.AppendText(Path))
                {
                    swYazici.WriteLine("#### Request (BASLANGIC) ####");
                    swYazici.WriteLine("Ip Adresi: " + Ip);
                    swYazici.WriteLine("Tarayıcı Bilgileri: " + TarayiciBilgileri);
                    swYazici.WriteLine("Request.Scheme: " + RequestScheme);
                    swYazici.WriteLine("Request.Host: " + RequestHost);
                    swYazici.WriteLine("Request.Path: " + RequestPath);
                    swYazici.WriteLine("Request.QueryString: " + RequestQueryString);
                    swYazici.WriteLine("Tarih: " + DateTime.Now);
                    swYazici.WriteLine("#### Request (BITIS) ####");
                    swYazici.WriteLine("\n");
                }
                await _rdIstek.Invoke(httpContext);
            }
    }

}


    //public async Task Invoke(HttpContext httpContext)
    //{
    //    Console.WriteLine("main middleware çalıştı");
    //    await _next.Invoke(httpContext);
    //    Console.WriteLine("main middleware durdu.");
    //}


