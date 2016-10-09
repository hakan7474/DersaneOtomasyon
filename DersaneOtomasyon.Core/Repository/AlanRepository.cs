using DersaneOtomasyon.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DersaneOtomasyon.Data.Model;
using System.Linq.Expressions;
using DersaneOtomasyon.Data.DersaneContext;
using System.Data.Entity.Migrations;

namespace DersaneOtomasyon.Core.Repository
{
    public class AlanRepository : IAlanRepository
    {
        private readonly Context _context = new Context();

        public int Count()
        {
            return _context.Alan.Count();
        }

        public void Delete(int id)
        {
            var find = GetById(id);

            if (find != null)
            {
                _context.Alan.Remove(find);
            }

        }

        public Alan Get(Expression<Func<Alan, bool>> epression)
        {
            return _context.Alan.FirstOrDefault(epression);
        }

        public IEnumerable<Alan> GetAll()
        {
            return _context.Alan.Select(x => x);
        }

        public Alan GetById(int id)
        {
            return _context.Alan.FirstOrDefault(x => x.AlanId == id);
        }

        public IQueryable<Alan> GetMany(Expression<Func<Alan, bool>> expression)
        {
            return _context.Alan.Where(expression);
        }

        public void Insert(Alan obj)
        {
            _context.Alan.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Alan obj)
        {
            _context.Alan.AddOrUpdate(obj);
        }
    }
}
