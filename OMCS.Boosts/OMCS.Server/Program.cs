using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Configuration;

namespace OMCS.Server
{
    static class Program
    {
        private static IMultimediaServer MultimediaServer;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {  
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                
                GlobalUtil.SetAuthorizedUser(ConfigurationManager.AppSettings["AuthorizedUser"], ConfigurationManager.AppSettings["AuthorizedPassword"]);
                GlobalUtil.SetMaxLengthOfUserID(byte.Parse(ConfigurationManager.AppSettings["MaxLengthOfUserID"]));
                OMCSConfiguration config = new OMCSConfiguration();

                //用于验证登录用户的帐密
                DefaultUserVerifier userVerifier = new DefaultUserVerifier();
                Program.MultimediaServer = MultimediaServerFactory.CreateMultimediaServer(int.Parse(ConfigurationManager.AppSettings["Port"]), userVerifier, config, bool.Parse(ConfigurationManager.AppSettings["SecurityLogEnabled"]));
                                
                MainServerForm form = new MainServerForm(Program.MultimediaServer);
                
                Application.Run(form);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }           
    }
}
