﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DersaneOtomasyon.Data.Model
{
   public  class Veli
    {
        [Key]
        public int VeliId { get; set; }
        [Required]
        public string VeliAdi { get; set; }
        [Required]
        public string VeliAdres { get; set; }
        [Required]
        public string VeliTc { get; set; }


        [Required]
        public int OgrenciId { get; set; }

        public virtual Ogrenci Ogrenci { get; set; }
    }
}
