using Sample.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Sample.Repository
{
    [EfError]
    public class EfRepository<T>:IRepository<T> where T:BaseEntity 
    {
        #region field

        private readonly IDbContext _context;
        private IDbSet<T> _entities;
        #endregion

        #region ctor
        /// <summary>
        /// 构造方法 接口注入
        /// </summary>
        /// <param name="context"></param>
        public EfRepository(IDbContext context){
            this._context = context;
        
        }
        #endregion

        #region methods
        public virtual T GetById(object id)
        {
            return this.Entities.Find(id);
        }
        public void Insert(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            this.Entities.Add(entity);
            this._context.SaveChanges();
        }

        public virtual void Insert(IEnumerable<T> entities)
        {
            if (entities == null || !entities.Any()) throw new ArgumentNullException("entities");
             foreach(var entity in entities){
                 this.Entities.Add(entity);
             }
            this._context.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            this._context.SaveChanges();
        }

        public virtual void UpdateOrSave(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            this.Entities.Remove(entity);
            this._context.SaveChanges();
        }

        public virtual void Delete(IEnumerable<T> entities)
        {
            if (entities == null || !entities.Any()) throw new ArgumentNullException("entities");
            foreach (var entity in entities)
            {
                this.Entities.Remove(entity);
            }
            this._context.SaveChanges();
        }
        /// <summary>
        /// get a Table
        /// </summary>
        public IQueryable<T> Table
        {
            get { return this.Entities; }
        }

        /// <summary>
        /// get a table with no tacking  Use it only where you load records only  for read-only operations
        /// </summary>
        public IQueryable<T> TableNoTracking
        {
            get {return this.Entities.AsNoTracking(); }
        }
        #endregion

        #region properties

        /// <summary>
        /// 获取DbSet
        /// </summary>
        public IDbSet<T> Entities {
            get {
                if (this._entities == null) return this._context.Set<T>();
                return this._entities;
            }
        }
        #endregion
    }
}
