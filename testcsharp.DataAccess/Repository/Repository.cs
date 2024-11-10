using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using testcsharp.DataAccess.Data;
using testcsharp.DataAccess.Repository.IRepository;

namespace testcsharp.DataAccess.Repository
{
    // Lớp generic
    public class Repository <T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        //DbSet<T> trong Entity Framework là một tập hợp các đối tượng kiểu T tương ứng với một bảng trong cơ sở dữ liệu
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }
        public void Add(T item)
        {
            dbSet.Add(item);
        }

        public void Delete(T item)
        {
            dbSet.Remove(item);
        }

        public void DeleteRange(IEnumerable<T> items)
        {
            dbSet.RemoveRange(items);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            
            return query.ToList();
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
