using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DersaneOtomasyon.Core.Infrastructure
{
   public interface IRepository<T> where T:class
    {
        IEnumerable<T> GetAll();

        T GetById(int id);
        
        T Get(Expression<Func<T, bool>> epression);

        IQueryable<T> GetMany(Expression<Func<T,bool>> expression);

        void Save();

        void Update(T obj);

        void Insert(T obj);

        int Count();

        void Delete(int id);

    }
}
