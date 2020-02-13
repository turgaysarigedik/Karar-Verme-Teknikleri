using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjeKVT.Models
{
    public class SonucDetay
    {
        [Required]
        public float Sonuc { get; set; }
        [Required]
        public float SonucSatir { get; set; }
    }
}