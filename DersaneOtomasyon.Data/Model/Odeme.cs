using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DersaneOtomasyon.Data.Model
{
   public class Odeme
    {
        [Key]
        public int OdemeId { get; set; }
        [Required]
        public int ToplamUcret { get; set; }
 
        [Required]
        public int TaksitSayisi { get; set; }

        public bool OdemeAktif { get; set; }


        [Required]
        public int OgrenciId { get; set; }

        public virtual Ogrenci Ogrenci { get; set; }
    }
}
