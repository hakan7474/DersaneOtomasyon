using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DersaneOtomasyon.Data.Model
{
   public class OgrenciResim
    {
        [Key]
        public int OgrResimId { get; set; }
        [Required]
        public string ResimAdi { get; set; }
        [Required]
        public string IcerikTipi { get; set; }
        [Required]
        public byte[] Icerik { get; set; }




        [Required]
        public int OgrenciId { get; set; }

        public virtual Ogrenci Ogrenci { get; set; }
    }
}
