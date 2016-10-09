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
   public class OgrenciResimRepository:IOgrenciResimRepository
    {
        private readonly Context _context = new Context();

        public int Count()
        {
            return _context.OgrenciResim.Count();
        }

        public void Delete(int id)
        {
            var find = GetById(id);

            if (find != null)
            {
                _context.OgrenciResim.Remove(find);
            }

        }

        public OgrenciResim Get(Expression<Func<OgrenciResim, bool>> epression)
        {
            return _context.OgrenciResim.FirstOrDefault(epression);
        }

        public IEnumerable<OgrenciResim> GetAll()
        {
            return _context.OgrenciResim.Select(x => x);
        }

        public OgrenciResim GetById(int id)
        {
            return _context.OgrenciResim.FirstOrDefault(x => x.OgrResimId == id);
        }

        public IQueryable<OgrenciResim> GetMany(Expression<Func<OgrenciResim, bool>> expression)
        {
            return _context.OgrenciResim.Where(expression);
        }

        public void Insert(OgrenciResim obj)
        {
            _context.OgrenciResim.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(OgrenciResim obj)
        {
            _context.OgrenciResim.AddOrUpdate(obj);
        }
    }
}
