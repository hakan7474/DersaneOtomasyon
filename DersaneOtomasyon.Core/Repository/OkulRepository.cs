using DersaneOtomasyon.Core.Infrastructure;
using DersaneOtomasyon.Data.DersaneContext;
using DersaneOtomasyon.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace DersaneOtomasyon.Core.Repository
{
    public  class OkulRepository:IOkulRepository
    {
        private readonly Context _context = new Context();

        public int Count()
        {
            return _context.Okul.Count();
        }

        public void Delete(int id)
        {
            var find = GetById(id);

            if (find != null)
            {
                _context.Okul.Remove(find);
            }

        }

        public Okul Get(Expression<Func<Okul, bool>> epression)
        {
            return _context.Okul.FirstOrDefault(epression);
        }

        public IEnumerable<Okul> GetAll()
        {
            return _context.Okul.Select(x => x);
        }

        public Okul GetById(int id)
        {
            return _context.Okul.FirstOrDefault(x => x.OkulId == id);
        }

        public IQueryable<Okul> GetMany(Expression<Func<Okul, bool>> expression)
        {
            return _context.Okul.Where(expression);
        }

        public void Insert(Okul obj)
        {
            _context.Okul.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Okul obj)
        {
            _context.Okul.AddOrUpdate(obj);
        }
    }
}
