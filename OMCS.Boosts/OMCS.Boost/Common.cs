using System;
using System.Collections.Generic;
using System.Text;

namespace OMCS.Boost
{
    /// <summary>
    /// 远程协助的类型：全屏？部分屏幕？
    /// </summary>
    public enum RemoteHelpStyle
    {
        PartScreen = 0,
        AllScreen
    }

    /// <summary>
    /// 挂掉视频聊天的原因。
    /// </summary>
    public enum HungUpCauseType
    {
        ActiveHungUp = 0,
        ConnectorDisconnected
    }
}
