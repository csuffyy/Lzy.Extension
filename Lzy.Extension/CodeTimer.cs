using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace Lzy.Extension
{
    /// <summary>
    /// 用于测量代码运行时间及CPU、内存使用情况的静态类
    /// 为保证测试结果准确，请在使用前先调用CodeTimer.Initialize()静态方法
    /// </summary>
    public static class CodeTimer
    {
        static CodeTimer()
        {
            Initialize();
        }

        /// <summary>
        /// 初始化CodeTimer，运行一次空方法
        /// </summary>
        public static void Initialize()
        {
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
            Thread.CurrentThread.Priority = ThreadPriority.Highest;
            Run("", 1, () => { });
        }

        /// <summary>
        /// 开始代码运行测试
        /// </summary>
        /// <param name="name">自定义的测试名称</param>
        /// <param name="iteration">测试方法的执行次数</param>
        /// <param name="action">要运行的测试方法</param>
        public static void Run(string name, int iteration, Action action)
        {
            if (string.IsNullOrEmpty(name))
            {
                return;
            }

            // 1.
            ConsoleColor currentForeColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(name);

            // 2.
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            var gcCounts = new int[GC.MaxGeneration + 1];
            for (int i = 0; i <= GC.MaxGeneration; i++)
            {
                gcCounts[i] = GC.CollectionCount(i);
            }

            // 3.
            var watch = new Stopwatch();
            watch.Start();
            ulong cycleCount = GetCycleCount();
            for (int i = 0; i < iteration; i++)
            {
                action();
            }
            ulong cpuCycles = GetCycleCount() - cycleCount;
            watch.Stop();

            // 4.
            Console.ForegroundColor = currentForeColor;
            Console.WriteLine("\t代码执行时间:\t{0} ms", watch.ElapsedMilliseconds.ToString("N0"));
            Console.WriteLine("\tCPU 时钟周期:\t{0}", cpuCycles.ToString("N0"));

            // 5.
            for (int i = 0; i <= GC.MaxGeneration; i++)
            {
                int count = GC.CollectionCount(i) - gcCounts[i];
                Console.WriteLine("\t第{0}代: \t\t{1}", i, count);
            }

            Console.WriteLine();
        }

        /// <summary>
        /// 获取当前线程CPU运行周期数
        /// </summary>
        /// <returns>CPU运行周期数</returns>
        private static ulong GetCycleCount()
        {
            ulong cycleCount = 0;
            QueryThreadCycleTime(GetCurrentThread(), ref cycleCount);
            return cycleCount;
        }

        /// <summary>
        /// Queries the thread cycle time.
        /// </summary>
        /// <param name="threadHandle">The thread handle.</param>
        /// <param name="cycleTime">The cycle time.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool QueryThreadCycleTime(IntPtr threadHandle, ref ulong cycleTime);

        /// <summary>
        /// Gets the current thread.
        /// </summary>
        /// <returns>IntPtr.</returns>
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetCurrentThread();
    }
}