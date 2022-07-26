using Leaf.xNet;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Keys = OpenQA.Selenium.Keys;

namespace VKBot
{
    public partial class Form1 : Form
    {
        DateTime date;
        IWebDriver browzer;


        //   Form2 form2 = new Form2();


        public Form1()
        {

            // form2.Show();

            InitializeComponent();


            // File.WriteAllText(@"txt/links.txt", string.Empty);
            // File.WriteAllText(@"txt/products_and_cost.txt", string.Empty);


            OpenQA.Selenium.Chrome.ChromeOptions co = new OpenQA.Selenium.Chrome.ChromeOptions();
            co.AddArgument(@"user-data-dir=C:\Users\Fenikso\AppData\Local\Google\Chrome\User Data");
            // co.AddArgument(@"C:\Users\Admin\AppData\Local\Google\Chrome\User Data");
            browzer = new OpenQA.Selenium.Chrome.ChromeDriver(co);
           // browzer.Manage().Window.Maximize();
            // co.AddArgument(@"C:\Users\Admin\AppData\Local\Google\Chrome\User Data");
            ///      auto_login_vk_com();


            this.TopMost = true;
            button1.Text = "Передний";
            Size resolution = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size;
            this.Location = new Point(0, resolution.Height / 2 + 270);
            //    Location.X = 2;
            //  form2.Show();
            //    form2.TopMost = true;
            //     DateTime time =DateTime.Now;

            //    writer_in_file("txt/date.txt", time.ToString());


            //  read_date();



            //  load_file_for_search_yanex();

            //form2.Show();
            reader_file_db();
            podgotovka();
        }

        private void read_date()
        {
            if (System.IO.File.Exists("txt/date.txt"))
            {
                StreamReader srts = new StreamReader("txt/date.txt");
                string srtu = srts.ReadToEnd();
                srts.Close();
                date = DateTime.Parse(srtu);
            }
        }

        private void auto_login_vk_com()//Автоматический вход на Deal.by
        {
            try
            {
                browzer.Navigate().GoToUrl("https://vk.com/");
                IWebElement element = browzer.FindElement(By.Id("index_email"));//.SendKeys("");// ;/
                element.SendKeys("+375447228549");
                element = browzer.FindElement(By.Id("index_pass"));
                element.SendKeys("Ыфылу159");
                element = browzer.FindElement(By.Id("index_login_button"));
                element.Click();
            }
            catch
            {
                auto_login_vk_com();
                //LogWrite("Ошибка подключения происходит переподключение");
                MessageBox.Show("Ошибка подключения происходит переподключение");
            }
        }


        int i_links_news = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            browzer.Navigate().GoToUrl("https://vk.com/public178578659");
            IWebElement element = browzer.FindElement(By.Id("post_field"));


            ///./   ..   element = browzer.FindElement(By.Id("post_field"));
        }
        EventWaitHandle handle = new AutoResetEvent(false);
        private void button2_Click(object sender, EventArgs e)
        {
            File.WriteAllText(@"txt/links.txt", string.Empty);
            File.WriteAllText(@"txt/products_and_cost.txt", string.Empty);
            browzer.Quit();
            string directory1 = "temp_photo/";
            DirectoryInfo dir = new DirectoryInfo(directory1);
            if (Directory.Exists(directory1))
            {
                dir.Delete(recursive: true);
            }

            //  browzer.Quit();
            Application.Exit();
        }

        bool news = false;
        bool nexeter = true;

        List<IWebElement> links_news;
        private void pda_main_page()
        {
            browzer.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //https://4pda.ru
            //Thread.Sleep(500);
            browzer.Navigate().GoToUrl(textBox3.Text);

            //IWebElement prod = browzer.FindElement(By.CssSelector("#raKz1legz0xSB > article:nth-child(1) > div.description > h2 > a > span"));
            links_news = browzer.FindElements(By.XPath("//*[@id]/article/div/h2/a/span")).ToList();
            for (int i = 0; i < links_news.Count; i++)
            {
                textBox2.AppendText("[" + i + "] : " + links_news[i].Text + Environment.NewLine + new string('=', 100) + Environment.NewLine);
            }
        }


