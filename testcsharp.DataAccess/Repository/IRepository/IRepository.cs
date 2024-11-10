using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace testcsharp.DataAccess.Repository.IRepository
{
    public interface IRepository <T> where T : class
    {
        //T ở đây là Category
        IEnumerable<T> GetAll ();
        T Get(Expression<Func<T, bool>> filter);
        void Add(T item);
        void Update(T item);
        void Delete(T item);
        void DeleteRange(IEnumerable<T> items);

    }
}
