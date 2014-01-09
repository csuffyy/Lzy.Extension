using System;
using System.Collections.Generic;

namespace Lzy.Extension.Validate
{
    /// <summary>
    /// 验证方法的扩展
    /// </summary>
    public static class ValidateExtension
    {
        /// <summary>
        /// 对目标按照指定方法进行验证
        /// </summary>
        /// <typeparam name="T">要验证的目标</typeparam>
        /// <param name="target">要验证的目标</param>
        /// <param name="predicate">验证条件</param>
        /// <param name="errorMessage">验证不通过的错误信息</param>
        /// <returns>验证结果</returns>
        public static ValidateResult<T> Validate<T>(this T target, Predicate<T> predicate, string errorMessage)
        {
            var result = new ValidateResult<T>(target);
            if (!predicate(target))
            {
                result.Errors.Add(errorMessage);
            }
            return result;
        }

        /// <summary>
        /// Validates the specified target.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">The target.</param>
        /// <param name="predicate">The predicate.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <returns>ValidateResult{``0}.</returns>
        internal static ValidateResult<T> Validate<T>(this ValidateResult<T> target, Predicate<T> predicate, string errorMessage)
        {
            if (!predicate(target.Entity))
            {
                target.Errors.Add(errorMessage);
            }
            return target;
        }
    }

    /// <summary>
    /// 验证的结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ValidateResult<T>
    {
        internal List<string> Errors { get; set; }
        internal T Entity { get; private set; }

        internal ValidateResult(T entity)
        {
            Errors = new List<string>();
            Entity = entity;
        }

        /// <summary>
        /// 验证未通过的错误信息
        /// </summary>
        public string[] ErrorMessages
        {
            get { return Errors.ToArray(); }
        }
    }
}
