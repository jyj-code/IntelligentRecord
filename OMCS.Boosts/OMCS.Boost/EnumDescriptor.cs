using System;
using System.Collections.Generic;
using System.Text;
using OMCS.Passive;

namespace OMCS.Boost
{
    /// <summary>
    /// 枚举描述器。用于将枚举值转换为对应的中文表达。
    /// </summary>
    public static class EnumDescriptor
    {
        #region GetDescription for ConnectResult
        /// <summary>
        /// 获取ConnectResult枚举值对应的中文描述。
        /// </summary>        
        public static string GetDescription(ConnectResult connectResult)
        {
            if (connectResult == ConnectResult.Succeed)
            {
                return "Succeed：连接成功。";
            }
            if (connectResult == ConnectResult.CantConnectRepeatly)
            {
                return "CantConnectRepeatly：不能重复连接同一设备！";
            }
            if (connectResult == ConnectResult.ChannelUnavailable)
            {
                return "ChannelUnavailable：通道不可用，当前客户端与OMCS服务器之间的连接尚未建立或已经断开！";
            }           
            if (connectResult == ConnectResult.DeviceInUsing)
            {
                return "DeviceInUsing：要连接的目标设备已经被其它程序占用！";
            }
            if (connectResult == ConnectResult.DeviceInvalid)
            {
                return "DeviceInvalid：要连接的目标设备不存在或不可用！";
            }
            if (connectResult == ConnectResult.DeviceUnauthorized)
            {
                return "DeviceUnauthorized：本次OMCS授权不包含目标设备类型！";
            }
            if (connectResult == ConnectResult.ExceptionOccured)
            {
                return "ExceptionOccured：在连接的过程中出现了异常！";
            }
            if (connectResult == ConnectResult.OwnerNotInitialized)
            {
                return "MultimediaManagerNotInitialized目标设备主人的多媒体管理器还未完成初始化！";
            }
            if (connectResult == ConnectResult.SelfOffline)
            {
                return "SelfOffline：在连接的过程中，当前客户端与OMCS服务器之间的连接已经断开！";
            }
            if (connectResult == ConnectResult.TargetUserOffline)
            {
                return "TargetUserOffline：在连接的过程中，对方与OMCS之间的连接已经断开！";
            }
            if (connectResult == ConnectResult.Timeout)
            {
                return "Timeout：等待对方回复超时！";
            }

            return "";
        } 
        #endregion

        #region GetDescription for ConnectorDisconnectedType
        /// <summary>
        /// 获取ConnectorDisconnectedType枚举值对应的中文描述。
        /// </summary>   
        public static string GetDescription(ConnectorDisconnectedType connectorDisconnectedType)
        {
            if (connectorDisconnectedType == ConnectorDisconnectedType.GuestActiveDisconnect)
            {
                return "自己主动断开了到目标设备的连接！";
            }
            if (connectorDisconnectedType == ConnectorDisconnectedType.GuestOffline)
            {
                return "当前客户端与OMCS服务器之间的连接已经断开！";
            }
            if (connectorDisconnectedType == ConnectorDisconnectedType.OwnerActiveDisconnect)
            {
                return "对方主动断开了其设备与当前连接器的连接！";
            }
            if (connectorDisconnectedType == ConnectorDisconnectedType.OwnerOffline)
            {
                return "对方与OMCS服务器之间的连接已经断开！";
            }
            if (connectorDisconnectedType == ConnectorDisconnectedType.TrialTimeout)
            {
                return "试用时间结束！";
            }

            return "";
        } 
        #endregion
    }
}
