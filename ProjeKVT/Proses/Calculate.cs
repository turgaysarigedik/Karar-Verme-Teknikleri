using ProjeKVT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjeKVT.Proses;
namespace ProjeKVT.Proses
{
    public class Calculate
    {
        int[] Buyukler;
        int[] Kucukler;
        int[,] YeniMatris;
        TableRank _tableRank = new TableRank();
        int a;//Alternatif sayısı
        int d;//Durum sayısı
        public int MatrisSatirHesapla(String[,] hesaplanacakMatris)
        {
            int len = hesaplanacakMatris.Length;

            int columns = MatrisKolonHesapla(hesaplanacakMatris);
           
            int rows = len / columns;

            return rows;
            
        }
        public int MatrisKolonHesapla(String[,] hesaplanacakMatris)
        {
            int len = hesaplanacakMatris.Length;
            
            int columns = 0;
            for (int i = 0; i <= hesaplanacakMatris.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= hesaplanacakMatris.GetUpperBound(1); j++)
                {
                    if (columns<=hesaplanacakMatris.GetUpperBound(1))
                    {
                        columns++;
                    }
                }
                break;
            }
            return columns;
        }

      //string değeri matrise çevir
        public string[,] AyirilmisMatris(string matris,int rows)
        {
            
            var items = matris.ToString().Split('|');
            
            var len = (items.Length)-1;
            var columns = ((len - 1) / rows) + 1;

            string[,] result = new string[rows, columns];
            int c = -1;
            int r = -1;
          
            for (int i = 0; i < len; i++)
            {
                string item = items[i];
                r = (r + 1) % columns;
                if (r == 0)
                {
                    c++;
                }
              
                result[c, r] = item;
            }
            return result;//string tipinde matris döndür
        }
        //string türünde matrisi int tipine çevir
        public int[,] ConvertMatris(String[,] model)
        {
            a = MatrisSatirHesapla(model);
            d = MatrisKolonHesapla(model);
            YeniMatris = new int[a, d];
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < d; j++)
                {
                    YeniMatris[i, j] = Convert.ToInt32(model[i, j]);

                }
            }
            return YeniMatris;
        }

        public int[] EnBuyukHesapla(String[,] model)
        {
            a = MatrisSatirHesapla(model);
            d = MatrisKolonHesapla(model);
            Buyukler = new int[a];
            YeniMatris = new int[a, d];
            YeniMatris = ConvertMatris(model);
            for (int i = 0; i < a; i++)
            {
                //satır
                for (int j = 0; j < d; j++)
                {
                    if (Buyukler[i] < YeniMatris[i, j])
                    {
                        Buyukler[i] = YeniMatris[i, j];

                    }

                }

            }

            return Buyukler;
        }

        public int[] EnKucukHesapla(String[,] model)
        {
            a = MatrisSatirHesapla(model);
            d = MatrisKolonHesapla(model);
            Kucukler = new int[a];
            YeniMatris = new int[a, d];
            YeniMatris = ConvertMatris(model);
            for (int i = 0; i < a; i++)
            {
                Kucukler[i] = YeniMatris[i, 0];
                //satır
                for (int j = 0; j <d; j++)
                {
                    if (Kucukler[i] > YeniMatris[i, j])
                    {
                        Kucukler[i] = YeniMatris[i, j];
                    }
                }

            }
            return Kucukler;
        }

      
        public SonucDetay IyimserlikHesapla(String[,] model)
        {
            a = MatrisSatirHesapla(model);
          
            Buyukler = new int[a];
            int iyiBuyuk = 0;
           
            Buyukler = EnBuyukHesapla(model);
            for (int i = 0; i < Buyukler.Length; i++)
            {
                if (iyiBuyuk < Buyukler[i])
                {
                    iyiBuyuk = Buyukler[i];
                }
            }
           int sonucSatiri= Array.IndexOf(Buyukler, iyiBuyuk);
            SonucDetay sonucDetay = new SonucDetay()
            {
                Sonuc = iyiBuyuk,
                SonucSatir = sonucSatiri

            };
            return sonucDetay;
        }

        public SonucDetay KotumserlikHesapla(String[,] model)
        {
            a = MatrisSatirHesapla(model);
          
            Kucukler = new int[a];
            int KotuBuyuk = 0;

            Kucukler = EnKucukHesapla(model);

            for (int i = 0; i < Kucukler.Length; i++)
            {
                if (KotuBuyuk < Kucukler[i])
                {
                    KotuBuyuk = Kucukler[i];
                }
            }
            int sonucSatiri = Array.IndexOf(Kucukler, KotuBuyuk);
            SonucDetay sonucDetay = new SonucDetay()
            {
                Sonuc = KotuBuyuk,
                SonucSatir = sonucSatiri

            };
            return sonucDetay;
        }

        public SonucDetay HurwicsHesapla(String[,] model,float _alfa)
        {
            a = MatrisSatirHesapla(model);
          
            Buyukler = new int[a];
            float alfa =_alfa;
            float alfa2 = 1 - alfa;//1-alfa
            //satırın en büyüğü

            Buyukler = EnBuyukHesapla(model);
            Kucukler = EnKucukHesapla(model);
            float[] HurwicsTop = new float[a];
            float hurwics = 0;
            for (int i = 0; i < Buyukler.Length; i++)
            {
                HurwicsTop[i] = (Buyukler[i] * alfa) + (Kucukler[i] * alfa2);
                if (hurwics < HurwicsTop[i])
                {
                    hurwics = HurwicsTop[i];
                }
            }
            int sonucSatiri = Array.IndexOf(HurwicsTop, hurwics);
            SonucDetay sonucDetay = new SonucDetay()
            {
                Sonuc = hurwics,
                SonucSatir = sonucSatiri

            };
            return sonucDetay;
        }

        public SonucDetay LaplaceHesapla(String[,] model)
        {
            a = MatrisSatirHesapla(model);
            d = MatrisKolonHesapla(model);
            
            float EsOlasilik =1/Convert.ToSingle(d) ;
            YeniMatris = ConvertMatris(model);
            float[] SatirTop = new float[a];
            float buyuk = 0;
            for (int i = 0; i < a; i++)
            {
                float Top = 0;

                for (int j = 0; j < d; j++)
                {
                    Top += YeniMatris[i, j];
                }
                SatirTop[i] = Top;
                SatirTop[i] = SatirTop[i] * EsOlasilik;
                if (buyuk < SatirTop[i])
                {
                    buyuk = SatirTop[i];
                }
            }
            int sonucSatiri = Array.IndexOf(SatirTop, buyuk);
            SonucDetay sonucDetay = new SonucDetay()
            {
                Sonuc = buyuk,
                SonucSatir = sonucSatiri

            };
            return sonucDetay;


        }

        public SonucDetay PismanlikHesapla(String[,] model)
        {
            a = MatrisSatirHesapla(model);
            d = MatrisKolonHesapla(model);
            Buyukler = new int[d];
           
            YeniMatris = ConvertMatris(model);

            for (int i = 0; i < d; i++)
            {
                int sayi = 0;
                for (int j = 0; j < a; j++)
                {
                    if (sayi < YeniMatris[j, i])
                    {
                        sayi = YeniMatris[j, i];
                    }
                    Buyukler[i] = sayi;
                }
            }
            int[,] PismalikMatris = new int[a, d];
            for (int i = 0; i <d; i++)
            {
                for (int j = 0; j <a; j++)
                {
                    PismalikMatris[j,i] = Buyukler[i] - YeniMatris[j, i];
                }
            }

            //Sütundaki büyük olanlar
            int[] Buyuk = new int[a];
           
            for (int i = 0; i < a; i++)
            {
                //satır
                for (int j = 0; j < d; j++)
                {
                    if (Buyuk[i] < PismalikMatris[i, j])
                    {
                        Buyuk[i] = PismalikMatris[i ,j];
                    }
                }
            }
            int kucuk=Buyuk[0];
            for (int i = 0; i < Buyuk.Length; i++)
            {
                
                if (kucuk > Buyuk[i])
                {
                    kucuk = Buyuk[i];
                }
            }
            int sonucSatiri = Array.IndexOf(Buyuk, kucuk);
            
            SonucDetay sonucDetay = new SonucDetay()
            {
                Sonuc = kucuk,
                SonucSatir = sonucSatiri

            };
          
            return sonucDetay;
        }
    }
}