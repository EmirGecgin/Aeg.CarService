using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Aeg.CarService.Bll.Abstract
{
    public interface IRepositoryBll<T>
    {
        List<T> List();
        T GetById(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
        IEnumerable<T> Get(Expression<Func<T, bool>> filter=null, 
            Func<IQueryable<T>, 
                IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");
    }
}
