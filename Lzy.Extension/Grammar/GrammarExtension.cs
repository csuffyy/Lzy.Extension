using System;
using System.Collections.Generic;
using System.Linq;

namespace Lzy.Extension.Grammar
{
    /// <summary>
    /// 基本语法的扩展：In、If、Where...
    /// </summary>
    public static class GrammarExtension
    {
        /// <summary>
        /// In扩展:是否在某个集合内
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool In<T>(this T t, params T[] c)
        {
            return c.Any(i => i.Equals(t));
        }

        /// <summary>
        /// In扩展:是否在某个集合内
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool In<T>(this T t, IEnumerable<T> c)
        {
            return c.Any(i => i.Equals(t));
        }

        /// <summary>
        /// If扩展:若符合特定条件则执行操作
        /// </summary>
        /// <typeparam name="T">类</typeparam>
        /// <param name="t">类T的实例</param>
        /// <param name="predicate">条件</param>
        /// <param name="action">操作</param>
        /// <returns>若满足条件，返回执行后的结果，反之返回本身</returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static T If<T>(this T t, Predicate<T> predicate, Action<T> action) where T : class, new()
        {
            if (t == null)
            {
                throw new ArgumentNullException();
            }
            if (predicate(t))
            {
                action(t);
            }
            return t;
        }

        /// <summary>
        /// If扩展:若符合特定条件则执行操作
        /// </summary>
        /// <typeparam name="T">值类型</typeparam>
        /// <param name="t">值</param>
        /// <param name="predicate">条件</param>
        /// <param name="func">操作</param>
        /// <returns>若满足条件，返回执行后的结果，反之返回本身</returns>
        public static T If<T>(this T t, Predicate<T> predicate, Func<T, T> func) where T : struct
        {
            return predicate(t) ? func(t) : t;
        }

        /// <summary>
        /// While扩展：若符合特定条件则执行一系列的操作
        /// </summary>
        /// <typeparam name="T">类</typeparam>
        /// <param name="t">类的实例</param>
        /// <param name="predicate">条件</param>
        /// <param name="actions">操作</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static void While<T>(this T t, Predicate<T> predicate, params Action<T>[] actions) where T : class, new()
        {
            if (t == null)
            {
                throw new ArgumentNullException();
            }

            while (predicate(t))
            {
                foreach (var action in actions)
                {
                    action(t);
                }
            }
        }
    }
}
