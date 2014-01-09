using System;
using System.Windows.Forms;

namespace Lzy.Extension.MultiInheritance
{
    /// <summary>
    /// 一个空接口，用于实现C#‘多继承’
    /// </summary>
    public interface IMultiInheritance
    {
    }

    /// <summary>
    /// 空接口的扩展方法，用于实现多继承，继承了IEmpty接口的类可在此扩展方法
    /// </summary>
    public static class MultiInheritanceExtension
    {
        /// <summary>
        /// 展示C#‘多继承’技术
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">The t.</param>
        public static void ShowMultiInheritance<T>(this T t) where T : IMultiInheritance
        {
            Console.WriteLine("我实现了C#的‘多继承’！");
            MessageBox.Show("我实现了C#的‘多继承’！");
        }
    }
}
