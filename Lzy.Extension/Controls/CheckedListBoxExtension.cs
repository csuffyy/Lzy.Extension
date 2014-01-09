using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Lzy.Extension.Controls
{
    /// <summary>
    /// CheckedListBoxExtension的扩展方法
    /// </summary>
    public static class CheckedListBoxExtension
    {
        /// <summary>
        /// 全部选定所有项
        /// </summary>
        public static void 全部选定(this CheckedListBox c)
        {
            for (int i = 0; i < c.Items.Count; i++)
            {
                c.SetItemChecked(i, true);
            }
        }

        /// <summary>
        /// 全部取消选定所有项
        /// </summary>
        public static void 全部取消选定(this CheckedListBox c)
        {
            for (int i = 0; i < c.Items.Count; i++)
            {
                c.SetItemChecked(i, false);
            }
        }

        /// <summary>
        /// 反向选定所有项
        /// </summary>
        public static void 反向选定(this CheckedListBox c)
        {
            for (int i = 0; i < c.Items.Count; i++)
            {
                c.SetItemChecked(i, !c.GetItemChecked(i));
            }
        }

        /// <summary>
        /// 根据选定状态列表中的值，逐一设定各列表项的选定状态
        /// </summary>
        /// <param name="c"></param>
        /// <param name="bools">包含所有列表项对应的选定状态的列表</param>
        public static void 自设选定(this CheckedListBox c, IEnumerable<bool> bools)
        {
            int x = 0;
            foreach (bool f in bools)
            {
                c.SetItemChecked(x++, f);
            }
        }

        /// <summary>
        /// 根据选定项索引列表的值，设定指定索引处列表项的选定状态为已选定，其它处均设为未选定
        /// </summary>
        /// <param name="c"></param>
        /// <param name="ints">包含选定列表项的索引位置的列表</param>
        public static void 自设选定(this CheckedListBox c, IEnumerable<int> ints)
        {
            c.全部取消选定();
            foreach (int f in ints)
            {
                c.SetItemChecked(f, true);
            }
        }

        /// <summary>
        /// 将一个字典作为数据源加载到CheckedListBox，字典的键即为列表项的值，字典的值用以指示列表项是否被选定
        /// </summary>
        /// <typeparam name="T">自定义类型</typeparam>
        /// <param name="c"></param>
        /// <param name="src">数据源</param>
        public static void 数据源设定<T>(this CheckedListBox c, Dictionary<T, bool> src)
        {
            c.DataSource = null;
            c.DataSource = src.Keys.ToList();
            c.自设选定(src.Values);
        }

        /// <summary>
        /// 将CheckedListBox的列表项及其选定状态作为字典返回，字典的键即为列表项的值，字典的值用以指示列表项是否被选定
        /// </summary>
        /// <typeparam name="T">自定义类型</typeparam>
        /// <returns>字典</returns>
        public static Dictionary<T, bool> 数据源获取<T>(this CheckedListBox c)
        {
            var l = new Dictionary<T, bool>();
            for (int i = 0; i < c.Items.Count; i++)
            {
                l.Add((T)c.Items[i], c.GetItemChecked(i));
            }
            return l;
        }
    }
}
