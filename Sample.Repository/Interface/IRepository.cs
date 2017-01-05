using Sample.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Repository
{
    /// <summary>
    /// 仓储基类接口
    /// </summary>
    public interface IRepository<T> where T:BaseEntity
    {
        /// <summary>
        /// Get Entity by Identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(object id);

        /// <summary>
        /// Insert Entity
        /// </summary>
        /// <param name="entity"></param>
        void Insert(T entity);

        /// <summary>
        /// Insert entities
        /// </summary>
        /// <param name="entities"></param>
        void Insert(IEnumerable<T> entities);

        /// <summary>
        /// Update Entity
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

       /// <summary>
       /// 新增或者添加
       /// </summary>
       /// <param name="entity"></param>
        void UpdateOrSave(T entity);

        /// <summary>
        ///Delete Entity
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);

        /// <summary>
        /// Delete Entities
        /// </summary>
        /// <param name="entities"></param>
        void Delete(IEnumerable<T> entities);


        /// <summary>
        ///获取一张表
        /// </summary>
        IQueryable<T> Table{get;}

         /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        IQueryable<T> TableNoTracking { get; }
    }
}