        private void haper_news()
        {



            LogWrite("Начало получения информации");
            // IWebElement links_prod;
            browzer.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            string name_news = browzer.FindElement(By.XPath("//*[@id]/div[1]/div[1]/div[2]/h1/span")).Text;



            LogWrite("Получения информации p1");
            List<IWebElement> peshka = browzer.FindElements(By.XPath("//*[@id]/div[1]/div[2]/div/p")).ToList();
            LogWrite("Получения информации p2");
            List<IWebElement> peshka2 = browzer.FindElements(By.XPath("//*[@id]/div/div/p")).ToList();
            ////*[@id]/div/div/p

            List<string> name_p = new List<string>();
            //   List<IWebElement> links = browzer.FindElements(By.XPath("//*[@id='rj89ZMYe2JO']/div/div/div/div/div/a/img")).ToList();
            LogWrite("Получения информации links 1");
            List<IWebElement> links = browzer.FindElements(By.XPath("//*[@id]/div/div/div/p/a/img")).ToList();//просто парсит картинки с 4pda без перелистываний
            LogWrite("Получения информации links 2");
            List<IWebElement> links2 = browzer.FindElements(By.XPath("//*[@id]/div[1]/div/div/div/div/a/img")).ToList();
            LogWrite("Получения информации links 3");
            List<IWebElement> links3 = browzer.FindElements(By.XPath("//*[@id]/div/div/figure/img")).ToList();
            LogWrite("Получения информации links 4");
            List<IWebElement> links4 = browzer.FindElements(By.XPath("//*[@id]/div/div/div/p/img")).ToList();
            LogWrite("Получения информации links 5");
            List<IWebElement> links5 = browzer.FindElements(By.XPath("//*[@id]/div/div/div/p/span/span/a/img")).ToList();
            LogWrite("Получения информации links 6");
            List<IWebElement> links6 = browzer.FindElements(By.XPath("//*[@id]/div/div/div/p/span/span/a/img")).ToList();

            //  //*[@id]/div/div/div/p/span/span/a/img

            LogWrite("Конец получения информации");
            //    //*[@id]/div/div/div/p/img
            //List<>
            //  //*[@id]/div/div/figure/img
            links = browzer.FindElements(By.XPath("//*[@id]/div/div/div/p/a/img")).ToList();







            LogWrite("Скачаивание 1 партии фото");
            save_photo(0, links);
            LogWrite("Скачаивание 2 партии фото");
            save_photo(500, links2);
            LogWrite("Скачаивание 3 партии фото");
            save_photo(1000, links3);
            LogWrite("Скачаивание 4 партии фото");
            save_photo(1500, links4);
            LogWrite("Скачаивание 5 партии фото");
            save_photo(2000, links5);
            LogWrite("Скачаивание 7 партии фото");




            peshka = browzer.FindElements(By.XPath("//*[@id]/div[1]/div[2]/div/p")).ToList();
            peshka2 = browzer.FindElements(By.XPath("//*[@id]/div/div/p")).ToList();
            //  //*[@id="rS2O7CAidAM"]/div/div/div/p/a/img
            //  links[0].GetAttribute("src");
            //   MessageBox.Show(links[0].GetAttribute("src"));

            LogWrite("Начало добавление информации в вк");

            for (int i = 0; i < peshka.Count; i++)
            {
                name_p.Add(peshka[i].Text);
            }
            for (int i = 0; i < peshka2.Count; i++)
            {
                name_p.Add(peshka2[i].Text);
            }

            browzer.Navigate().GoToUrl("https://vk.com/public178578659");
            IWebElement vk_adder;

            /* for(int i=0; i<new DirectoryInfo("temp_photo").GetFiles().Length;i++)
             {
                 IWebElement fotos = browzer.FindElement(By.CssSelector("#page_add_media > div.media_selector.clear_fix > a.ms_item.ms_item_photo._type_photo"));
                 ////*[@id="photos_choose_upload_area_label"]
                 ///  v //*[@id="photos_choose_upload_area_label"]
                 ///   fotos = browzer.FindElement(By.CssSelector("#page_add_media > div.media_selector.clear_fix > a.ms_item.ms_item_photo._type_photo"));
                 fotos.Click();
                 fotos = browzer.FindElement(By.XPath("//*[@id='photos_choose_upload_area_label']"));
                 //  .. fotos.SendKeys("C:/Users/Fenixoko/Desktop/Project_parser/VKBot/bin/Debug/temp_photo1/0.jpg");

                 fotos.Click();

             }
             незаконченая функция по вставке изображдения потом доделай а то ручками будешь втавлять
              */


            vk_adder = browzer.FindElement(By.Id("post_field"));
            vk_adder.SendKeys("&#12288;" + name_news);
            vk_adder.SendKeys(OpenQA.Selenium.Keys.Return);
            for (int i = 0; i < name_p.Count - 1; i++)
            {
                vk_adder.SendKeys("&#12288;" + name_p[i]);
                vk_adder.SendKeys(OpenQA.Selenium.Keys.Return);
            }

            // MessageBox.Show( new DirectoryInfo(@"temp_photo").GetFiles().Length.ToString());
            // links_prod = browzer.FindElement(By.ClassName("img"));


            // this will display list of all images exist on page

            /* for (IWebElement ele:links)
            {
                System.out.println(ele.getAttribute("src"));
            }
            */
            // post_field
            //   //*[@id="raKz1legz0xSB"]/div[1]/div[2]/div/p
            //   //*[@id='raKz1legz0xSB']/div[1]/div/p[5]
            // MessageBox.Show("");

            // //*[@id="raKz1legz0xSB"]/article[1]/div[2]/h2/a/span
            ////*[@id="rS2O7CAidAM"]/article/div/h2/a/span
            ////*[@id="rS2O7CAidAM"]/article[1]/div[2]/h2/a/span
            ///
            //  DirectoryInfo dir = new DirectoryInfo(directory1);
            //   dir.Delete(recursive: true);

            LogWrite("Конец добавление информации в вк");
            writer_in_file("txt/4pda.txt", name_news + ".");
        }

        public void haper()
        {
            var date = new HttpRequest();
            string name;
            string response = date.Get(browzer.Url).ToString();
            HtmlAgilityPack.HtmlDocument hap = new HtmlAgilityPack.HtmlDocument();
            File.WriteAllText("Test.txt", response);
            // richTextBox1.Text = response;
            //textBox2.AppendText("");
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
                    //     richTextBox1.AppendText(str[i]);
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
                    //    richTextBox1.AppendText(str[i]);
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
                    //   richTextBox1.AppendText(str[i]);
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
            /* for (int i = 0; i < hyper_link.Count; i++)
             {
                 //richTextBox2.AppendText(hyper_link[i] + "\r\n");


             }*/
            //  MessageBox.Show(browzer.Title);
            string directory = "prods/";
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            // try
            // {
            for (int i = 0; i < hyper_link.Count; i++)
            {
                string savePath = Path.Combine(directory, i + ".jpg");
                using (WebClient localClient = new WebClient())
                {
                    localClient.DownloadFile(hyper_link[i], savePath);
                }
                savePath = "";
            }
            for (int i = 0; i < hyper_link.Count; i++)
            {

                string savePath = Path.Combine(directory, i + ".jpg");
                using (WebClient localClient = new WebClient())
                {
                    localClient.DownloadFile(hyper_link[i], savePath);
                }
                savePath = "";
            }

            //}
            // catch
            //  {
            //    mark_photo = false;
            //    LogWrite("Exeption 404 not found web");
            //}

            //LogWrite("Saveing foto....");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string s = "zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz";
            MessageBox.Show(s.Length.ToString());
        }

        private void writer_in_file(string fileName, string stoka)
        {
            //   fileName = "4pda.ru";
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
            sw.WriteLine(stoka);
            //  richTextBox1.AppendText(stoka + "\n\r");
            //   progressBar1.Increment(1);
            //    }
            sw.Close();
            // LogWrite("Записан в файл объект: " + stoka + "\r\n");
            /// LogWrite("Переход к след странице \n\r");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            links_news[Convert.ToInt32(textBox3.Text)].Click();
            haper_news();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            news = true;
            handle.Set();
        }

