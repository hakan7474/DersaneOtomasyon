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
        public string AlanAdi { get; set; }
        [Required]
        public string AlanAciklama { get; set; }
         

        public virtual ICollection<Ogrenci> Ogrenci { get; set; }
     }
}
