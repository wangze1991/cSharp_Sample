using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace Utils.Helper
{


        
        //public static Attribute GetCustomAttribute(Assembly element, Type attributeType);
        //public static Attribute GetCustomAttribute(MemberInfo element, Type attributeType);     
        //public static Attribute GetCustomAttribute(Module element, Type attributeType);    
        //public static Attribute GetCustomAttribute(ParameterInfo element, Type attributeType);      
        //public static Attribute GetCustomAttribute(Assembly element, Type attributeType, bool inherit);   
        //public static Attribute GetCustomAttribute(MemberInfo element, Type attributeType, bool inherit);    
        //public static Attribute GetCustomAttribute(Module element, Type attributeType, bool inherit);       
        //public static Attribute GetCustomAttribute(ParameterInfo element, Type attributeType, bool inherit);



    /// <summary>
    /// attribute帮助类
    /// </summary>
    public static class AttributeHelper
    {
        /// <summary>
        /// 获取自定义Attribute
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="element"></param>
        /// <returns></returns>
        public static T GetAttribute<T>(Assembly element) where T : Attribute
        {
            //bool hasAttribute = Attribute.IsDefined(element, typeof(T));
            Attribute attribute = Attribute.GetCustomAttribute(element, typeof(T));
            if (attribute != null && attribute is T)
            {
                return attribute as T;
            }
            return null;
        }

    }
}
