using ProjeKVT.Models;
using ProjeKVT.Proses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjeKVT.Controllers
{
    public class TableController : Controller
    {
        // GET: Table
        [HttpGet]
        public ActionResult TableValue()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TableValue(TableRank tableRank)
        {
            return View(tableRank);
        }
        [HttpPost]
        public ActionResult Table(FormCollection Nesneler)
        {
            int a =Convert.ToInt32( Nesneler["Alternatif"]);
            int d = Convert.ToInt32(Nesneler["Durum"]);

            string[,] matris = new string[a, d];
            for (int i = 0; i <= matris.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= matris.GetUpperBound(1); j++)
                {
                    matris[i, j] = Nesneler["Durum" + i + "" + j];

                }
            }

            Calculate calculate = new Calculate();
            

            int columns = calculate.MatrisKolonHesapla(matris);

            int rows = calculate.MatrisSatirHesapla(matris);
            
            string matrisBirlesim ="";
            for (int i = 0; i <= matris.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= matris.GetUpperBound(1); j++)
                {
                    matrisBirlesim += matris[i, j]+"|";
                }
            }

            IntermediateMatris intermediate = new IntermediateMatris()
            {
                Birlestirilmismatris = matrisBirlesim,
                RowLength = rows
               
            };
           

            return RedirectToAction("Kriterler", "Kriter",intermediate);
        }

    }
}