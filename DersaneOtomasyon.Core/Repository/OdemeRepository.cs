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
    public class OdemeRepository : IOdemeRepository
    {
        private readonly Context _context = new Context();

        public int Count()
        {
            return _context.Odeme.Count();
        }

        public void Delete(int id)
        {
            var find = GetById(id);

            if (find != null)
            {
                _context.Odeme.Remove(find);
            }

        }

        public Odeme Get(Expression<Func<Odeme, bool>> epression)
        {
            return _context.Odeme.FirstOrDefault(epression);
        }

        public IEnumerable<Odeme> GetAll()
        {
            return _context.Odeme.Select(x => x);
        }

        public Odeme GetById(int id)
        {
            return _context.Odeme.FirstOrDefault(x => x.OdemeId == id);
        }

        public IQueryable<Odeme> GetMany(Expression<Func<Odeme, bool>> expression)
        {
            return _context.Odeme.Where(expression);
        }

        public void Insert(Odeme obj)
        {
            _context.Odeme.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Odeme obj)
        {
            _context.Odeme.AddOrUpdate(obj);
        }
    }
}
