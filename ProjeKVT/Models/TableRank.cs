using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjeKVT.Models
{
    public class TableRank
    {
        [Required]
        [Display(Name ="Alternatif Sayısı: ")]
        public int AlternatifSayisi { get; set; }
        [Required]
        [Display(Name ="Durum Sayısı: ")]
        public int DurumSayisi { get; set; }
    }
}