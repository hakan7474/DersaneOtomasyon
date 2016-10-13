using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DersaneOtomasyon.Data.Model
{
   public class Ogrenci
    {
        [Key]
        public int OgrenciId { get; set; }
        [Required]
        public string OgrenciAdi { get; set; }
        [Required]
        public string OgrenciSoyadi { get; set; }
        [Required]
        public string Okul { get; set; }


        public virtual ICollection<Odeme> Odeme { get; set; }

        public virtual ICollection<Veli> Veli { get; set; }

        [Required]
        public int AlanId { get; set; }
        
        public virtual Alan Alan { get; set; }
    }
}
