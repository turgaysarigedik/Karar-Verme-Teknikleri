
using ProjeKVT.Models;
using ProjeKVT.Proses;
using ProjeKVT.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ProjeKVT.Controllers
{
    public class ResultValueController : Controller
    {
       
        // GET: ResultValue
        public ActionResult Sonuc()
        {
            return View();
        }
       
        public ActionResult Iyimserlik(String matris,int rows)
        {
          
            Calculate calculate = new Calculate();
            String[,] Matris= calculate.AyirilmisMatris(matris,rows);
            var results = new Results()
            {
                Isim = "İyimserlik",
                Rows = rows

            };
            var _sonucDetay = calculate.IyimserlikHesapla(Matris);
            _sonucDetay.SonucSatir += 1;
            var sonucDetay = new SonucDetay()
            {
                Sonuc = _sonucDetay.Sonuc,
                SonucSatir = _sonucDetay.SonucSatir
            };
            var sonucViewModel = new SonucViewModel()
            {
               Results=results,
               SonucDetay=sonucDetay
            };
            return View("Sonuc", sonucViewModel);

        }

        public ActionResult Kotumserlik(string matris,int rows)
        {

            Calculate calculate = new Calculate();
            String[,] Matris = calculate.AyirilmisMatris(matris,rows);
            Results results = new Results()
            {
                Isim = "Kötümserlik",
                Rows = rows

            };
            SonucDetay _sonucDetay = calculate.KotumserlikHesapla(Matris);
            _sonucDetay.SonucSatir += 1;
            SonucDetay sonucDetay = new SonucDetay()
            {
                Sonuc = _sonucDetay.Sonuc,
                SonucSatir = _sonucDetay.SonucSatir
            };
            SonucViewModel sonucViewModel = new SonucViewModel()
            {
                Results = results,
                SonucDetay = sonucDetay
            };
            return View("Sonuc", sonucViewModel);
        }
        
        public ActionResult Hurwics(FormCollection Nesneler)
        {
            string matris = Nesneler["matris"];
            int rows =Convert.ToInt32( Nesneler["rows"]);
            float alfa =Convert.ToSingle( Nesneler["textBoxAlfa"]);
            alfa /= 100;
            Calculate calculate = new Calculate();
            String[,] Matris = calculate.AyirilmisMatris(matris,rows);
            Results results = new Results()
            {
                Isim = "Hurwics",
                Rows = rows

            };
            SonucDetay _sonucDetay = calculate.HurwicsHesapla(Matris,alfa);
            _sonucDetay.SonucSatir += 1;
            SonucDetay sonucDetay = new SonucDetay()
            {
                Sonuc = _sonucDetay.Sonuc,
                SonucSatir = _sonucDetay.SonucSatir
            };
            SonucViewModel sonucViewModel = new SonucViewModel()
            {
                Results = results,
                SonucDetay = sonucDetay
            };
            return View("Sonuc", sonucViewModel);
        }

        public ActionResult Laplace(string matris,int rows)
        {
            Calculate calculate = new Calculate();
            String[,] Matris = calculate.AyirilmisMatris(matris,rows);
            Results results = new Results()
            {
                Isim = "Laplace",
                Rows = rows

            };
            SonucDetay _sonucDetay = calculate.LaplaceHesapla(Matris);
            _sonucDetay.SonucSatir += 1;
            SonucDetay sonucDetay = new SonucDetay()
            {
                Sonuc = _sonucDetay.Sonuc,
                SonucSatir = _sonucDetay.SonucSatir
            };
            SonucViewModel sonucViewModel = new SonucViewModel()
            {
                Results = results,
                SonucDetay = sonucDetay
            };
            return View("Sonuc", sonucViewModel);
        }
        public ActionResult Pismanlik(string matris,int rows)
        {
          
           
            Calculate calculate = new Calculate();
            String[,] Matris = calculate.AyirilmisMatris(matris,rows);
            Results results = new Results()
            {
                Isim="Pişmanlık",
                Rows=rows
                
            };
            SonucDetay _sonucDetay = calculate.PismanlikHesapla(Matris);
            _sonucDetay.SonucSatir += 1;
            SonucDetay sonucDetay = new SonucDetay()
            {
                Sonuc=_sonucDetay.Sonuc,
                SonucSatir=_sonucDetay.SonucSatir
            };
            SonucViewModel sonucViewModel = new SonucViewModel()
            {
                Results = results,
                SonucDetay = sonucDetay
            };




            return View("Sonuc", sonucViewModel);
        }

    }
}