using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Repository{
    /// <summary>
    /// 显示实现EF实体对象的详细错误信息
    /// </summary>
    [AttributeUsage(AttributeTargets.Method|AttributeTargets.Class,AllowMultiple=true,Inherited=false)]
    public class EfErrorAttribute:Attribute
    {
        public EfErrorAttribute() { 
        
        }

        /// <summary>
        /// 显示EF错误信息
        /// </summary>
        /// <param name="ex"></param>
        public void OnException(DbEntityValidationException ex)
        {
            var msg = string.Empty;

            foreach (var validationErrors in ex.EntityValidationErrors)
                foreach (var validationError in validationErrors.ValidationErrors)
                    msg += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;

            var fail = new Exception(msg, ex);
            //Debug.WriteLine(fail.Message, fail);
            throw fail;
        }
    }
}
