using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Lzy.Extension
{
    /// <summary>
    /// Object类型的扩张方法
    /// </summary>
    public static class ObjectExtension
    {
        /// <summary>
        /// 转换成类型T
        /// </summary>
        /// <typeparam name="T">要转换成的类型</typeparam>
        /// <param name="obj">要转换的对象</param>
        /// <returns>转换后的结果</returns>
        public static T Cast<T>(this object obj)
        {
            return (T)Convert.ChangeType(obj, typeof(T));
        }

        /// <summary>
        /// 转换成类型T
        /// </summary>
        /// <typeparam name="T">要转换成的类型</typeparam>
        /// <param name="obj">要转换的对象</param>
        /// <returns>转换后的结果</returns>
        public static T As<T>(this object obj)
        {
            return (T)(object)obj;
        }
        
        /// <summary>
        /// 根据属性名称获取属性的值
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="t">初始化以后的实例</param>
        /// <param name="propertyName">属性的名称</param>
        /// <returns>属性的值</returns>
        public static object GetPropertyValue<T>(this T t, string propertyName)
        {
            object obj;
            try
            {
                obj = typeof(T).GetProperty(propertyName).GetValue(t, null);
            }
            catch (AmbiguousMatchException)
            {
                throw new AmbiguousMatchException("属性名称错误");
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("属性名称错误");                
            }
            catch (Exception)
            {
                throw new Exception("属性名称错误");
            }
            return obj;
        }

        /// <summary>
        /// 获取所有属性的名称
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="t">实例</param>
        /// <returns>属性名称</returns>
        public static IEnumerable<string> GetPropertyNames<T>(this T t)
        {
            return typeof(T).GetProperties().ToList().Select(p => p.Name);
        }
    }
}
