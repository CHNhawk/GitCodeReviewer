using CefSharp;
using CefSharp.WinForms;
using StyleCop;
using StyleCopTool.StyleCop;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StyleCopTool
{
    public partial class Form1 : Form
    {
        public ChromiumWebBrowser chromeBrowser;

        public Form1()
        {
            InitializeComponent();
            InitializeChromium();
        }

        //初始化浏览器并启动
        public void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            // Initialize cef with the provided settings
            Cef.Initialize(settings);
            // Create a browser component
            //chromeBrowser = new ChromiumWebBrowser("https://www.baidu.com");
            chromeBrowser = new ChromiumWebBrowser("D:/Xuanyu/projects/GitCodeReviewer/Web/index.html");
            // Add it to the form and fill it to the form window.
            this.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var helper = new StyleCopHelper();
            bool bb = helper.Test();
            label1.Text = (bb ? "成功" : "失败") + $" s_numberViolations: {helper.NumberViolations}";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }
    }
}