        private void save_photo(int iph, List<IWebElement> link)
        {
            string directory1 = "temp_photo/";
            if (!Directory.Exists(directory1))
            {
                Directory.CreateDirectory(directory1);
            }
            // try
            // {
            //int iph = 1000;
            for (int i = 0; i < link.Count; i++)
            {
                string savePath = Path.Combine(directory1, iph + ".jpg");
                using (WebClient localClient = new WebClient())
                {
                    if (link[i].GetAttribute("src").ToString().Contains(".gif") != true)
                    {
                        localClient.DownloadFile(link[i].GetAttribute("src"), savePath);
                        iph++;
                    }
                }
                savePath = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pda_main_page();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
        private void four_dpa_haper()
        {
            LogWrite("Переход по сылке");
            del_phtos();
            browzer.Navigate().GoToUrl(textBox3.Text);
            if (remove_copy_in_list_and_file("txt/4pda.txt", browzer.FindElement(By.XPath("//*[@id]/div[1]/div[1]/div[2]/h1/span")).Text))
            {
                haper_news();
                textBox3.Clear();
                date_changet();
                clicks_photo();
            }
            else
            {
                MessageBox.Show("Данная статья есть");
            }
        }
        private bool remove_copy_in_list_and_file(string file_name, string name_news)//удаление повторяющихся элементов в сравнении с файлом
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
                    if (String.Compare(str[i], name_news) == 0)
                        return false;

            }
            return true;
        }

