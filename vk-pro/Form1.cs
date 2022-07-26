using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using vk_pro.Properties;
using VkNet;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace vk_pro
{
    public partial class Form1 : Form
    {
        IWebDriver browzer;
        public Form1()
        {
           // browzer = new OpenQA.Selenium.Chrome.ChromeDriver();
            //browzer.Manage().Window.Maximize();
            InitializeComponent();
            //  auto_login_vk_com();  VkNet.Enums.Filters.
        }
        //  VkNet.Enums.Filters.Settings settings = VkNet.Enums.Filters.Settings.All; // уровень доступа к данным

        private void button1_Click(object sender, EventArgs e)
        {
           
        }



    }

}