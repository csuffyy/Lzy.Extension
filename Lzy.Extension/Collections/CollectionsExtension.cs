using System;
using System.Collections.Generic;

namespace Lzy.Extension.Collections
{
    /// <summary>
    /// 集合的扩展方法
    /// </summary>
    public static class CollectionsExtension
    {
        /// <summary>
        /// IEnumerable类型遍历扩展方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="action">The action.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }
            foreach (var item in source)
            {
                action(item);
            }
        }
    }
}