        private void del_phtos()
        {
            string directory1 = "temp_photo/";
            DirectoryInfo dir = new DirectoryInfo(directory1);
            if (Directory.Exists(directory1))
            {
                dir.Delete(recursive: true);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string directory1 = "temp_photo/";
            DirectoryInfo dir = new DirectoryInfo(directory1);
            if (Directory.Exists(directory1))
            {
                dir.Delete(recursive: true);
            }
        }

        private void LogWrite(string txt)
        {
            textBox2.AppendText(txt + Environment.NewLine);
            textBox2.SelectionStart = textBox2.Text.Length;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        bool metka = true;
        private void button1_Click_1(object sender, EventArgs e)
        {
            // .. form1.TopMost = true;          
            if (metka)
            {
                this.TopMost = true;
                button1.Text = "Передний";
                metka = false;
            }
            else
            {
                metka = true;
                this.TopMost = false;
                button1.Text = "Back";
            }
        }
        int time = 0;
        private void button4_Click_1(object sender, EventArgs e)
        {
            if (time == 0)
            {
                //       time =Convert.ToInt32( textBox1.Text);
            }
            else
            {
                time = time + 2;
                LogWrite(time.ToString());
            }
        }

        private void button4_Click_2(object sender, EventArgs e)
        {


        }

        private void techcult_haper()
        {
            LogWrite("Переход по сылке" + textBox3.Text);
            del_phtos();
            browzer.Navigate().GoToUrl(textBox3.Text);
            if (remove_copy_in_list_and_file("txt/TechCult.txt", browzer.FindElement(By.XPath("//*[@id='content_col']/div[3]/div[1]/h1")).Text))
            {
                haper_news_tech_cult();
                date_changet();
                clicks_photo();
            }
            else
            {
                MessageBox.Show("Данная статья есть");
            }
        }

        private void ixbt_haper()
        {
            LogWrite("Переход по сылке" + textBox3.Text);
            del_phtos();
            browzer.Navigate().GoToUrl(textBox3.Text);
            if (remove_copy_in_list_and_file("txt/ixbt.txt", browzer.FindElement(By.XPath("//*[@id='pagebody']/div/div/div/div/div/div/h1")).Text))

            //*[@id="pagebody"]/div[3]/div[2]/div/div[1]/div[1]/div[1]/h1
            //*[@id='pagebody']/div[6]/div[2]/div/div[1]/div[1]/div[1]/h1

            {
                haper_news_ixbt();
                date_changet();
                clicks_photo();
            }
            else
            {
                MessageBox.Show("Данная статья есть");
            }
        }
        private void haper_news_ixbt()
        {
            LogWrite("Начало получения информации");
            browzer.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement name_newes = browzer.FindElement(By.XPath("//*[@id='pagebody']/div/div/div/div/div/div/h1"));
            string name_news = name_newes.Text;
            LogWrite("Получения информации p1");
            List<IWebElement> peshka = browzer.FindElements(By.XPath("//*[@id='pagebody']/div/div/div/div/div/div/p")).ToList();
            List<string> name_p = new List<string>();
            LogWrite("Получения информации links 1");
            List<IWebElement> links = browzer.FindElements(By.XPath("//*[@id='pagebody']/div/div/div/div/div/div/div/figure/img")).ToList();//просто парсит картинки с 4pda без перелистываний
            LogWrite("Получения информации links 2");
            List<IWebElement> links2 = browzer.FindElements(By.XPath("//*[@id='pagebody']/div/div/div/div/div/div/figure/a/img")).ToList();
            LogWrite("Получения информации links 3");
            List<IWebElement> links3 = browzer.FindElements(By.XPath("//*[@id='pagebody']/div/div/div/div/div/div/div/figure/a/img")).ToList();



            LogWrite("Конец получения информации");
            LogWrite("Скачаивание 1 партии фото");
            save_photo(0, links);
            LogWrite("Скачаивание 2 партии фото");
            save_photo(500, links2);
            LogWrite("Скачаивание 3 партии фото");
            save_photo(1000, links3);
            LogWrite("Начало добавление информации в вк");

            for (int i = 0; i < peshka.Count; i++)
            {
                name_p.Add(peshka[i].Text);
            }


            browzer.Navigate().GoToUrl("https://vk.com/public178578659");
            IWebElement vk_adder;

            vk_adder = browzer.FindElement(By.Id("post_field"));
            vk_adder.SendKeys("&#12288;" + name_news);
            vk_adder.SendKeys(OpenQA.Selenium.Keys.Return);
            for (int i = 0; i < name_p.Count - 7; i++)
            {
                vk_adder.SendKeys("&#12288;" + name_p[i]);
                vk_adder.SendKeys(OpenQA.Selenium.Keys.Return);
            }
            LogWrite("Конец добавление информации в вк");
            writer_in_file("txt/ixbt.txt", name_news + ".");
            textBox3.Clear();
        }

        private void haper_news_tech_cult()
        {
            LogWrite("Начало получения информации");
            // IWebElement links_prod;
            browzer.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            string name_news = browzer.FindElement(By.XPath("//*[@id='content_col']/div[3]/div[1]/h1")).Text;
            LogWrite("Получения информации p1");
            List<IWebElement> peshka = browzer.FindElements(By.XPath("//*[@id]/div/div/div/p")).ToList();
            ////*[@id]/div/div/p
            List<string> name_p = new List<string>();
            //   List<IWebElement> links = browzer.FindElements(By.XPath("//*[@id='rj89ZMYe2JO']/div/div/div/div/div/a/img")).ToList();
            LogWrite("Получения информации links 1");
            List<IWebElement> links = browzer.FindElements(By.XPath("//*[@id]/div/div/div/div/img")).ToList();//просто парсит картинки с 4pda без перелистываний
                                                                                                              //*[@id]/div/div/div/div/img
                                                                                                              //  //*[@id]/div/div/div/p/span/span/a/img

            LogWrite("Конец получения информации");
            //    //*[@id]/div/div/div/p/img
            //List<>
            //  //*[@id]/div/div/figure/img





            LogWrite("Скачаивание 1 партии фото");
            save_photo(0, links);




            //peshka = browzer.FindElements(By.XPath("//*[@id]/div[1]/div[2]/div/p")).ToList();
            //    peshka2 = browzer.FindElements(By.XPath("//*[@id]/div/div/p")).ToList();
            //  //*[@id="rS2O7CAidAM"]/div/div/div/p/a/img
            //  links[0].GetAttribute("src");
            //   MessageBox.Show(links[0].GetAttribute("src"));

            LogWrite("Начало добавление информации в вк");

            for (int i = 0; i < peshka.Count; i++)
            {
                name_p.Add(peshka[i].Text);
            }


            browzer.Navigate().GoToUrl("https://vk.com/public178578659");
            IWebElement vk_adder;

            /* for(int i=0; i<new DirectoryInfo("temp_photo").GetFiles().Length;i++)
             {
                 IWebElement fotos = browzer.FindElement(By.CssSelector("#page_add_media > div.media_selector.clear_fix > a.ms_item.ms_item_photo._type_photo"));
                 ////*[@id="photos_choose_upload_area_label"]
                 ///  v //*[@id="photos_choose_upload_area_label"]
                 ///   fotos = browzer.FindElement(By.CssSelector("#page_add_media > div.media_selector.clear_fix > a.ms_item.ms_item_photo._type_photo"));
                 fotos.Click();
                 fotos = browzer.FindElement(By.XPath("//*[@id='photos_choose_upload_area_label']"));
                 //  .. fotos.SendKeys("C:/Users/Fenixoko/Desktop/Project_parser/VKBot/bin/Debug/temp_photo1/0.jpg");

                 fotos.Click();

             }
             незаконченая функция по вставке изображдения потом доделай а то ручками будешь втавлять
              */


            vk_adder = browzer.FindElement(By.Id("post_field"));
            vk_adder.SendKeys("&#12288;" + name_news);
            vk_adder.SendKeys(OpenQA.Selenium.Keys.Return);
            for (int i = 0; i < name_p.Count - 1; i++)
            {
                vk_adder.SendKeys("&#12288;" + name_p[i]);
                vk_adder.SendKeys(OpenQA.Selenium.Keys.Return);
            }

            // MessageBox.Show( new DirectoryInfo(@"temp_photo").GetFiles().Length.ToString());
            // links_prod = browzer.FindElement(By.ClassName("img"));


            // this will display list of all images exist on page

            /* for (IWebElement ele:links)
            {
                System.out.println(ele.getAttribute("src"));
            }
            */
            // post_field
            //   //*[@id="raKz1legz0xSB"]/div[1]/div[2]/div/p
            //   //*[@id='raKz1legz0xSB']/div[1]/div/p[5]
            // MessageBox.Show("");

            // //*[@id="raKz1legz0xSB"]/article[1]/div[2]/h2/a/span
            ////*[@id="rS2O7CAidAM"]/article/div/h2/a/span
            ////*[@id="rS2O7CAidAM"]/article[1]/div[2]/h2/a/span
            ///
            //  DirectoryInfo dir = new DirectoryInfo(directory1);
            //   dir.Delete(recursive: true);

            LogWrite("Конец добавление информации в вк");
            writer_in_file("txt/TechCult.txt", name_news + ".");
            textBox3.Clear();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            if (textBox3.Text.Contains("4pda.ru"))
                four_dpa_haper();
            if (textBox3.Text.Contains("techcult.ru"))
                techcult_haper();
            if (textBox3.Text.Contains("ixbt.com"))
                ixbt_haper();

        }

        DateTime newdate;
        int i = 0;

        private void date_changet()
        {
            File.WriteAllText(@"txt/date.txt", string.Empty);
            i += 2;
            newdate = date.AddHours(i);
            if (newdate.Hour != 0)
            {
                newdate = date.AddHours(i);
            }
            else
            {
                newdate = date.AddHours(12);
            }
            writer_in_file("txt/date.txt", newdate.ToString());
            textBox1.Text = newdate.ToString();
        }

        private void button4_Click_3(object sender, EventArgs e)
        {


        }

        private void clicks_photo()
        {
            browzer.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            IWebElement webElement = browzer.FindElement(By.XPath("//*[@id='page_add_media']/div[1]/a[1]"));
            webElement.Click();

            webElement = browzer.FindElement(By.CssSelector("#photos_choose_upload_area > div.photos_choose_upload_area_upload"));
            webElement.Click();

        }

        private void button4_Click_4(object sender, EventArgs e)
        {
            date_changet();


            //*[@id='photos_choose_upload_area_label']
        }
        int vk_enter = 0;

        private void button4_Click_5(object sender, EventArgs e)
        {
            if (textBox3.Text.Contains("vek"))
            {
                dva_one_Vek();
            }
            else
            {
                if (textBox3.Text.Contains("market"))
                    yandex_prods_in_vk_news();
            }
            textBox3.Clear();
        }

        private void yandex_prods_in_vk_news()
        {
            try
            {
                IWebElement vk_adder;
                browzer.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                browzer.Navigate().GoToUrl(textBox3.Text);

                IWebElement all_catigories = browzer.FindElement(By.XPath("/html/body/div[1]/div[5]/div/div/div/div/a"));
                all_catigories.Click();

                List<string> name_p = new List<string>();
                //  IWebElement photo_mini = browzer.FindElement(By.XPath("//*[@id='n-gallery']/div[1]/div/div[1]/img"));
                //  photo_mini.Click();

                string name_prods = browzer.FindElement(By.CssSelector("body > div.main > div:nth-child(7) > div > div.n-product-headline__content > div.n-product-headline__headline > div > div.n-title__text > h1")).Text;

                List<IWebElement> name_of_catigories = browzer.FindElements(By.XPath("/html/body/div[1]/div[6]/div[1]/div/dl")).ToList();

                List<IWebElement> type_categories = browzer.FindElements(By.XPath("/html/body/div[1]/div[6]/div/div[1]/div/dl")).ToList();
                //      List<IWebElement> vol_categories = browzer.FindElements(By.XPath("/html/body/div/div/div/div/div/dl/dd/span")).ToList();
                Regex newReg = new Regex(@"\r\n");
              

                /*
                for (int i_name = 0; i_name < name_of_catigories.Count; i_name++)
                {
                    name_p.Add(name_of_catigories[i_name].Text);
                    List<IWebElement> type_categories1 = browzer.FindElements(By.XPath("/html/body/div[1]/div[6]/div/div[1]/div[" + (i_name + 2) + "]/dl")).ToList();
                    for (int i = 0; i < type_categories1.Count; i++)
                    {
                        name_p.Add(type_categories1[i].Text);
                    }
                }*/

                for (int i_name = 0; i_name < name_of_catigories.Count; i_name++)
                {
                    //string s = ;
                    name_p.Add(newReg.Replace(name_of_catigories[i_name].Text, " : "));
                  

                }




                  /*  Regex r = new Regex(@"\r\n");
                //List<string> str = new List<string>(srtu.Split('.'));
                for (int i = 0; i < name_p.Count; i++)
                {
                    name_p[i] = r.Replace(name_p[i], " : ");
                }*/
                //MessageBox.Show("");
                //*[@id='content']/div[1]/div/div[1]/h1
                browzer.Navigate().GoToUrl("https://vk.com/public178578659");
                vk_adder = browzer.FindElement(By.Id("post_field"));
                vk_adder.SendKeys("Товар в наличии");

                vk_adder.SendKeys(OpenQA.Selenium.Keys.Return); vk_adder.SendKeys(OpenQA.Selenium.Keys.Return);
                vk_adder.SendKeys(name_prods); vk_adder.SendKeys(OpenQA.Selenium.Keys.Return);
                vk_adder.SendKeys(OpenQA.Selenium.Keys.Return);
                vk_adder.SendKeys("Цена : ");
                vk_adder.SendKeys(OpenQA.Selenium.Keys.Return); vk_adder.SendKeys(OpenQA.Selenium.Keys.Return);
                for (int i = 0; i < name_p.Count - 1; i++)
                {
                    vk_adder.SendKeys(name_p[i]);
                    vk_adder.SendKeys(OpenQA.Selenium.Keys.Return);
                    if (name_p[i + 1].Contains(":") != true)
                    {
                        vk_adder.SendKeys(OpenQA.Selenium.Keys.Return);
                    }
                }

            }
            catch
            {
                MessageBox.Show("Ошибка не найдено описание товара");
            }


        }
        private void dva_one_Vek()
        {
            try
            {
                IWebElement vk_adder;
                browzer.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                browzer.Navigate().GoToUrl(textBox3.Text);
                List<string> name_p = new List<string>();
                //  IWebElement photo_mini = browzer.FindElement(By.XPath("//*[@id='n-gallery']/div[1]/div/div[1]/img"));
                //  photo_mini.Click();

                string name_prods = browzer.FindElement(By.XPath("//*[@id='content']/div[1]/div/div[1]/h1")).Text;

                List<IWebElement> type_categories = browzer.FindElements(By.XPath("//*[@id='j-tabs-attrs']/div/div/div/div")).ToList();
                //      List<IWebElement> vol_categories = browzer.FindElements(By.XPath("/html/body/div/div/div/div/div/dl/dd/span")).ToList();

                for (int i = 0; i < type_categories.Count; i++)
                {
                    name_p.Add(type_categories[i].Text);
                }
                Regex r = new Regex(@"\r\n");
                //List<string> str = new List<string>(srtu.Split('.'));
                for (int i = 0; i < name_p.Count; i++)
                {
                    name_p[i] = r.Replace(name_p[i], " : ");
                }
                //MessageBox.Show("");
                //*[@id='content']/div[1]/div/div[1]/h1
                browzer.Navigate().GoToUrl("https://vk.com/public178578659");
                vk_adder = browzer.FindElement(By.Id("post_field"));
                vk_adder.SendKeys("Товар в наличии");

                vk_adder.SendKeys(OpenQA.Selenium.Keys.Return); vk_adder.SendKeys(OpenQA.Selenium.Keys.Return);
                vk_adder.SendKeys(name_prods); vk_adder.SendKeys(OpenQA.Selenium.Keys.Return);
                vk_adder.SendKeys(OpenQA.Selenium.Keys.Return);
                vk_adder.SendKeys("Цена : ");
                vk_adder.SendKeys(OpenQA.Selenium.Keys.Return); vk_adder.SendKeys(OpenQA.Selenium.Keys.Return);
                for (int i = 0; i < name_p.Count - 1; i++)
                {
                    vk_adder.SendKeys(name_p[i]);
                    vk_adder.SendKeys(OpenQA.Selenium.Keys.Return);
                    if (name_p[i + 1].Contains(":") != true)
                    {
                        vk_adder.SendKeys(OpenQA.Selenium.Keys.Return);
                    }
                }

            }
            catch
            {
                MessageBox.Show("Ошибка не найдено описание товара");
            }
        }

        private void dva_one_Vek(string link)
        {
            try
            {
                IWebElement vk_adder;
                browzer.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                browzer.Navigate().GoToUrl(link);
                List<string> name_p = new List<string>();
                //  IWebElement photo_mini = browzer.FindElement(By.XPath("//*[@id='n-gallery']/div[1]/div/div[1]/img"));
                //  photo_mini.Click();

                string name_prods = browzer.FindElement(By.XPath("//*[@id='content']/div[1]/div/div[1]/h1")).Text;

                List<IWebElement> type_categories = browzer.FindElements(By.XPath("//*[@id='j-tabs-attrs']/div/div/div/div")).ToList();
                //      List<IWebElement> vol_categories = browzer.FindElements(By.XPath("/html/body/div/div/div/div/div/dl/dd/span")).ToList();

                for (int i = 0; i < type_categories.Count; i++)
                {
                    name_p.Add(type_categories[i].Text);
                }
                Regex r = new Regex(@"\r\n");
                //List<string> str = new List<string>(srtu.Split('.'));
                for (int i = 0; i < name_p.Count; i++)
                {
                    name_p[i] = r.Replace(name_p[i], " : ");
                }
                //MessageBox.Show("");
                //*[@id='content']/div[1]/div/div[1]/h1
                browzer.Navigate().GoToUrl("https://vk.com/public178578659");
                vk_adder = browzer.FindElement(By.Id("post_field"));
                vk_adder.SendKeys("Товар в наличии");
                vk_adder.SendKeys(OpenQA.Selenium.Keys.Return); vk_adder.SendKeys(OpenQA.Selenium.Keys.Return);
                vk_adder.SendKeys(name_prods);
                vk_adder.SendKeys(OpenQA.Selenium.Keys.Return);
                vk_adder.SendKeys("Цена : ");
                vk_adder.SendKeys(OpenQA.Selenium.Keys.Return); vk_adder.SendKeys(OpenQA.Selenium.Keys.Return);
                for (int i = 0; i < name_p.Count - 1; i++)
                {

                    vk_adder.SendKeys(name_p[i]);
                    vk_adder.SendKeys(OpenQA.Selenium.Keys.Return);
                    if (name_p[i + 1].Contains(":") != true)
                    {
                        vk_adder.SendKeys(OpenQA.Selenium.Keys.Return);
                    }
                }

            }
            catch
            {
                MessageBox.Show("Ошибка не найдено описание товара");
            }
        }


        private void button7_Click_1(object sender, EventArgs e)
        {
            try
            {
                browzer.Quit();
            }
            catch
            {
                MessageBox.Show("exe");
            }
            ///     form2.Show();  tyta

        }




        private void reader()
        {


        }

        bool google_not_open = true;

        private void button3_Click_1(object sender, EventArgs e)
        {
            LogWrite("Начался поск товаров в интернете и сохранение в файл");

            IWebElement search_yandex_input;
            //browzer.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            if (google_not_open)
            {
                browzer.Navigate().GoToUrl("https://www.google.by");
                google_not_open = false;
            }
            List<IWebElement> links_prods;
            for (int i = 0; i < str.Count; i++)
            {
                Regex newReg = new Regex(@"\t");
                string s = newReg.Replace(str[i], "");
                // if (str[i] == string.Empty) str.RemoveAt(i);
                try
                {

                    search_yandex_input = browzer.FindElement(By.XPath("//*[@id='tsf']/div/div/div/div/div/input"));

                    search_yandex_input.Clear();
                    search_yandex_input.SendKeys(s);
                    search_yandex_input.SendKeys(OpenQA.Selenium.Keys.Return);
                    //search_yandex_input.FindElement(By.XPath("/html/body/div/div/div/div/div/ul/li/div/div[1]"));
                    links_news = browzer.FindElements(By.XPath("//*[@id='rso']/div/div/div/div/div/div/a")).ToList();
                }
                catch
                {
                    browzer.Quit();
                    Thread.Sleep(1000);
                    browzer = new OpenQA.Selenium.Chrome.ChromeDriver();
                    browzer.Manage().Window.Maximize();
                    browzer.Navigate().GoToUrl("https://www.google.by");
                    search_yandex_input = browzer.FindElement(By.XPath("//*[@id='tsf']/div/div/div/div/div/input"));

                    search_yandex_input.Clear();
                    search_yandex_input.SendKeys(s);
                    search_yandex_input.SendKeys(OpenQA.Selenium.Keys.Return);
                    //search_yandex_input.FindElement(By.XPath("/html/body/div/div/div/div/div/ul/li/div/div[1]"));
                    links_news = browzer.FindElements(By.XPath("//*[@id='rso']/div/div/div/div/div/div/a")).ToList();
                }
                string path_search = "txt/searchs/";
                for (int y = 0; y < links_news.Count; y++)
                {
                    //  link[i].GetAttribute("src").ToString()
                    if (links_news[y].GetAttribute("href").ToString().Contains("21vek"))
                    {
                        LogWrite(links_news[y].GetAttribute("href").ToString());
                        writer_in_file(path_search + "prods_21vek_find.txt", s + " : " + links_news[y].GetAttribute("href").ToString());
                    }
                    if (links_news[y].GetAttribute("href").ToString().Contains("catalog.onliner.by"))
                    {
                        LogWrite(links_news[y].GetAttribute("href").ToString());
                        writer_in_file(path_search + "prods_catalog_find.txt", s + " : " + links_news[y].GetAttribute("href").ToString());
                    }
                    if (links_news[y].GetAttribute("href").ToString().Contains("777555"))
                    {
                        LogWrite(links_news[y].GetAttribute("href").ToString());
                        writer_in_file(path_search + "prods_777555_find.txt", s + " : " + links_news[y].GetAttribute("href").ToString());
                    }
                    if (links_news[y].GetAttribute("href").ToString().Contains("yandex"))
                    {
                        LogWrite(links_news[y].GetAttribute("href").ToString());
                        writer_in_file(path_search + "prods_market_yandex_find.txt", s + " : " + links_news[y].GetAttribute("href").ToString());
                    }
                    if (links_news[y].GetAttribute("href").ToString().Contains("ram.by"))
                    {
                        LogWrite(links_news[y].GetAttribute("href").ToString());
                        writer_in_file(path_search + "prods_ram_find.txt", s + " : " + links_news[y].GetAttribute("href").ToString());
                    }
                    writer_in_file(path_search + "ALL_LINKS_FIND.txt", s + " : " + links_news[y].GetAttribute("href").ToString());

                    //market
                }
                textBox1.Clear();
                textBox1.AppendText(i.ToString() + "/" + str.Count.ToString());
            }
        }
        List<string> str;

        private void load_file_for_search_yanex()
        {
            if (System.IO.File.Exists("txt/prods_temp_find.txt"))
            {
                StreamReader srts = new StreamReader("txt/prods_temp_find.txt");
                string srtu = srts.ReadToEnd();
                srts.Close();

                str = new List<string>(srtu.Split('+'));
                Regex r = new Regex(@"\r\n");
                //   List<string> str = new List<string>(srtu.Split('.'));
                for (int i = 0; i < str.Count; i++)
                {
                    str[i] = r.Replace(str[i], "");
                }
                for (var i = str.Count - 1; i > -1; i--)
                {
                    if (str[i] == string.Empty) str.RemoveAt(i);
                }
                for (var i = str.Count - 1; i > 0; i--)
                {
                    if (str[i].CompareTo(str[i - 1]) == 0)
                        str.RemoveAt(i);
                }
                LogWrite("Загружен файл с товарами");
            }
        }

        int dynemic_int = 0;

        public void testers()
        {



        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (dynemic_int < name_prods_in_search.Count)
            {
                IWebElement finder_image_in_yandex;
                browzer.Navigate().GoToUrl("https://yandex.by/images/");
                finder_image_in_yandex = browzer.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[1]/div[2]/form/div[1]/span/span/input"));
                // /html/body/div[1]/div/div/div/div[1]/div[2]/form/div[1]/span/span
                // /html/body/div[1]/div/div/div/div[1]/div[2]/form/div[1]/span/span/input
                // /html/body/div[1]/div[2]/div[1]/div[1]/div/div[1]/div/div/div[1]/div[2]/form/div[1]/span/input
                finder_image_in_yandex.SendKeys(name_prods_in_search[dynemic_int]);
                finder_image_in_yandex.SendKeys(Keys.Enter);
                //browzer.Navigate().GoToUrl("http://www.cyberforum.ru");
                dynemic_int++;
            }
            else
            {
                MessageBox.Show("Всё найдено");
            }
        }

        List<string> str_in_db;

        List<string> temp_name_prods = new List<string>();

        List<string> name_prods_in_search = new List<string>();

        List<string> links_in_file = new List<string>();
        private void podgotovka()
        {





            //  StreamReader srts = new StreamReader("txt/Test.txt");

            //prods_21vek_find

            StreamReader srts = new StreamReader("txt/prods_temp_find.txt");
            string srtu = srts.ReadToEnd();
            srts.Close();

            str = new List<string>(srtu.Split('\r'));
            Regex r = new Regex(@"\n");
            //   List<string> str = new List<string>(srtu.Split('.'));


            for (int i = 0; i < str.Count; i++)
            {
                str[i] = r.Replace(str[i], "");
            }
            for (var i = str.Count - 1; i > -1; i--)
            {
                if (str[i] == string.Empty) str.RemoveAt(i);
            }
            for (var i = str.Count - 1; i > 0; i--)
            {
                if (str[i].CompareTo(str[i - 1]) == 0)
                    str.RemoveAt(i);
            }
        }
        int o = 0;
        string temp_cost_for_vk;
        private void obrabotka_Files_search_cost_and_write_in_file()
        {
            Random rnd = new Random();
            int value; string tempers_cost = "";
            string tempers_link = "";
            value = rnd.Next(0, str.Count);
            Regex newReg = new Regex(@" : ");
            string s = newReg.Replace(str[value], "\t");
            List<string> name_and_link = new List<string>(s.Split('\t'));
            for (int y = 0; y < str_in_db.Count; y++)
            {
                //   if (str_in_db[y].CompareTo(name_and_link[0]) == 0)
                if (name_and_link[0].CompareTo(str_in_db[y]) == 0)
                {
                    // MessageBox.Show(str_in_db[y]+"  :: "+y+" : \r\n :0 "+ name_and_link[0]);
                    // MessageBox.Show(str_in_db[y + 3]);
                    //y = str_in_db.Count; 
                    tempers_cost = str_in_db[y] + "\r\n" + str_in_db[y + 3];
                    links_in_file.Add(name_and_link[1]);
                    tempers_link = name_and_link[1];
                    // MessageBox.Show(str[value]+"\r\n"+value+"\r\n O : = "+o);
                    writer_in_file("txt/logs.txt", str[value] + "     value :   " + value + "      O : = " + o);

                }
            }
            str.RemoveAt(value);
            File.WriteAllText(@"txt/prods_21vek_find.txt", string.Empty);
            for (int i = 0; i < str.Count; i++)
            {
                writer_in_file("txt/prods_21vek_find.txt", str[i]);
            }


            IWebElement finder_image_in_yandex;
            browzer.Navigate().GoToUrl("https://yandex.by/images/");
            finder_image_in_yandex = browzer.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[1]/div[2]/form/div[1]/span/span/input"));
            // /html/body/div[1]/div/div/div/div[1]/div[2]/form/div[1]/span/span
            // /html/body/div[1]/div/div/div/div[1]/div[2]/form/div[1]/span/span/input
            // /html/body/div[1]/div[2]/div[1]/div[1]/div/div[1]/div/div/div[1]/div[2]/form/div[1]/span/input
            finder_image_in_yandex.SendKeys(name_and_link[0]);
            finder_image_in_yandex.SendKeys(Keys.Enter);
            //browzer.Navigate().GoToUrl("http://www.cyberforum.ru");
            LogWrite("Файл сохранен");
            DialogResult dialogResult = MessageBox.Show(name_and_link[0] + "\r\n" + name_and_link[1], tempers_cost, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                name_prods_in_search.Add(name_and_link[0]);
                //  File.WriteAllText(@"txt/products_and_cost.txt", string.Empty);
                // writer_in_file("txt/links.txt",  name_and_link[1]);
                writer_in_file("txt/products_and_cost.txt", tempers_cost);

                temp_cost_for_vk = name_and_link[1];
                temp_name_prods.Add(str[value]);
                str.RemoveAt(value);
                for (var i = links_in_file.Count - 1; i > 0; i--)
                {
                    if (links_in_file[i].CompareTo(links_in_file[i - 1]) == 0)
                        links_in_file.RemoveAt(i);
                }

                for (var i = name_prods_in_search.Count - 1; i > 0; i--)
                {
                    if (name_prods_in_search[i].CompareTo(name_prods_in_search[i - 1]) == 0)
                        name_prods_in_search.RemoveAt(i);
                }
                //  File.WriteAllText(@"txt/links.txt", string.Empty);

                //  for (var i = 0; i < links_in_file.Count; i++)
                //  {
                writer_in_file("txt/links.txt", tempers_link);

                //    }

                //   File.WriteAllText(@"txt/prods_21vek_find.txt", string.Empty);



            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }


            //    MessageBox.Show(name_and_link[0]+ "\r\n"+name_and_link[1]);


            // MessageBox.Show("");





            // File.WriteAllText(@"txt/prods_21vek_find.txt", string.Empty);

            //  File.WriteAllText(@"txt/prods_21vek_find.txt", string.Empty);

            //    dell_links();
        }

        private void reader_file_db()
        {
            //  StreamReader srts = new StreamReader("txt/Test.txt");

            //prods_21vek_find

            StreamReader srts = new StreamReader("txt/Test.txt");
            string srtu = srts.ReadToEnd();
            srts.Close();

            str_in_db = new List<string>(srtu.Split('\t'));



            Regex r = new Regex(@"\r\n");
            //   List<string> str = new List<string>(srtu.Split('.'));


            for (int i = 0; i < str_in_db.Count; i++)
            {
                str_in_db[i] = r.Replace(str_in_db[i], "");
            }
            for (var i = str_in_db.Count - 1; i > -1; i--)
            {
                if (str_in_db[i] == string.Empty) str_in_db.RemoveAt(i);
            }
            for (var i = str_in_db.Count - 1; i > 0; i--)
            {
                if (str_in_db[i].CompareTo(str_in_db[i - 1]) == 0)
                    str_in_db.RemoveAt(i);
            }
            //write_file_in_rich_box();
            LogWrite("Файл загружен с списком цен и товаров");

        }


        private void dell_links()
        {
            StreamReader srts = new StreamReader("txt/links.txt");
            string srtu = srts.ReadToEnd();
            srts.Close();

            str_in_db = new List<string>(srtu.Split('\t'));



            Regex r = new Regex(@"\r\n");
            //   List<string> str = new List<string>(srtu.Split('.'));


            for (int i = 0; i < str_in_db.Count; i++)
            {
                str_in_db[i] = r.Replace(str_in_db[i], "");
            }
            for (var i = str_in_db.Count - 1; i > -1; i--)
            {
                if (str_in_db[i] == string.Empty) str_in_db.RemoveAt(i);
            }
            for (var i = str_in_db.Count - 1; i > 0; i--)
            {
                if (str_in_db[i].CompareTo(str_in_db[i - 1]) == 0)
                    str_in_db.RemoveAt(i);
            }
            //write_file_in_rich_box();
            //LogWrite("Файл загружен с списком цен и товаров");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            obrabotka_Files_search_cost_and_write_in_file();
        }

        int dynemic_int2 = 0;
        bool dynemic_button10_Click = false;
        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                IWebElement vk_adder;
                browzer.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                browzer.Navigate().GoToUrl("https://market.yandex.by/product--videokarta-palit-geforce-gtx-1050-1354mhz-pci-e-3-0-2048mb-7000mhz-128-bit-dvi-hdmi-hdcp-stormx/1712062125/spec?nid=55314&track=char");
                List<string> name_p = new List<string>();
                //  IWebElement photo_mini = browzer.FindElement(By.XPath("//*[@id='n-gallery']/div[1]/div/div[1]/img"));
                //  photo_mini.Click();

                string name_prods = browzer.FindElement(By.CssSelector("body > div.main > div:nth-child(7) > div > div.n-product-headline__content > div.n-product-headline__headline > div > div.n-title__text > h1")).Text;

                List<IWebElement> name_of_catigories = browzer.FindElements(By.XPath("/html/body/div[1]/div[6]/div/div[1]/div/h2")).ToList();

                List<IWebElement> type_categories = browzer.FindElements(By.XPath("/html/body/div[1]/div[6]/div/div[1]/div/dl")).ToList();
                //      List<IWebElement> vol_categories = browzer.FindElements(By.XPath("/html/body/div/div/div/div/div/dl/dd/span")).ToList();


                for (int i_name = 0; i_name < name_of_catigories.Count; i_name++)
                {
                    name_p.Add(name_of_catigories[i_name].Text);
                    List<IWebElement> type_categories1 = browzer.FindElements(By.XPath("/html/body/div[1]/div[6]/div/div[1]/div[" + (i_name + 2) + "]/dl")).ToList();
                    for (int i = 0; i < type_categories1.Count; i++)
                    {
                        name_p.Add(type_categories1[i].Text);
                    }
                }







                Regex r = new Regex(@"\r\n");
                //List<string> str = new List<string>(srtu.Split('.'));
                for (int i = 0; i < name_p.Count; i++)
                {
                    name_p[i] = r.Replace(name_p[i], " : ");
                }
                //MessageBox.Show("");
                //*[@id='content']/div[1]/div/div[1]/h1
                browzer.Navigate().GoToUrl("https://vk.com/public178578659");
                vk_adder = browzer.FindElement(By.Id("post_field"));
                vk_adder.SendKeys("Товар в наличии");

                vk_adder.SendKeys(OpenQA.Selenium.Keys.Return); vk_adder.SendKeys(OpenQA.Selenium.Keys.Return);
                vk_adder.SendKeys(name_prods); vk_adder.SendKeys(OpenQA.Selenium.Keys.Return);
                vk_adder.SendKeys(OpenQA.Selenium.Keys.Return);
                vk_adder.SendKeys("Цена : ");
                vk_adder.SendKeys(OpenQA.Selenium.Keys.Return); vk_adder.SendKeys(OpenQA.Selenium.Keys.Return);
                for (int i = 0; i < name_p.Count - 1; i++)
                {
                    vk_adder.SendKeys(name_p[i]);
                    vk_adder.SendKeys(OpenQA.Selenium.Keys.Return);
                    if (name_p[i + 1].Contains(":") != true)
                    {
                        vk_adder.SendKeys(OpenQA.Selenium.Keys.Return);
                    }
                }

            }
            catch
            {
                MessageBox.Show("Ошибка не найдено описание товара");
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        int value=0;
        private void Button11_Click(object sender, EventArgs e)
        {
            StreamReader srts = new StreamReader("txt/Test.txt");
            string srtu = srts.ReadToEnd();
            srts.Close();

            str_in_db = new List<string>(srtu.Split('\r'));            

            Regex r = new Regex(@"\r\n");
            Random rnd = new Random();
           
            //string tempers_cost = "";
       //     string tempers_link = "";
        //   value = rnd.Next(0, str.Count);
            Regex newReg = new Regex(@" : ");
            string s = newReg.Replace(str_in_db[value], "\t");
            List<string> name_and_link = new List<string>(s.Split('\t'));
            IWebElement finder_image_in_yandex;
            browzer.Navigate().GoToUrl("https://yandex.by/images/");
            finder_image_in_yandex = browzer.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[1]/div[2]/form/div[1]/span/span/input"));
            // /html/body/div[1]/div/div/div/div[1]/div[2]/form/div[1]/span/span
            // /html/body/div[1]/div/div/div/div[1]/div[2]/form/div[1]/span/span/input
            // /html/body/div[1]/div[2]/div[1]/div[1]/div/div[1]/div/div/div[1]/div[2]/form/div[1]/span/input
            finder_image_in_yandex.SendKeys(name_and_link[0]);
            finder_image_in_yandex.SendKeys(Keys.Enter);
            //browzer.Navigate().GoToUrl("http://www.cyberforum.ru");



        }

        private void Button12_Click(object sender, EventArgs e)
        {
            IWebElement vk_adder;
            browzer.Navigate().GoToUrl("https://vk.com/public178578659");
            vk_adder = browzer.FindElement(By.Id("post_field"));
            vk_adder.SendKeys("Товар в наличии");
            vk_adder.SendKeys(OpenQA.Selenium.Keys.Return); vk_adder.SendKeys(OpenQA.Selenium.Keys.Return);
             vk_adder.SendKeys("Цена : ");
        }
    }
}


