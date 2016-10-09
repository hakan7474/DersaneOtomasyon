using DersaneOtomasyon.Core.Infrastructure;
using DersaneOtomasyon.Data.DersaneContext;
using DersaneOtomasyon.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DersaneOtomasyon.Core.Repository
{
   public class VeliRepositor :IVeliRepository
    {
        private readonly Context _context = new Context();

        public int Count()
        {
            return _context.Veli.Count();
        }

        public void Delete(int id)
        {
            var find = GetById(id);

            if (find != null)
            {
                _context.Veli.Remove(find);
            }

        }

        public Veli Get(Expression<Func<Veli, bool>> epression)
        {
            return _context.Veli.FirstOrDefault(epression);
        }

        public IEnumerable<Veli> GetAll()
        {
            return _context.Veli.Select(x => x);
        }

        public Veli GetById(int id)
        {
            return _context.Veli.FirstOrDefault(x => x.VeliId == id);
        }

        public IQueryable<Veli> GetMany(Expression<Func<Veli, bool>> expression)
        {
            return _context.Veli.Where(expression);
        }

        public void Insert(Veli obj)
        {
            _context.Veli.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Veli obj)
        {
            _context.Veli.AddOrUpdate(obj);
        }
    }
}
