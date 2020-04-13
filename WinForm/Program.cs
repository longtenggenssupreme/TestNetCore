using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace WinForm
{
    static class Program
    {
        public static log4net.ILog Log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            log4net.Config.XmlConfigurator.Configure();
            Application.Run(new Form1());
        }
    }
}
