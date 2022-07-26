using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
//using System.Windows.Forms;
using Leaf.xNet;
//using Fizzler;
//using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using System.Net;
using System.Drawing;
using System.ComponentModel;
using System.Text.RegularExpressions;
using Keys = OpenQA.Selenium.Keys;
using System.Threading;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;


namespace Project_parser_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IWebDriver browzer;
        int y;
        public MainWindow()
        {
            InitializeComponent();
            browzer = new OpenQA.Selenium.Chrome.ChromeDriver();
            browzer.Manage().Window.Maximize();
            auto_login_deal_by();

        }
        private void auto_login_deal_by()//Автоматический вход на Deal.by
        {
            try
            {
                browzer.Navigate().GoToUrl("https://my.deal.by/cms/product/create");
                IWebElement element = browzer.FindElement(By.Id("phone_email"));//.SendKeys("");// ;/
                element.SendKeys("director@t-x.by");
                element = browzer.FindElement(By.Id("password"));
                element.SendKeys("T-x28092017s");
                element = browzer.FindElement(By.ClassName("button__text--ujaS_"));
                element.Click();
            }
            catch
            {
                auto_login_deal_by();
                LogWrite("Ошибка подключения происходит переподключение");
                MessageBox.Show("Ошибка подключения происходит переподключение");
            }

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool metka = true;
            do
            {
                try
                {
                    LogWrite("Подключение к сайту RAm.by");
                    browzer.Navigate().GoToUrl(textBox2.Text);
                    metka = false;
                }
                catch
                {
                    MessageBox.Show("Неправильно введен url");
                }
            } while (metka);

            ram_by();
        }

        private void ram_by() // Парсинг по сайту с товароми и выборка их п оочереди
        {
            List<IWebElement> prods = browzer.FindElements(By.XPath("//*[@id='store_products']/div/div/div/div/div/h3/a[1]")).ToList();
            IWebElement name_for_file = browzer.FindElement(By.XPath("//*[@id='manreplace']"));
            IWebElement links_prod;
            string fileName = "txt/" + name_for_file.Text + ".txt";
            remove_copy(prods);
            remove_copy_in_list_and_file(prods, fileName);
            string temp_url = browzer.Url;
            List<string> link_string = new List<string>();
            for (int i = 0; i < prods.Count; i++)
            {
                link_string.Add(prods[i].Text);
            }
            DateTime ib_begin = DateTime.Now;
            for (int o = 0; o < 3; o++)
            {
                for (int i = 0; i < prods.Count; i++)
                {
                    links_prod = browzer.FindElement(By.PartialLinkText(link_string[i]));
                    links_prod.Click();
                    parsing_opisanie_ram_by(link_string[i]);
                    writer_in_file(fileName, link_string[i]);
                    browzer.Navigate().GoToUrl(temp_url);
                }

            }

            DateTime in_end = DateTime.Now;
            //DateTime delta = in_end - in_end;
            MessageBox.Show((in_end.Minute - ib_begin.Minute).ToString() + ":" + (in_end.Second - ib_begin.Second).ToString());
        }

        private void remove_copy(List<IWebElement> prod)//удаление повторяющихся элементов
        {
            string s1, s2;
            Double l = 0;
            Double s;
            int metka_test;
            Double scc;

            List<string> str = new List<string>();
            for (int i = 0; i < prod.Count; i++)
            {
                str.Add(prod[i].Text);
            }
            Double y = 0;
            try
            {
                for (int i1 = 0; i1 < str.Count; i1++)
                {
                    for (int i2 = 0; i2 < str.Count; i2++)
                    {
                        y = 0;
                        l = 0;
                        s = str[i1].Length > str[i2].Length ? str[i2].Length : str[i1].Length;
                        metka_test = 0;
                        s1 = str[i1];
                        s2 = str[i2];
                        for (int i = 0; i < (s1.Length > s2.Length ? s2.Length : s1.Length); i++)
                        {
                            if (i1 != i2)
                            {
                                scc = s1.Length > s2.Length ? s2.Length : s1.Length;
                                if (s1[i] == s2[i])
                                {
                                    l++;
                                    metka_test = 1;
                                    y = l / s;
                                }
                                if (y >= 0.80)
                                {
                                    str.RemoveAt(i2);
                                    prod.RemoveAt(i2);
                                    LogWrite("Удален: " + s2 + "\r\n");
                                    LogWrite("Повторение с: " + s1 + "\r\n");
                                    LogWrite("Совпадение: " + y + "\r\n");
                                    i = (s1.Length > s2.Length ? s2.Length : s1.Length);
                                }
                            }
                        }
                    }
                }

            }
            catch
            {
                MessageBox.Show("Exeption");
            }

        }
        private void remove_copy_in_list_and_file(List<IWebElement> prod, string file_name)//удаление повторяющихся элементов в сравнении с файлом
        {
            if (System.IO.File.Exists(file_name))
            {
                int metka_test;
                Double l = 0;
                Double s;
                LogWrite("начался поиск");
                string s1, s2;
                Double ls = 0;
                Double scc;
                Double y = 0;
                LogWrite("Начался поиск одинаковых элементов");
                StreamReader srts = new StreamReader(file_name);
                string srtu = srts.ReadToEnd();
                srts.Close();
                Regex r = new Regex(@"\r\n");
                List<string> str = new List<string>(srtu.Split('.'));
                for (int i = 0; i < str.Count; i++)
                {
                    str[i] = r.Replace(str[i], "");
                }

                for (int i = 0; i < str.Count; i++)
                    for (int u = 0; u < prod.Count; u++)
                    {
                        if (String.Compare(str[i], prod[u].Text) == 0)
                        {
                            prod.RemoveAt(u);
                            LogWrite("Удалён причина есть в файле: " + str[i] + "\r\n");
                        }
                    }
            }
        }

        private void parsing_opisanie_ram_by(string name_prods)//ПАрсинг описания с RAm.by
        {

            //  IWebElement prods = browzer.FindElement(By.XPath("//[class='gLFyf gsfi']/div[2]/div/div[1]/div/div[1]/input"));

            //browzer.Navigate().GoToUrl(textBox4.Text);
            //IWebElement cost = browzer.FindElement(By.XPath("/html/body/div[1]/div[3]/div/div[2]/div[2]/div[1]/div/div[1]/div[2]/div[1]/div/input"));
            //MessageBox.Show(cost.Text);

            //b-product-edit__label

            //   MessageBox.Show("cost_s");

            IWebElement cost = browzer.FindElement(By.XPath("/html/body/div[1]/div[6]/div/div/div[2]/div[2]/div[1]/div[1]/span"));
            string cost_string = cost.Text;
            bool metka_s = true;

            List<IWebElement> name_params = browzer.FindElements(By.XPath("//*[@id='contentTab1']/table[1]/tbody/tr/td")).ToList();
            List<IWebElement> vid_params = browzer.FindElements(By.XPath("//*[@id='contentTab1']/table[1]/tbody/tr/td/b")).ToList();
            //   /html/body/div[1]/div[6]/div/div/div[2]/div[2]/div[1]/div[1]/span
            //IWebElement cost = browzer.FindElement(By.XPath("/html/body/div[1]/div[6]/div/div/div[2]/div[2]/div[1]/div[1]/span"));

            List<string> string_name_params = new List<string>();
            List<string> string_vid_params = new List<string>();
            List<int> count_tables = new List<int>();
            for (int i = 0; i < name_params.Count; i++)
            {
                string_name_params.Add(name_params[i].Text);
                if (name_params[i].Text == "")
                    metka_s = false;
            }
            for (int i = 0; i < vid_params.Count; i++)
            {
                string_vid_params.Add(vid_params[i].Text);
            }
            if (name_params.Count > 0 && metka_s)
            {

                haper();
                int stork_count_table = (string_name_params.Count + string_vid_params.Count) / 2;
                create_the_tabble_ram_by(stork_count_table.ToString());
                search_buton();
                vhachalo_table(stork_count_table.ToString());
                IWebElement tr_td = browzer.FindElement(By.XPath("//*[@id='cke_1_contents']/iframe")); // 

                bool metka = false;
                ////*[@id="contentTab1"]/table[1]/tbody/tr/td/b
                for (int i = 0; i < string_name_params.Count; i++)
                {
                    metka = false;
                    for (int u = 0; u < string_vid_params.Count; u++)
                    {
                        //if (i+1 < string_name_params.Count)
                        if (i > 0)
                        {
                            if (String.Compare(string_name_params[i], string_name_params[i - 1]) != 0)
                                if (String.Compare(string_name_params[i], string_vid_params[u]) == 0)
                                {
                                    metka = true;
                                    u = string_vid_params.Count;
                                }
                        }
                        else
                            metka = true;
                    }
                    if (metka)
                    {

                        IWebElement test = browzer.FindElement(By.XPath("//*[@id='cke_" + (y + 54).ToString() + "']"));
                        test.Click();
                        //MessageBox.Show("stope");
                        test = browzer.FindElement(By.XPath("//*[@id='cke_" + (y + 3).ToString() + "']"));
                        test.Click();
                        //.  MessageBox.Show("нажамкали");
                        tr_td.SendKeys(string_name_params[i]);
                        LogWrite("\r\n" + string_name_params[i] + ":\r\n");
                        test = browzer.FindElement(By.XPath("//*[@id='cke_" + (y + 3).ToString() + "']"));
                        // MessageBox.Show("отжмакали");
                        test.Click();
                        tr_td.SendKeys(Keys.Tab);
                    }
                    else
                    {
                        tr_td.SendKeys(string_name_params[i]);
                        LogWrite(string_name_params[i] + ", ");
                        if (i < (string_name_params.Count - 1))
                            tr_td.SendKeys(Keys.Tab);
                    }
                }

                browzer.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                List<IWebElement> inputs = browzer.FindElements(By.ClassName("b-input__field")).ToList();
                /*Название позиции 0 
                   Код/Артикул 1
                   Розничная цена 2*/
                inputs[0].SendKeys(name_prods);
                inputs[1].SendKeys("999999");
                inputs[2].SendKeys(cost_string);

                IWebElement fotos = browzer.FindElement(By.ClassName("b-uploader-extend__file-input"));
                //   IWebElement fotos = browzer.FindElement(By.ClassName("b-pseudo-link b-pseudo-link_type_without-line"));
                //b-pseudo-link b-pseudo-link_type_without-line 
                //b-pseudo-link b-pseudo-link_type_without-line"
                //..fotos.Click();
                // File file = new File("src/test/resources/photo.png");
                // ..File photo_gile = new File("0.jpg");
                fotos.SendKeys("C:/Users/Fenixoko/Desktop/Project_parser/Project_parser/bin/Debug/prods/0.jpg");
                // MessageBox.Show("");


                LogWrite("create the table");

            }
            else
            {
                LogWrite("Не достаточно информации \r\n");
            }
        }
        private void vhachalo_table(string ctr_int)//переход в начало созданой таблицы на deal.by
        {
            int innach;
            IWebElement tr_td = browzer.FindElement(By.XPath("//*[@id='cke_1_contents']/iframe"));
            if (Convert.ToInt32(ctr_int) <= 7)
            {
                innach = 6;
            }
            else
            {
                innach = Convert.ToInt32(ctr_int) * 2 - 7;
            }
            tr_td.SendKeys("ss");
            tr_td.Click();
            for (int i = 0; i < innach; i++)
            {
                //tr_td.SendKeys(i.ToString());
                tr_td.SendKeys(Keys.Up);
            }

        }
        private void search_buton()
        {
            browzer.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            y = 0;
            bool metka = true;
            while (metka)
            {
                try
                {
                    y++;
                    //By.PartialLinkText(link_string[i])
                    IWebElement tr_td = browzer.FindElement(By.XPath("//*[@id='cke_" + y.ToString() + "']"));
                    //*[@id='cke_221']/span[1]
                    //*[@id="cke_206"]/span[1]
                    tr_td.Click();
                    // List<IWebElement> tr_td = browzer.FindElements(By.XPath("//*[@id='cke_" + y.ToString() + "']")).ToList();



                    metka = false;
                }
                catch
                {
                    LogWrite("перебор элемента №: " + y + "\r\n");
                }
            }
        }
        private void create_the_tabble_ram_by(string ct_int)
        {
            browzer.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            try
            {
                browzer.Navigate().GoToUrl("https://my.deal.by/cms/product/create");
                //  System.Threading.Thread.Sleep(3000);
                IWebElement tabale = browzer.FindElement(By.XPath("//*[@id='cke_28']/span[1]"));
                tabale.Click();
                //  MessageBox.Show("suka");
                // System.Threading.Thread.Sleep(500);
                //  string s = "20";
                // IWebElement
                tabale = browzer.FindElement(By.XPath("//*[@id='cke_70_textInput']"));
                tabale.Clear();
                tabale.SendKeys(ct_int.ToString());
                tabale = browzer.FindElement(By.XPath("//*[@id='cke_106_label']"));
                tabale.Click();
            }
            catch
            {
                create_the_tabble_ram_by(ct_int);
            }
        }


        private void writer_in_file(string fileName, string stoka)
        {
            DirectoryInfo dirInfo = new DirectoryInfo("txt");
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            FileStream aFile = new FileStream(fileName, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(aFile);
            aFile.Seek(0, SeekOrigin.End);
            //progressBar1.Maximum = prods.Count;
            // progressBar1.Value = 0;
            //foreach (IWebElement pereb in prods)
            // {
            sw.WriteLine(stoka + ".");
            //richTextBox1.AppendText(stoka + "\n\r");
            //   progressBar1.Increment(1);
            //    }
            sw.Close();
            LogWrite("Записан в файл объект: " + stoka);
            LogWrite("Переход к след странице");
        }
        private void LogWrite(string txt)
        {
            RichTextBox1.AppendText(txt + Environment.NewLine);
           // Application.DoEvents();
            TextB1.AppendText(txt + Environment.NewLine);
            //Application.DoEvents();
            // RichTextBox.SelectionStart = RichTextBox.Text.Length;
        }

        public void haper()
        {
            var date = new HttpRequest();
            string name;
            string response = date.Get(browzer.Url).ToString();
            HtmlAgilityPack.HtmlDocument hap = new HtmlAgilityPack.HtmlDocument();
            File.WriteAllText("Test.txt", response);
            //richTextBox1.Text = response;
            textBox2.AppendText("");
            obrabotchik_html();
        }
        private void obrabotchik_html()//Scachivanie jpg iz ram
        {
            string[] kord = new string[3];
            StreamReader srts = new StreamReader("test.txt");
            string srt = srts.ReadToEnd();
            srts.Close();
            List<string> str = new List<string>(srt.Split('<'));
            //  MessageBox.Show("");
            int k = 0;
            List<string> instr;

            for (int i = 0; i < str.Count; i++)
            {
                if (str[i].Contains(".jpg") || str[i].Contains(".href"))
                {
                    //richTextBox1.AppendText(str[i]);
                    k++;
                }
                else
                {

                    str.RemoveAt(i);
                    i--;
                }
            }
            for (int i = 0; i < str.Count; i++)
            {
                if (str[i].Contains("img"))
                {
                    //richTextBox1.AppendText(str[i]);
                    k++;
                }
                else
                {
                    str.RemoveAt(i);
                }
            }
            for (int i = 0; i < str.Count; i++)
            {
                if (str[i].Contains("300x300"))
                {
                    //richTextBox1.AppendText(str[i]);
                    k++;
                }
                else
                {

                    str.RemoveAt(i);
                    i--;
                }
            }
            Regex r = new Regex(@"/(.*).jpg");
            List<string> hyper_link = new List<string>();
            List<string> image = new List<string>();
            string sotav;
            for (int i = 0; i < str.Count; i++)
            {
                sotav = "https:";
                str[i] = r.Match(str[i]).Groups[1].Value + ".jpg";
                List<string> strk = new List<string>(str[i].Split('/'));
                for (int t = 0; t < strk.Count; t++)
                {
                    sotav = string.Concat(sotav, "/", strk[t]);
                }
                hyper_link.Add(sotav);
                sotav = "";
            }
       /*     for (int i = 0; i < hyper_link.Count; i++)
            {
                richTextBox2.AppendText(hyper_link[i] + "\r\n");


            }*/
            //  MessageBox.Show(browzer.Title);
            string directory = "prods/";
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            try
            {
                for (int i = 0; i < hyper_link.Count; i++)
                {
                    string savePath =System.IO.Path.Combine(directory, i + ".jpg");
                    using (WebClient localClient = new WebClient())
                    {
                        localClient.DownloadFile(hyper_link[i], savePath);
                    }
                    savePath = "";
                }
            }
            catch
            {
                MessageBox.Show("Exeption 404 not found web");
            }

            LogWrite("Saveing foto....");
        }
       
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LogWrite("sujka");
        }

        private void Exit_B_Click(object sender, RoutedEventArgs e)
        {
            browzer.Quit();
            System.Windows.Application.Current.Shutdown();
            // this.Exit();
        }
    }
}
