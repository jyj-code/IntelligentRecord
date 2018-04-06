using System;
using System.Collections.Generic;
using System.Text;
using ESBasic;
using System.Drawing;
using ESBasic.Loggers;
using OMCS.Passive;

namespace OMCS.Boost
{
    /// <summary>
    /// 智能多媒体管理器的工作模式。
    /// </summary>
    public enum MultimediaManagerMode
    {
        Common = 0,
        ConnectOnlyWhenNeed
    }

    /// <summary>
    /// 智能多媒体管理器，支持按需连接（在需要的时候，才连接多媒体服务器）。
    /// </summary>
    public class AgileMultimediaManager 
    {
        private IAgileLogger logger;
        private MultimediaManagerMode multimediaManagerMode = MultimediaManagerMode.Common;
        private IMultimediaManager multimediaManager;
        private OmcsLoginParas omcsLoginParas;

        private AgileMultimediaManager() { }

        #region Singleton
        private static AgileMultimediaManager singleton = new AgileMultimediaManager();
        public static AgileMultimediaManager Singleton
        {
            get
            {
                return AgileMultimediaManager.singleton;
            }
        }
        #endregion

        /// <summary>
        /// AgileMultimediaManager内部使用的多媒体管理器实例。管理器实例可能还未完成初始化。
        /// </summary>
        public IMultimediaManager InnerMultimediaManager
        {
            get
            {
                return this.multimediaManager;
            }
        }

        #region Initialize
        /// <summary>
        /// 初始化"rude"多媒体管理器。
        /// </summary>
        /// <param name="rudeManager">未调用Initialize方法的多媒体管理器。</param>
        /// <param name="agileLogger">日志记录器</param>       
        public void Initialize(IMultimediaManager rudeManager, OmcsLoginParas paras, IAgileLogger agileLogger, MultimediaManagerMode mode)
        {
            this.omcsLoginParas = paras;
            this.multimediaManager = rudeManager;
            this.multimediaManagerMode = mode;
            this.logger = agileLogger;
            this.multimediaManager.DeviceDisconnected += new CbGeneric<string, OMCS.MultimediaDeviceType>(multimediaManager_DeviceDisconnected);
            this.multimediaManager.ConnectorDisconnected += new CbGeneric<IMultimediaConnector, ConnectorDisconnectedType>(multimediaManager_ConnectorDisconnected);

            if (this.multimediaManagerMode == MultimediaManagerMode.Common)
            {
                string msg = null;
                this.Prepare(true ,out msg);
            }
        }

        void multimediaManager_ConnectorDisconnected(IMultimediaConnector obj1, ConnectorDisconnectedType obj2)
        {
            this.ReleaseHandle();
        }

        void multimediaManager_DeviceDisconnected(string guestID, OMCS.MultimediaDeviceType type)
        {
            this.ReleaseHandle();
        }

        /// <summary>
        /// 如果多媒体管理器空闲，则断开与多媒体服务器的连接。
        /// </summary>
        private void ReleaseHandle()
        {
            if (this.multimediaManagerMode == MultimediaManagerMode.Common)
            {
                return;
            }

            if (!this.multimediaManager.Available)
            {
                return;
            }

            if (!this.multimediaManager.Working)
            {
                this.multimediaManager.Dispose();
            }
        }
        #endregion

        #region Prepare
        /// <summary>
        /// 如果与多媒体服务器连接失败，则返回null。
        /// </summary>       
        public IMultimediaManager Prepare(out string errorMsg)
        {
            return this.Prepare(false ,out errorMsg);
        }

        private IMultimediaManager Prepare(bool rethrow ,out string errorMsg)
        {
            errorMsg = null;
            try
            {               
                if (!this.multimediaManager.Available)
                {
                    this.multimediaManager.Initialize(this.omcsLoginParas.UserID, this.omcsLoginParas.Password, this.omcsLoginParas.ServerIP, this.omcsLoginParas.ServerPort);
                }

                return this.multimediaManager;
            }
            catch (Exception ee)
            {
                errorMsg = ee.Message;
                this.logger.Log(ee, "OMCS.Passive.AgileMultimediaManager.Prepare", ESBasic.Loggers.ErrorLevel.Standard);
                if (rethrow)
                {
                    throw;
                }
                return null;
            }
        }
        #endregion
    }

    public sealed class OmcsLoginParas
    {
        public OmcsLoginParas()
        {

        }
        public OmcsLoginParas(string _userID ,string _password ,string _serverIP, int _serverPort)
        {
            this.userID = _userID;
            this.password = _password;
            this.serverIP = _serverIP;
            this.serverPort = _serverPort;
        }

        #region UserID
        private string userID;
        public string UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        #endregion

        #region Password
        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        } 
        #endregion

        #region ServerIP
        private string serverIP;
        public string ServerIP
        {
            get { return serverIP; }
            set { serverIP = value; }
        } 
        #endregion

        #region ServerPort
        private int serverPort;
        public int ServerPort
        {
            get { return serverPort; }
            set { serverPort = value; }
        } 
        #endregion
    }
}
