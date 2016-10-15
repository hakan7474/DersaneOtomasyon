using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string OdemeAciklama { get; set; }
        [Required]
        public int TaksitNo { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]
        public double OdenenTutar { get; set; } 

         
         
        [Required]
        public int OgrenciId { get; set; }

        public virtual Ogrenci Ogrenci { get; set; }
    }
}
