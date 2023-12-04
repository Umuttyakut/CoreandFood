using CoreandFood.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CoreandFood.Repositories
{
    public class GenericRepository<T> where T:class,new()
    {
        Context c = new Context();
        public List<T> TList()
        {
            return c.Set<T>().ToList();
        }
        public void TAdd(T p)
        {
            c.Set<T>().Add(p);
            c.SaveChanges();
        }
        public void TDelete(T p)
        {
            c.Set<T>().Remove(p);
            c.SaveChanges();
        }
        public void TUpdate(T p)
        {
            c.Set<T>().Update(p);
            c.SaveChanges();
        }
        public T TGet(int id)
        {
           return c.Set<T>().Find(id);
        }
        public List<T> Tlist(string p)
        {
            return c.Set<T>().Include(p).ToList();//buna bakılcak
        }
        public List<T>List(Expression<Func<T,bool>> filter)//İstediğim bir sütuna
                                                           //göre arama işlemi yapmak için kullanılır
        {
            return c.Set<T>().Where(filter).ToList();
        }
    }
}
