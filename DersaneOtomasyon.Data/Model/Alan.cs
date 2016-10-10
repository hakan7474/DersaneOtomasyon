using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DersaneOtomasyon.Data.Model
{
   public class Alan
    {
        [Key]
        public int AlanId { get; set; }
        [Required]
        public string SinifAdi { get; set; }
        [Required]
        public int SinifMevcut { get; set; }
       
        public virtual ICollection<Ogrenci> Ogrencis { get; set; }
    }
}
