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
   public class ilRepository:IilRepository
    {
        private readonly Context _context = new Context();

        public int Count()
        {
            return _context.Il.Count();
        }

        public void Delete(int id)
        {
            var find = GetById(id);

            if (find != null)
            {
                _context.Il.Remove(find);
            }

        }

        public Il Get(Expression<Func<Il, bool>> epression)
        {
            return _context.Il.FirstOrDefault(epression);
        }

        public IEnumerable<Il> GetAll()
        {
            return _context.Il.Select(x => x);
        }

        public Il GetById(int id)
        {
            return _context.Il.FirstOrDefault(x => x.IlId == id);
        }

        public IQueryable<Il> GetMany(Expression<Func<Il, bool>> expression)
        {
            return _context.Il.Where(expression);
        }

        public void Insert(Il obj)
        {
            _context.Il.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Il obj)
        {
            _context.Il.AddOrUpdate(obj);
        }
    }
}
