using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Windows.Forms;

namespace WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            //System.Threading.Thread.CurrentThread.CurrentUICulture =new System.Globalization.CultureInfo("zh"); 
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CN");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("EN");
            //ComponentResourceManager resources = new ComponentResourceManager(typeof(Form1));
            //this.button1 = new Button();          
            //resources.ApplyResources(this.button1, "button1");

            ////WinForm.Properties
            //ResourceManager temp = new ResourceManager("WinForm.Properties.Resources", typeof(Resources).Assembly);
            //直接读取
            //var ss = Properties.Resources.rensheng;

            ////WinForm.Form1
            //ResourceManager resourceManager = new ResourceManager("WinForm.Form1", Assembly.GetExecutingAssembly());
            ResourceManager resourceManager = new ResourceManager("WinForm.Form1", typeof(Form1).Assembly);

            ////WinForm.Resource1
            //ResourceManager resourceManager = new ResourceManager("WinForm.Resource1", typeof(Resource1).Assembly);

            var sss = resourceManager.GetString("String1",new System.Globalization.CultureInfo("zh-CN"));
            this.label1.Text = sss;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.Log.Fatal("Fatal");
            Program.Log.Error("Error");
            Program.Log.Warn("Warn");
            Program.Log.Info("Info");
            Program.Log.Debug("Debug");
        }
    }
}
