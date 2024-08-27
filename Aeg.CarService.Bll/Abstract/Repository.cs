using Aeg.CarService.Dal;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Aeg.CarService.Bll.Abstract
{
    public class Repository<T> : IRepositoryBll<T> where T : class
    {
        private readonly DataContext _dbContext = new DataContext();//veritabanı bağlantısı
        private DbSet<T> _objectSet;//veritabanı tablosunu temsil eden nesne işlemleri yapmak için
        public Repository()
        {
            _objectSet = _dbContext.Set<T>();
        }
        public void Delete(T entity)
        {
            _objectSet.Remove(entity);
            Save();
        }
        /*
        Expression<Func<T, bool>> filter = null
        Ne İşe Yarar?: Veritabanı sorgusunda belirli bir koşulu sağlayan kayıtları almak için kullanılır.
        Örnek Kullanım: x => x.Age > 18 (Bu, 18 yaşından büyük olan tüm kayıtları getirir.)
        Varsayılan Değer: null (Eğer bir filtre verilmezse, tüm kayıtlar sorgulanır.)
        2. OrderBy (Sıralama)

        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null
        Ne İşe Yarar?: Sorgu sonuçlarını belirli bir sıraya göre sıralamak için kullanılır.
        Örnek Kullanım: q => q.OrderBy(x => x.Name) (Bu, sonuçları Name alanına göre alfabetik sıraya göre sıralar.)
        Varsayılan Değer: null (Eğer sıralama verilmezse, sonuçlar sıralanmadan döndürülür.)

        string includeProperties = ""
        Ne İşe Yarar?: İlişkili verileri (örneğin, başka tablolarla ilişkili veriler) sorguya dahil etmek için kullanılır.
        Örnek Kullanım: "Customer,Order" (Bu, Customer ve Order tablolarıyla ilişkili verileri de sorguya dahil eder.)
        Varsayılan Değer: Boş string "" (Eğer belirtilmezse, ilişkili veriler sorguya dahil edilmez.)
         */
        public IEnumerable<T> Get(/*1*/Expression<Func<T, bool>> filter = null,/*2*/ Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, /*3*/string includeProperties = "")
        {
            IQueryable<T> query = _objectSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            //includeProperties = "musteri,araç";
            if (includeProperties != null)
            {
                foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public T GetById(int id)
        {
            return _objectSet.Find(id);
        }

        public void Insert(T entity)
        {
            _objectSet.Add(entity);
            Save();
        }

        public List<T> List()
        {
            return _objectSet.ToList();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _objectSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            Save();
        }
    }
}
