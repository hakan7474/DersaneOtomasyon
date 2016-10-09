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
        public string Soyadi { get; set; }
        [Required]
        public DateTime DogumTarihi { get; set; }
        [Required]
        public DateTime KayitTarihi { get; set; }

        public byte[] OgrenciFotograf { get; set; }
        
        public bool AktifMi { get; set; }
    }


}
