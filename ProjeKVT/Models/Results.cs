using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjeKVT.Models
{
    public class Results
    {

        [Required]
        public string Isim { get; set; }

        [Required]
        public int Rows { get; set; }

       

    }
}