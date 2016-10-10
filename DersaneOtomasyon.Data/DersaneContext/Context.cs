using DersaneOtomasyon.Data.DersaneContext;
using DersaneOtomasyon.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DersaneOtomasyon.Data.DersaneContext
{
    public class Context : DbContext
    {

        public DbSet<Alan> Alan { get; set; }
 

        public DbSet<Odeme> Odeme { get; set; }

        public DbSet<Ogrenci> Ogrenci { get; set; }

        public DbSet<OgrenciResim> OgrenciResim { get; set; }

        public DbSet<Okul> Okul { get; set; }

        public DbSet<Veli> Veli { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        

    }
}
