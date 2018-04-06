using System;
using System.Collections.Generic;
using System.Text;
using OMCS.Passive;
using System.Diagnostics;

namespace OMCS.Boost
{
    /// <summary>
    /// OMCS多媒体管理器协助者。
    /// </summary>
    public static class MultimediaManagerHelper
    {
        /// <summary>
        /// 方法一直阻塞到多媒体管理器变成可用。
        /// </summary>
        /// <param name="manager">要监控的多媒体管理器实例</param>
        /// <param name="timeoutSpanInSecs">等待的最大时间，单位：秒。如果小于等于0，表示无限。</param>
        /// <returns>true表示多媒体管理器已经可用，false表示超时。</returns>
        public static bool WaitUtilAvailable(IMultimediaManager manager, int timeoutSpanInSecs)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (!manager.Available)
            {
                System.Threading.Thread.Sleep(100);
                if (timeoutSpanInSecs > 0 && stopwatch.Elapsed.TotalSeconds >= timeoutSpanInSecs)
                {
                    stopwatch.Stop();
                    return false;
                }
            }
            stopwatch.Stop();
            return true;
        }
    }
}
