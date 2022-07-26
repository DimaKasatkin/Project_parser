using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_parser
{
    public partial class Form2 : Form
    {
        IWebDriver browzer;
        public Form2()
        {      
            InitializeComponent();
        }

        public void richtextbox(string input)
        {
            textBox2.AppendText(input +"\r\n");
        }
        public void textBox1_input(string input,string count)
        { 
            textBox1.Clear();
            textBox1.AppendText(input.ToString() + "/" + count);
         //   textBox2.AppendText(input + "\r\n");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            browzer.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            IWebElement tovar_categories = browzer.FindElement(By.XPath("/html/body/div[1]/div[3]/div/div[2]/div[2]/div[2]/div/div[4]/div[2]/div/div[1]/div"));
          //  tovar_categories.Click();
            //html body div.b-cms div div div.b-content div div.b-section.b-section_type_margin-20.b-product-edit div.b-product-edit__wrapper div.b-product-edit__table div.b-product-edit__field div.b-recommended-cat div.b-input div div.b-smart-selector.b-smart-selector_type_dd div div.b-smart-selector__body.b-smart-selector__body_max-height_520.b-smart-selector__body_min-height_250 ul.b-smart-selector__list li.b-smart-selector__item div.b-smart-selector__text-wrapper div ul.b-smart-selector__list.b-smart-selector__list_type_child li.b-smart-selector__item div.b-smart-selector__text-wrapper span.b-smart-selector__dropdown-caption.b-pseudo-link span.b-smart-selector__text span
            //  List<IWebElement> tovar_categories1 = browzer.FindElements(By.XPath("html body div.b-cms div div div.b-content div div.b-section.b-section_type_margin-20.b-product-edit div.b-product-edit__wrapper div.b-product-edit__table div.b-product-edit__field div.b-recommended-cat div.b-input div div.b-smart-selector.b-smart-selector_type_dd div div.b-smart-selector__body.b-smart-selector__body_max-height_520.b-smart-selector__body_min-height_250 ul.b-smart-selector__list li.b-smart-selector__item div.b-smart-selector__text-wrapper div ul.b-smart-selector__list.b-smart-selector__list_type_child li.b-smart-selector__item div.b-smart-selector__text-wrapper span.b-smart-selector__dropdown-caption.b-pseudo-link span.b-smart-selector__text span")).ToList();
            //li.b-smart-selector__item:nth-child(4) > div:nth-child(2) > span:nth-child(1) > span:nth-child(2) > span:nth-child(1)
           // tovar_categories = browzer.FindElement(By.CssSelector("li.b-smart-selector__item:nth-child(22) > div:nth-child(2) > span:nth-child(1) > span:nth-child(2) > span:nth-child(1)"));       
         //   
            //  tovar_categories.Click();
          //  tovar_categories = browzer.FindElement(By.CssSelector("li.b-smart-selector__item:nth-child(22) > div:nth-child(2) > div:nth-child(3) > ul:nth-child(1) > li:nth-child(2) > div:nth-child(2) > span:nth-child(1) > span:nth-child(2) > span:nth-child(1)"));
          //  tovar_categories.Click();
           // tovar_categories = browzer.FindElement(By.CssSelector("li.b-smart-selector__item:nth-child(22) > div:nth-child(2) > div:nth-child(3) > ul:nth-child(1) > li:nth-child(2) > div:nth-child(2) > div:nth-child(3) > ul:nth-child(1) > li:nth-child(2) > div:nth-child(3) > span:nth-child(1) > span:nth-child(2) > span:nth-child(1)"));
           // tovar_categories.Click();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
