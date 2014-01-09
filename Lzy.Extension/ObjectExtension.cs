using System;

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
    }
}
