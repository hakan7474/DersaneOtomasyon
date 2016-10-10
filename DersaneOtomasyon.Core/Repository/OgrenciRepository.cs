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
    public class OgrenciRepository:IOgrenciRepository
    {
        private readonly Context _context = new Context();

        public int Count()
        {
            return _context.Ogrenci.Count();
        }

        public void Delete(int id)
        {
            var find = GetById(id);

            if (find != null)
            {
                _context.Ogrenci.Remove(find);
            } 
        }

        public Ogrenci Get(Expression<Func<Ogrenci, bool>> epression)
        {
            return _context.Ogrenci.FirstOrDefault(epression);
        }

        public IEnumerable<Ogrenci> GetAll()
        {
            return _context.Ogrenci.Select(x => x);
        }

        public Ogrenci GetById(int id)
        {
            return _context.Ogrenci.FirstOrDefault(x => x.OgrenciId == id);
        }

        public IQueryable<Ogrenci> GetMany(Expression<Func<Ogrenci, bool>> expression)
        {
            return _context.Ogrenci.Where(expression);
        }

        public void Insert(Ogrenci obj)
        {
            _context.Ogrenci.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Ogrenci obj)
        {
            _context.Ogrenci.AddOrUpdate(obj);
        }
    }
}
