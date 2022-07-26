using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Leaf.xNet;
using Fizzler;
using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using System.Net;
using System.Drawing;
using System.ComponentModel;
using System.Text.RegularExpressions;
using Keys = OpenQA.Selenium.Keys;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;
using System.Runtime.InteropServices;
using OpenQA.Selenium.Interactions;
//реализовать открытие новой вкладки и там реализовать ввод (РЕАЛИЗОВАЛ)
//noot_books_categoties ПОМЕНЯТЬ ЭТОТ МЕДОТ ЕСЛИ ДРУГУЮ ГРУППУ БУДЕШЬ ДОБОВЛЯТЬ!!!!!!!!



namespace Project_parser
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern int EnumWindows(EnumWindowsProc ewp, int lParam);
        public delegate bool EnumWindowsProc(int hWnd, int lParam);

        [DllImport("user32.dll")]
        static extern bool BringWindowToTop(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern bool BringWindowToTop(HandleRef hWnd);
        Form2 form2 = new Form2();

        IWebDriver browzer;
        public Form1()
        {
            InitializeComponent();

            //  this.TopMost = true;

            // browzer = new OpenQA.Selenium.Chrome.ChromeDriver();
            //  browzer.Manage().Window.Maximize();
            //  auto_login_deal_by();

            OpenQA.Selenium.Chrome.ChromeOptions co = new OpenQA.Selenium.Chrome.ChromeOptions();
           // co.AddArgument(@"user-data-dir=C:\Users\Admin\AppData\Local\Google\Chrome\User Data");
         //   browzer = new OpenQA.Selenium.Chrome.ChromeDriver(co);
            //browzer.Manage().Window.Maximize();


            form2.Show();
            form2.TopMost = true;
            //form2.TopMost = true;
            Size resolution = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size;
            this.Location = new Point(resolution.Width - 380, resolution.Height / 2 - 200);

            form2.Location = new Point(0, 150);
            //CreateMyTopMostForm();
            // this.TopMost = true;

            //Form1.BringWindowToTop();
            //   CreateMyTopMostForm();
            //SetForegroundWindow();

            //..  WindowStyle = "None" AllowsTransparency = "True" Background = "Transparent"  Opacity = "0.7"
            // Form1.
        }

        private void CreateMyTopMostForm()
        {
            // Create lower form to display.
            Form bottomForm = new Form();
            // Display the lower form Maximized to demonstrate effect of TopMost property.
            bottomForm.WindowState = FormWindowState.Maximized;
            // Display the bottom form.
            bottomForm.Show();
            // Create the top most form.
            Form topMostForm = new Form();
            // Set the size of the form larger than the default size.
            topMostForm.Size = new Size(300, 300);
            // Set the position of the top most form to center of screen.
            topMostForm.StartPosition = FormStartPosition.CenterScreen;
            // Display the form as top most form.
            topMostForm.TopMost = true;
            topMostForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            browzer.Quit();
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            browzer.Navigate().GoToUrl("https://yandex.by");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mark_photo = true;
            List<IWebElement> prods = browzer.FindElements(By.CssSelector("#schema-products a")).ToList();
            IWebElement element;
            LogWrite("0 prohod\r\n");
            //    progressBar1.Maximum = prods.Count;
            //удаление не нужной фигни из списка
            try
            {
                for (int i = 0; i < prods.Count; i++)
                {
                    if (prods[i].Text.Contains("предложен") || prods[i].Text.Contains("отзы") || prods[i].Text.Contains("объяв"))
                    {
                        prods.RemoveAt(i);
                        //   progressBar1.Increment(1);
                    }
                    if (prods[i].Text.Contains("бсужд"))
                    {
                        // progressBar1.Increment(1);
                        prods.RemoveAt(i);
                    }
                    //    progressBar1.Increment(1);
                }
                //   MessageBox.Show("max sise " + progressBar1.Maximum.ToString());
                /// progressBar1.Maximum = prods.Count;
                //   MessageBox.Show("max sise " + progressBar1.Maximum.ToString());
                LogWrite("1 prohod\r\n");
                for (int i = 0; i < prods.Count; i++)
                {
                    if (prods[i].Text.Contains("от"))
                    {
                        //         progressBar1.Increment(1);
                        prods.RemoveAt(i);
                    }
                    //  progressBar1.Increment(1);
                }
                //       MessageBox.Show("max sise " + progressBar1.Maximum.ToString());
                LogWrite("2 prohod\r\n");
                for (int i = 0; i < prods.Count; i++)
                {
                    if (prods[i].Text.Contains("от"))
                    {
                        //   progressBar1.Increment(1);
                        prods.RemoveAt(i);
                    }
                    //  progressBar1.Increment(1);
                }
                LogWrite("3 prohod\r\n");

                //   progressBar1.Value = 0;
                LogWrite("1 prohod\r\n");
                for (int i = 0; i < prods.Count; i++)
                {

                    if (prods[i].Text.Contains("ариант"))
                    {
                        //     progressBar1.Increment(1);
                        prods.RemoveAt(i);
                    }
                    //   progressBar1.Increment(1);
                }


                for (int i = 0; i < prods.Count; i++)
                {

                    if (prods[i].Text.Contains(""))
                    {
                        //      progressBar1.Increment(1);
                        prods.RemoveAt(i);
                    }
                    //    progressBar1.Increment(1);
                }
            }
            catch
            {
                MessageBox.Show("Исключение!!!!!!!!!!!!!!!!!");
            }

            StreamReader srts = new StreamReader("prods.txt");
            string srtu = srts.ReadToEnd();
            srts.Close();

            List<string> str = new List<string>(srtu.Split('.'));



            int metka_test;
            Double l = 0;
            Double s;
            LogWrite("начался поиск");
            string s1, s2;
            Double ls = 0;
            Double scc;
            Double y = 0;
            LogWrite("Do pereborki !!!!!!!!!");

            foreach (IWebElement pereb in prods)
            {
                LogWrite(pereb.Text + "\r\n");
            }

            try
            {
                for (int i1 = 0; i1 < prods.Count; i1++)
                {
                    for (int i2 = 0; i2 < prods.Count; i2++)
                    {
                        y = 0;
                        l = 0;
                        s = prods[i1].Text.Length > prods[i2].Text.Length ? prods[i2].Text.Length : prods[i1].Text.Length;
                        metka_test = 0;
                        s1 = prods[i1].Text;
                        s2 = prods[i2].Text;
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
                                if (y >= 0.75)
                                {
                                    prods.RemoveAt(i2);
                                    LogWrite("i2: " + i2 + "   " + s2 + "\r\n");
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



            LogWrite("Posle pereborki !!!!!!!!!");
            foreach (IWebElement pereb in prods)
            {
                LogWrite(pereb.Text + "\r\n");
            }


            string fileName = "prods.txt";
            FileStream aFile = new FileStream(fileName, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(aFile);
            aFile.Seek(0, SeekOrigin.End);
            //     progressBar1.Maximum = prods.Count;
            //       progressBar1.Value = 0;
            foreach (IWebElement pereb in prods)
            {
                sw.WriteLine(pereb.Text + ".");
                // progressBar1.Increment(1);
            }
            sw.Close();
            LogWrite("Завершено и записано в файл!\r\n");
            LogWrite("Переход к след странице");


        }
        string name_prods;
        bool sucses = false;
        private void button5_Click(object sender, EventArgs e)
        {
            File.WriteAllText(@"txt/prods.txt", string.Empty);
        }

        private void LogWrite(string txt)
        {
            textBox1.AppendText(txt + Environment.NewLine);
            textBox1.SelectionStart = textBox1.Text.Length;
            DateTime dateTime = DateTime.Now;
            //   dateTime.
            writer_in_file(@"txt/LOG/"+ dateTime.Day + "." + dateTime.Month + "." + dateTime.Year+".txt", dateTime.ToString()+"   " + txt);
            form2.richtextbox(dateTime.Hour+":"+dateTime.Minute+":"+dateTime.Second+"   " + txt);
           // form2.textBox1_input(i_links.ToString(), str.Count.ToString());
        }


        private void parsing_opisanie_ram_by()//ПАрсинг описания с RAm.by
        {
            sucses = false;
            //  IWebElement prods = browzer.FindElement(By.XPath("//[class='gLFyf gsfi']/div[2]/div/div[1]/div/div[1]/input"));

            //browzer.Navigate().GoToUrl(textBox4.Text);
            //IWebElement cost = browzer.FindElement(By.XPath("/html/body/div[1]/div[3]/div/div[2]/div[2]/div[1]/div/div[1]/div[2]/div[1]/div/input"));
            //MessageBox.Show(cost.Text);
            //mark_photo = false;
            //b-product-edit__label

            // try
            // {

            // if (mark_photo)
            //  {

            name_prods = browzer.FindElement(By.XPath("/html/body/div[1]/div[6]/div/div/div/div/div/h1")).Text;

            LogWrite("Парсинг описания товара");
            IWebElement cost = browzer.FindElement(By.XPath("/html/body/div[1]/div[6]/div/div/div[2]/div[2]/div[1]/div[1]/span"));
            string cost_string = cost.Text;
            bool metka_s = true;
            ///html/body/div[1]/div[6]/div[4]/div/div[2]/div[1]/div[3]/span
            ///
            Regex r = new Regex(@",");
            Regex v = new Regex(@":");
            //   cost_string = r.Replace(cost_string, ".");
            Regex t = new Regex(@" руб.");
            cost_string = t.Replace(cost_string, "");
            double cost_double = Convert.ToDouble(cost_string);
            double raznosti = cost_double / 10;
            cost_double = cost_double + raznosti;


            IWebElement cod_prod = browzer.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div/div/span"));
            Regex c = new Regex(@"-\d\d");
            string cod_prod_string = cod_prod.Text;
            List<IWebElement> name_params = browzer.FindElements(By.XPath("//*[@id='contentTab1']/table[1]/tbody/tr/td")).ToList();
            List<IWebElement> vid_params = browzer.FindElements(By.ClassName("param-block")).ToList();
            //   /html/body/div[1]/div[6]/div/div/div[2]/div[2]/div[1]/div[1]/span
            //IWebElement cost = browzer.FindElement(By.XPath("/html/body/div[1]/div[6]/div/div/div[2]/div[2]/div[1]/div[1]/span"));

            List<string> string_name_params = new List<string>();
            List<string> string_vid_params = new List<string>();

            List<int> count_tables = new List<int>();
            for (int i = 0; i < name_params.Count; i++)
            {
                string_name_params.Add(v.Replace(name_params[i].Text, ""));
                if (name_params[i].Text == "")
                {
                    //  cost_string = t.Replace(cost_string, "");
                    ///string name_params = v.Replace(cost_string, "");
                    metka_s = false;
                    break;
                }
            }
            for (int i = 0; i < vid_params.Count; i++)
            {
                //  vid_params[i].Text;
                string_vid_params.Add(vid_params[i].Text);
                ///string_vid_params.
                //= string.Concat(string_vid_params[i], ":");
            }
            int temp_u = 0;
            int u = 0;
            if (name_params.Count > 0 && metka_s)
            {
                haper();

                int stork_count_table = (string_name_params.Count + string_vid_params.Count) / 2;
                create_the_tabble_ram_by(stork_count_table.ToString());

                List<IWebElement> fotos = browzer.FindElements(By.ClassName("b-uploader-extend__file-input")).ToList();
                //   IWebElement fotos = browzer.FindElement(By.ClassName("b-pseudo-link b-pseudo-link_type_without-line"));
                //b-pseudo-link b-pseudo-link_type_without-line 
                //b-pseudo-link b-pseudo-link_type_without-line"
                //..fotos.Click();
                // File file = new File("src/test/resources/photo.png");
                // ..File photo_gile = new File("0.jpg");
                //   fotos.SendKeys("C:/Users/Fenixoko/Desktop/Project_parser/Project_parser/bin/Debug/prods/0.jpg");
                //  ..     form2.piture_load("C:/Users/Fenixoko/Desktop/Project_parser/Project_parser/bin/Debug/prods/0.jpg");
                for (int f = 0; f < 3; f++)
                {
                    fotos[f].SendKeys("D:/Project_parser/Project_parser/bin/Debug/prods/" + f + ".jpg");
                }
                search_buton();
                vhachalo_table(stork_count_table.ToString());
                IWebElement tr_td = browzer.FindElement(By.XPath("//*[@id='cke_1_contents']/iframe")); // 
                int i = 0;
                bool metka = false;
                ////*[@id="contentTab1"]/table[1]/tbody/tr/td/b
                ///



                for (; i < string_name_params.Count; i++)
                {
                    metka = false;
                    u = temp_u;
                    for (; u < string_vid_params.Count; u++)
                    {

                        //u = temp_u;
                        //if (i+1 < string_name_params.Count)
                        if (i > 0)
                        {
                            // r.Replace(string_name_params[i - 1],"")

                            //   r.Replace(string_name_params[i],""), r.Replace(string_vid_params[u],""))
                            if (String.Compare(r.Replace(string_name_params[i], ""), r.Replace(string_name_params[i - 1], "")) != 0)
                                if (String.Compare(r.Replace(string_name_params[i], ""), v.Replace(string_vid_params[u], "")) == 0)
                                {
                                    //   MessageBox.Show(u.ToString());
                                    u++;
                                    temp_u = u;
                                    metka = true;
                                    // u = string_vid_params.Count;
                                    break;
                                }
                        }
                        else
                        {
                            temp_u = u;
                            metka = true;
                            break;
                        }
                    }
                    if (metka)
                    {
                        // MessageBox.Show(string_name_params[i]);
                        //         MessageBox.Show(string_name_params[i]);
                        IWebElement test = browzer.FindElement(By.XPath("//*[@id='cke_" + (y + 54).ToString() + "']"));
                        test.Click();
                        //MessageBox.Show("stope");
                        test = browzer.FindElement(By.XPath("//*[@id='cke_" + (y + 3).ToString() + "']"));
                        test.Click();
                        //.  MessageBox.Show("нажамкали");
                        tr_td.SendKeys(string_name_params[i]);

                        // LogWrite("\r\n" + string_name_params[i] + ":\r\n");
                        form2.richtextbox(string_name_params[i]);
                        test = browzer.FindElement(By.XPath("//*[@id='cke_" + (y + 3).ToString() + "']"));
                        // MessageBox.Show("отжмакали");
                        test.Click();
                        tr_td.SendKeys(Keys.Tab);
                    }
                    else
                    {
                        tr_td.SendKeys(string_name_params[i]);
                        form2.richtextbox(string_name_params[i]);
                        if (i < (string_name_params.Count - 1))
                            tr_td.SendKeys(Keys.Tab);
                    }
                }




                //  noot_books_categoties(); 

                headphones();///ВЫбираем категорию

                browzer.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                List<IWebElement> inputs = browzer.FindElements(By.ClassName("b-input__field")).ToList();
                /*Название позиции 0 
                   Код/Артикул 1
                   Розничная цена 2*/
                inputs[0].SendKeys(name_prods);
                inputs[1].SendKeys(c.Replace(cod_prod_string, ""));
                // inputs[2].SendKeys(cost_double.ToString());
                cost_string = String.Format("{0:0.00}", cost_double);
                //cost_string = r.Replace(cost_string, ".");
                inputs[2].SendKeys(r.Replace(cost_string, "."));

                IWebElement hashtags = browzer.FindElement(By.CssSelector(".b-tokenbox__input"));
                List<string> hash_tags = new List<string>(name_prods.Split(' '));

                for (i = 0; i < hash_tags.Count; i++)
                {
                    hashtags.SendKeys(hash_tags[i] + ",");
                }

                hashtags.SendKeys("Речица,Гомельская область,Техно-х,Tehno-x,");

                browzer.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
                IWebElement zak = browzer.FindElement(By.XPath("/html/body/div[1]/div[3]/div/div[2]/div[2]/div[1]/div/div[1]/div[8]/div/div/div[3]/div[1]/div[1]/div/span/span"));
                zak.Click();
                browzer.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
                zak = browzer.FindElement(By.XPath("/html/body/div[1]/div[3]/div/div[2]/div[2]/div[1]/div/div[1]/div[8]/div/div/div[3]/div[1]/div[1]/div/ul/li[2]"));
                zak.Click();


                //mark_photo=false


                zak = browzer.FindElement(By.CssSelector(".b-content__header-controls > div:nth-child(1) > div:nth-child(1) > div:nth-child(2) > div:nth-child(1) > span:nth-child(1) > i:nth-child(1)"));
                zak.Click();

                //String.Format("{0:0.00}",x);

                // MessageBox.Show("");
                //  .. MessageBox.Show("create the table");
                // Thread.Sleep(1000);
                LogWrite("create the table");
                DateTime dateTime = DateTime.Now;
                writer_in_file(@"txt/Sucsess"+ dateTime.Day+"_"+dateTime.Month + ".txt", dateTime.ToString()+"   "+ name_prods);
                sucses = true; 
            }
             
            else
            {

                LogWrite("Не достаточно информации \r\n");
            }
            // }
            /*}
            catch
            {
                LogWrite("Ошибка сбора информации переход на следующую страницу");
            }*/
        }



        private void button6_Click(object sender, EventArgs e)
        {
            browzer.Navigate().GoToUrl(textBox2.Text);
            List<IWebElement> prods = browzer.FindElements(By.ClassName("result__name")).ToList();
            List<IWebElement> kod = browzer.FindElements(By.ClassName("g-code")).ToList();

            for (int i = 0; i < prods.Count; i++)
            {
                LogWrite(kod[i].Text + "   " + prods[i].Text + "\r\n");
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            haper();
        }
        private void button9_Click(object sender, EventArgs e)
        {



            browzer.Navigate().GoToUrl("https://www.21vek.by/teapots/ht5001_hitt.html");
            List<IWebElement> prods = browzer.FindElements(By.CssSelector("#fotorama > div.fotorama__wrap.fotorama__wrap_style_fade.fotorama__wrap_mouseout > div > div.fotorama__frame.fotorama__frame_active")).ToList();
            //    MessageBox.Show("");

            for (int i = 0; i < prods.Count; i++)

            {
                LogWrite(prods[i].Text + "\r\n");
            }
        }

        private void DownloadProgressCallback(object sender, System.Net.DownloadProgressChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        /*private void DownloadFileCallback2(object sender, AsyncCompletedEventArgs e)
        {
            //что-то делаете после того как файл загрузился
        }*/

        private void button15_Click(object sender, EventArgs e)
        {
            //   string[] str = new string[100];

            string[] kord = new string[3];
            Regex r = new Regex(@"\r\n");
            StreamReader srts = new StreamReader("test.txt");
            string srt = srts.ReadToEnd();
            srts.Close();
            List<string> str = new List<string>(srt.Split('<'));
            MessageBox.Show("");
            int k = 0;
            for (int h = 0; h < 100; h++)
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
                    }

                    /**
                    if (str[i].Text.Contains("предложен") || str[i].Text.Contains("отзы") || prods[i].Text.Contains("объяв"))
                    // if ( prods[i].Text.Contains("обсуж"))
                    {
                        // LogWrite(prods[i].Text + "\r\n");
                        prods.RemoveAt(i);
                        progressBar1.Increment(1);
                    }
                    if (prods[i].Text.Contains("бсужд"))
                    {
                        progressBar1.Increment(1);
                        // LogWrite(prods[i].Text + "\r\n");
                        prods.RemoveAt(i);
                    }
                    progressBar1.Increment(1);
                    //MessageBox.Show("max sise "+progressBar1.Maximum.ToString()+"\r\n"+"i: "+i);*/
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
            MessageBox.Show("");
        }
        public void haper()
        {
            var date = new HttpRequest();
            string name;
            string response = date.Get(browzer.Url).ToString();
            HtmlAgilityPack.HtmlDocument hap = new HtmlAgilityPack.HtmlDocument();
            File.WriteAllText("Test.txt", response);
            // richTextBox1.Text = response;
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
            for (int i = 0; i < 3; i++)
            {
                string savePath = Path.Combine(directory, i + ".jpg");
                using (WebClient localClient = new WebClient())
                {
                    localClient.DownloadFile(hyper_link[i], savePath);
                }
                savePath = "";
            }
            for (int i = 0; i < 3; i++)
            {

                string savePath = Path.Combine(directory, name_prods + "_" + i + ".jpg");
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

            LogWrite("Saveing foto....");
        }
        bool mark_photo = true;
        private void button16_Click(object sender, EventArgs e)
        {
            string url = "http://matreshka-love.ru/upload/images/albums_photos/sph_163VXA7ycgNs0_12042011.jpg";
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(url, AppDomain.CurrentDomain.BaseDirectory + "test.jpg");
            }
            Console.ReadKey();
        }
        List<IWebElement> prods; IWebElement links_prod; List<string> link_string; string fileName1;
        private void button10_Click(object sender, EventArgs e)//Парсинг с Ram.by
        {
            browzer.Navigate().GoToUrl(textBox2.Text);

            prods = browzer.FindElements(By.XPath("//*[@id='store_products']/div/div/div/div/div/h3/a[1]")).ToList();
            //List<IWebEleme  browzer.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);nt> prods = browzer.FindElements(By.XPath("/div/div/div/div/div/h3/a[1]")).ToList();
            browzer.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement name_for_file = browzer.FindElement(By.XPath("//*[@id='manreplace']"));

            fileName1 = "txt/" + name_for_file.Text;
            ////*[@id="manreplace"]
            remove_copy(prods);
            remove_copy_in_list_and_file(prods, fileName1 + ".txt");
            string temp_url = browzer.Url;
            link_string = new List<string>();
            for (int i = 0; i < prods.Count; i++)
            {
                link_string.Add(prods[i].Text);
            }
            DateTime ib_begin = DateTime.Now;


            // MessageBox.Show(browzer.Url + "\r\n" + browzer.Title);
            LogWrite("Переход на сайт: " + browzer.Url);
            ram_by();



        }
        int o = 0;
        List<String> BeforeTabs;
        int iram = 0;

        private void ram_by()
        {
            try
            {
                //*[@id="store_products"]/div/div/div/div/a
                //  List<IWebElement> prods = browzer.FindElements(By.TagName("h3")).ToList();
                // MessageBox.Show(browzer.Url + "\r\n" + browzer.Title);
                ////*[@id='store_products']/div[2]/div[67]/div/div[3]/div[1]/h3/a

                //   for (int o = 0; o < 3; o++)
                //   {

                int links_pages = 2;
                if (o < 500)
                {
                    for (; iram < prods.Count;)
                    {
                        iram++;
                        textBox3.Clear();
                        textBox3.AppendText(o + "/500");
                        string fileName = fileName1 + ".txt";
                        //string keyOpenNewTab = Keys.Chord(Keys.Control, Keys.Return); 
                        // MessageBox.Show(browzer.Url);
                        string temp_link = link_string[iram];
                        links_prod = browzer.FindElement(By.PartialLinkText(temp_link));
                        BeforeTabs = browzer.WindowHandles.ToList();
                        links_prod.SendKeys(Keys.Control + Keys.Return);
                        //делаем что то - открывается одна новая вкладка
                        //....
                        List<String> AfterTabs = browzer.WindowHandles.ToList();
                        //вкладки до - вкладки после = новая вкладка
                        List<String> OneNewTab = AfterTabs.Except(BeforeTabs).ToList();
                        browzer.SwitchTo().Window(OneNewTab[0]);
                        //  MessageBox.Show(browzer.Title + "\r\n" + browzer.Url);
                        name_prods = link_string[iram];
                        writer_in_file(fileName, link_string[iram]);

                        parsing_opisanie_ram_by();
                        Thread.Sleep(300);
                        browzer.Close();
                        browzer.SwitchTo().Window(BeforeTabs[0]);
                        // MessageBox.Show("all");
                        // browzer.Navigate().GoToUrl(temp_url);     
                        o++;

                    }
                    browzer.Navigate().GoToUrl("https://ram.by/notebooks.html?page=" + links_pages);
                    links_pages++;
                    LogWrite("Переход на следущую страницу RAM");

                }

                // }

                DateTime in_end = DateTime.Now;
                //DateTime delta = in_end - in_end;
                //       MessageBox.Show((in_end.Minute - ib_begin.Minute).ToString() + ":" + (in_end.Second - ib_begin.Second).ToString());
                //            List<string> str = new List<string>(prods[0].Text.Split('r'));

            }
            catch
            {
                o++; iram++;
                browzer.Close();
                browzer.SwitchTo().Window(BeforeTabs[0]);
                LogWrite("Ошибка при открытии сайта");
                ram_by();

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
            sw.WriteLine(stoka);//"+"."+"
            //  richTextBox1.AppendText(stoka + "\n\r");
            //   progressBar1.Increment(1);
            //    }
            sw.Close();
            // LogWrite("Записан в файл объект: " + stoka + "\r\n");
            // LogWrite("Переход к след странице \n\r");
        }

        /*     private void button11_Click(object sender, EventArgs e)//
             {
                 browzer.Navigate().GoToUrl("https://ram.by/videokarta-palit-geforce-gtx1050ti-dual-ne5105t018g1-1071d-4gb.html");
                 List<IWebElement> prods = browzer.FindElements(By.Id("contentTab1")).ToList();
                 string temp = prods[0].Text;

                 List<string> str = new List<string>(temp.Split('r'));
                 MessageBox.Show("");
             }
             */
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
                for (int i1 = str.Count - 1; i1 >= 0; i1--)
                {
                    for (int i2 = str.Count - 1; i2 >= 0; i2--)
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
                                    i1--;
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
                MessageBox.Show(" private void remove_copy(List<IWebElement> prod)//удаление повторяющихся элементов");
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

        private void button1_Click(object sender, EventArgs e)
        {
            Regex r = new Regex(@",");

            /*
            browzer.Navigate().GoToUrl(textBox4.Text);
              */

            //string cost_s = cost.Text;

            //cost_s = r.Replace(cost_s, ".");
            // /html/body/div[1]/div[3]/div/div[2]/div[2]/div[1]/div/div[1]/div[8]/div/div/div[1]/div[1]/div[1]/div/input


            //cost = browzer.FindElement(By.XPath("/html/body/div[1]/div[3]/div/div[2]/div[2]/div[1]/div/div[1]/div[8]/div/div/div[1]/div[1]/div[1]/div/input"));
            //cost = browzer.FindElement(By.ClassName("b-input-with-dd__input"));
            //
            //  cost = browzer.FindElement(By.XPath("/html/body/div[1]/div[3]/div/div[2]/div[2]/div[1]/div/div[1]/div[8]/div/div/div[1]/div[1]/div[1]/div"));

            // IWebElement cost = browzer.FindElement(By.XPath("/html/body/div[1]/div[3]/div/div[2]/div[2]/div[1]/div/div[1]/div[2]/div[1]/div/input"));
            //                            FindElements

            // IWebElement COST = browzer.FindElement(By.XPath(""));

            //cost.SendKeys("11");


            browzer.Navigate().GoToUrl("https://www.google.by");

        }

        private void button7_Click(object sender, EventArgs e) //ТЕстирую ввод на Deal.by
        {
            //create_the_tabble_ram_by();
            search_buton();
            //vhachalo_table();
        }
        int i = 0;

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

        private void Input_deal_by()///
        {
            List<IWebElement> inputs = browzer.FindElements(By.ClassName("b-input__field")).ToList();

            /*Название позиции 0 
                Код/Артикул 1
                Розничная цена 2*/


        }

        private void button11_Click(object sender, EventArgs e)
        {
            //browzer.Navigate().GoToUrl("https://my.deal.by/cms/product/create");
            Input_deal_by();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            SendKeys.Send("ss");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            IWebElement tr_td = browzer.FindElement(By.XPath("//*[@id='cke_1_contents']/iframe"));
            //List<IWebElement> tr_td = browzer.FindElements(By.TagName("td")).ToList();
            //  try
            // {
            tr_td.SendKeys("asdadiuhqwdu8i0qwheuqwehjqqwe");

        }

        private void button14_Click(object sender, EventArgs e)
        {
            IWebElement tr_td = browzer.FindElement(By.XPath("//*[@id='cke_1_contents']/iframe"));
            //List<IWebElement> tr_td = browzer.FindElements(By.TagName("td")).ToList();
            //  try
            // {
            tr_td.Click();

        }

        private void button17_Click(object sender, EventArgs e)
        {
            IWebElement tr_td = browzer.FindElement(By.XPath("//*[@id='cke_1_contents']/iframe"));
            //List<IWebElement> tr_td = browzer.FindElements(By.TagName("td")).ToList();
            tr_td.SendKeys(Keys.Tab);

        }

        private void button18_Click(object sender, EventArgs e)
        {
            SendKeys.Send("ss");


        }

        private void button19_Click(object sender, EventArgs e)
        {

            IWebElement tr_td = browzer.FindElement(By.XPath("//*[@id='cke_1_contents']/iframe"));

            tr_td.SendKeys(Keys.Up);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            IWebElement test = browzer.FindElement(By.XPath("//*[@id='cke_" + y.ToString() + "']"));
            test.Click();

        }
        int y;
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
                    // LogWrite("перебор элемента №: " + y + "\r\n");
                }
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            int innach;
            IWebElement tr_td = browzer.FindElement(By.XPath("//*[@id='cke_1_contents']/iframe"));
            // if (Convert.ToInt32(textBox7.Text) <= 7)
            {
                innach = 6;
            }
            //  else
            {
                //    innach = Convert.ToInt32(textBox7.Text) * 2 - 7;
            }
            tr_td.SendKeys("ss");
            tr_td.Click();
            for (int i = 0; i < innach; i++)
            {
                tr_td.SendKeys(i.ToString());
                tr_td.SendKeys(Keys.Up);
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

        private void button23_Click(object sender, EventArgs e)
        {
            browzer.Navigate().GoToUrl("https://my.deal.by/cms/product/create");

        }


        private void button11_Click_1(object sender, EventArgs e)
        {
            
            this.TopMost = true;
            button11.Text = "ss";
        }



        private void noot_books_categoties()///Выбор категорий ноутбуки на сайте Deal.by //Техника и электроника/Компьютерная техника и ПО/	Ноутбуки и нетбуки
        {
           //   browzer.Navigate().GoToUrl("https://my.deal.by/cms/product/create");
            browzer.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            IWebElement tovar_categories = browzer.FindElement(By.XPath("/html/body/div[1]/div[3]/div/div[2]/div[2]/div[2]/div/div[4]/div[2]/div/div[1]/div"));
            tovar_categories.Click();
            //html body div.b-cms div div div.b-content div div.b-section.b-section_type_margin-20.b-product-edit div.b-product-edit__wrapper div.b-product-edit__table div.b-product-edit__field div.b-recommended-cat div.b-input div div.b-smart-selector.b-smart-selector_type_dd div div.b-smart-selector__body.b-smart-selector__body_max-height_520.b-smart-selector__body_min-height_250 ul.b-smart-selector__list li.b-smart-selector__item div.b-smart-selector__text-wrapper div ul.b-smart-selector__list.b-smart-selector__list_type_child li.b-smart-selector__item div.b-smart-selector__text-wrapper span.b-smart-selector__dropdown-caption.b-pseudo-link span.b-smart-selector__text span
            //  List<IWebElement> tovar_categories1 = browzer.FindElements(By.XPath("html body div.b-cms div div div.b-content div div.b-section.b-section_type_margin-20.b-product-edit div.b-product-edit__wrapper div.b-product-edit__table div.b-product-edit__field div.b-recommended-cat div.b-input div div.b-smart-selector.b-smart-selector_type_dd div div.b-smart-selector__body.b-smart-selector__body_max-height_520.b-smart-selector__body_min-height_250 ul.b-smart-selector__list li.b-smart-selector__item div.b-smart-selector__text-wrapper div ul.b-smart-selector__list.b-smart-selector__list_type_child li.b-smart-selector__item div.b-smart-selector__text-wrapper span.b-smart-selector__dropdown-caption.b-pseudo-link span.b-smart-selector__text span")).ToList();
            //li.b-smart-selector__item:nth-child(4) > div:nth-child(2) > span:nth-child(1) > span:nth-child(2) > span:nth-child(1)
            tovar_categories = browzer.FindElement(By.CssSelector("li.b-smart-selector__item:nth-child(22) > div:nth-child(2) > span:nth-child(1) > span:nth-child(2) > span:nth-child(1)"));  //Техника и электроника
            tovar_categories.Click();

            tovar_categories = browzer.FindElement(By.CssSelector("li.b-smart-selector__item:nth-child(22) > div:nth-child(2) > div:nth-child(3) > ul:nth-child(1) > li:nth-child(2) > div:nth-child(2) > span:nth-child(1) > span:nth-child(2) > span:nth-child(1)"));//Компьютерная техника и ПО
            tovar_categories.Click();

            tovar_categories = browzer.FindElement(By.CssSelector("li.b-smart-selector__item:nth-child(22) > div:nth-child(2) > div:nth-child(3) > ul:nth-child(1) > li:nth-child(2) > div:nth-child(2) > div:nth-child(3) > ul:nth-child(1) > li:nth-child(2) > div:nth-child(3) > span:nth-child(1) > span:nth-child(2) > span:nth-child(1)"));//	Ноутбуки и нетбуки
            tovar_categories.Click();


            tovar_categories = browzer.FindElement(By.CssSelector("body > div.b-cms > div:nth-child(3) > div > div.b-content > div:nth-child(2) > div:nth-child(2) > div > div:nth-child(4) > div.b-product-edit__field > div > div.b-input > div > div.b-smart-selector.b-smart-selector_type_dd > div:nth-child(2) > div:nth-child(2) > div.b-smart-selector__footer > div"));//	Ноутбуки и нетбуки
            tovar_categories.Click();

            //body > div.b-cms > div:nth-child(3) > div > div.b-content > div:nth-child(2) > div:nth-child(2) > div > div:nth-child(4) > div.b-product-edit__field > div > div.b-input > div > div.b-smart-selector.b-smart-selector_type_dd > div:nth-child(2) > div:nth-child(2) > div.b-smart-selector__footer > div
            ///







            //  MessageBox.Show("1");


            // List <IWebElement> element = browzer.FindElements(By.CssSelector("")).ToList();//Компьютерная техника и ПО

            List<IWebElement> element = browzer.FindElements(By.ClassName("b-input")).ToList();//Компьютерная техника и ПО

            Actions action = new Actions(browzer);
            action.MoveToElement(element[0]).Click().Perform();

            element[4].Click();
            //    MessageBox.Show("2");

            //  tovar_categories = browzer.FindElement(By.XPath("/html/body/div[1]/div[3]/div/div[2]/div[2]/div[2]/div/div[2]/div[2]/div/div/div/div"));//Компьютерная техника и ПО
            // tovar_categories.Click();

            tovar_categories = browzer.FindElement(By.CssSelector("body > div.b-cms > div:nth-child(3) > div > div.b-content > div:nth-child(2) > div:nth-child(2) > div > div:nth-child(2) > div.b-product-edit__field > div > div > div > div.b-smart-selector.b-smart-selector_type_dd > div:nth-child(2) > div.b-smart-selector__body.b-smart-selector__body_max-height_520.b-smart-selector__body_min-height_250 > ul > li:nth-child(5) > div.b-smart-selector__text-wrapper > span:nth-child(1) > span > span"));//	Ноутбуки и нетбуки
            tovar_categories.Click();
            //   MessageBox.Show("2");


        }

        private void tv_categoties()///Выбор категорий ноутбуки на сайте Deal.by //Техника и электроника/Компьютерная техника и ПО/	Ноутбуки и нетбуки
        {
            browzer.Navigate().GoToUrl("https://my.deal.by/cms/product/create");
            browzer.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            IWebElement tovar_categories = browzer.FindElement(By.XPath("/html/body/div[1]/div[3]/div/div[2]/div[2]/div[2]/div/div[4]/div[2]/div/div[1]/div"));
            tovar_categories.Click();
            //html body div.b-cms div div div.b-content div div.b-section.b-section_type_margin-20.b-product-edit div.b-product-edit__wrapper div.b-product-edit__table div.b-product-edit__field div.b-recommended-cat div.b-input div div.b-smart-selector.b-smart-selector_type_dd div div.b-smart-selector__body.b-smart-selector__body_max-height_520.b-smart-selector__body_min-height_250 ul.b-smart-selector__list li.b-smart-selector__item div.b-smart-selector__text-wrapper div ul.b-smart-selector__list.b-smart-selector__list_type_child li.b-smart-selector__item div.b-smart-selector__text-wrapper span.b-smart-selector__dropdown-caption.b-pseudo-link span.b-smart-selector__text span
            //  List<IWebElement> tovar_categories1 = browzer.FindElements(By.XPath("html body div.b-cms div div div.b-content div div.b-section.b-section_type_margin-20.b-product-edit div.b-product-edit__wrapper div.b-product-edit__table div.b-product-edit__field div.b-recommended-cat div.b-input div div.b-smart-selector.b-smart-selector_type_dd div div.b-smart-selector__body.b-smart-selector__body_max-height_520.b-smart-selector__body_min-height_250 ul.b-smart-selector__list li.b-smart-selector__item div.b-smart-selector__text-wrapper div ul.b-smart-selector__list.b-smart-selector__list_type_child li.b-smart-selector__item div.b-smart-selector__text-wrapper span.b-smart-selector__dropdown-caption.b-pseudo-link span.b-smart-selector__text span")).ToList();
            //li.b-smart-selector__item:nth-child(4) > div:nth-child(2) > span:nth-child(1) > span:nth-child(2) > span:nth-child(1)
            tovar_categories = browzer.FindElement(By.CssSelector("li.b-smart-selector__item:nth-child(22) > div:nth-child(2) > span:nth-child(1) > span:nth-child(2) > span:nth-child(1)"));  //Техника и электроника
            tovar_categories.Click();

            tovar_categories = browzer.FindElement(By.CssSelector("body > div.b-cms > div:nth-child(3) > div > div.b-content > div:nth-child(2) > div:nth-child(2) > div > div:nth-child(4) > div.b-product-edit__field > div > div.b-input > div > div.b-smart-selector.b-smart-selector_type_dd > div:nth-child(2) > div.b-smart-selector__body.b-smart-selector__body_max-height_520.b-smart-selector__body_min-height_250 > ul > li > div.b-smart-selector__text-wrapper > div > ul > li:nth-child(22) > div.b-smart-selector__text-wrapper > div > ul > li:nth-child(3) > div.b-smart-selector__text-wrapper > span.b-smart-selector__dropdown-caption.b-pseudo-link > span > span"));//Компьютерная техника и ПО
            tovar_categories.Click();

            tovar_categories = browzer.FindElement(By.CssSelector("body > div.b-cms > div:nth-child(3) > div > div.b-content > div:nth-child(2) > div:nth-child(2) > div > div:nth-child(4) > div.b-product-edit__field > div > div.b-input > div > div.b-smart-selector.b-smart-selector_type_dd > div:nth-child(2) > div.b-smart-selector__body.b-smart-selector__body_max-height_520.b-smart-selector__body_min-height_250 > ul > li > div.b-smart-selector__text-wrapper > div > ul > li:nth-child(22) > div.b-smart-selector__text-wrapper > div > ul > li:nth-child(3) > div.b-smart-selector__text-wrapper > div > ul > li:nth-child(7) > div.b-smart-selector__text-wrapper > span:nth-child(1) > span > span"));//	Ноутбуки и нетбуки
            tovar_categories.Click();


            // tovar_categories = browzer.FindElement(By.CssSelector("body > div.b-cms > div:nth-child(3) > div > div.b-content > div:nth-child(2) > div:nth-child(2) > div > div:nth-child(4) > div.b-product-edit__field > div > div.b-input > div > div.b-smart-selector.b-smart-selector_type_dd > div:nth-child(2) > div:nth-child(2) > div.b-smart-selector__footer > div"));//	Ноутбуки и нетбуки
            //  tovar_categories.Click();

            //body > div.b-cms > div:nth-child(3) > div > div.b-content > div:nth-child(2) > div:nth-child(2) > div > div:nth-child(4) > div.b-product-edit__field > div > div.b-input > div > div.b-smart-selector.b-smart-selector_type_dd > div:nth-child(2) > div:nth-child(2) > div.b-smart-selector__footer > div
            ///

            List<IWebElement> element = browzer.FindElements(By.ClassName("b-input")).ToList();//Компьютерная техника и ПО

            Actions action = new Actions(browzer);
            action.MoveToElement(element[0]).Click().Perform();

            element[4].Click();
            //    MessageBox.Show("2");
            tovar_categories = browzer.FindElement(By.CssSelector("body > div.b-cms > div:nth-child(3) > div > div.b-content > div:nth-child(2) > div:nth-child(2) > div > div:nth-child(2) > div.b-product-edit__field > div > div > div > div.b-smart-selector.b-smart-selector_type_dd > div:nth-child(2) > div.b-smart-selector__body.b-smart-selector__body_max-height_520.b-smart-selector__body_min-height_250 > ul > li:nth-child(6) > div.b-smart-selector__text-wrapper > span:nth-child(1) > span > span"));//	Ноутбуки и нетбуки
            tovar_categories.Click();
            //   MessageBox.Show("2");
        }



        private void button13_Click_1(object sender, EventArgs e)
        {
            form2.richtextbox("ssss");
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            browzer.Navigate().GoToUrl(textBox2.Text);
            IWebElement hashtags = browzer.FindElement(By.CssSelector(".b-tokenbox__input"));
            // tovar_categories.SendKeys("suk,jan,kolo");


        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            // form2.T
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            browzer.Navigate().GoToUrl("https://my.deal.by/cms/product/create");
            noot_books_categoties(); ///ВЫбираем категорию
        }

        private void button1_Click_4(object sender, EventArgs e)
        {
            browzer.Navigate().GoToUrl(textBox2.Text);
            tempers_getlink = 0;
            get_links();


        }
        int tempers_getlink = 0;
        int links_pages = 2;
        public void get_links()
        {
            IWebElement name_for_file = browzer.FindElement(By.XPath("//*[@id='manreplace']"));
            fileName1 = "txt/" + name_for_file.Text + ".txt";
            string fileName_link = "txt/" + name_for_file.Text + "Link.txt";
            prods = browzer.FindElements(By.XPath("//*[@id='store_products']/div/div/div/div/div/h3/a[1]")).ToList();
            remove_copy(prods);
            //  remove_copy_in_list_and_file(prods, fileName1);

            for (int i = 0; i < prods.Count; i++)
            {
                writer_in_file(fileName_link, prods[i].GetAttribute("href"));
                tempers_getlink++;
                writer_in_file(fileName1, prods[i].Text);
            }
            //   MessageBox.Show(prods[0].GetAttribute("href"));
            browzer.Navigate().GoToUrl(textBox2.Text + "?page=" + links_pages);
            links_pages++;
            textBox3.Clear();
            textBox3.AppendText(tempers_getlink + "/1000");
            while (tempers_getlink < 800)
            {
                get_links();
            }

          

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            ram_by("txt/НаушникиLink.txt");
        }

        private void ram_by(string strs)
        {
            StreamReader srts = new StreamReader(strs);
            string srtu = srts.ReadToEnd();
            srts.Close();
            List<string> str = new List<string>(srtu.Split(new string[] { ".\r\n" }, StringSplitOptions.RemoveEmptyEntries));
            ///Name = Name.Split(new string[] { " (" }, StringSplitOptions.RemoveEmptyEntries)[0];

            ///   try
            ///    {
            //*[@id="store_products"]/div/div/div/div/a
            //  List<IWebElement> prods = browzer.FindElements(By.TagName("h3")).ToList();
            // MessageBox.Show(browzer.Url + "\r\n" + browzer.Title);
            ////*[@id='store_products']/div[2]/div[67]/div/div[3]/div[1]/h3/a
            //   for (int o = 0; o < 3; o++)
            //   {
            for (int i_links = 0; i_links < str.Count; i_links++)
            {
                browzer.Navigate().GoToUrl(str[i]);
                form2.textBox1_input(i_links.ToString(), str.Count.ToString());
                //  string fileName = fileName1 + ".txt";
                //string keyOpenNewTab = Keys.Chord(Keys.Control, Keys.Return); 
                // MessageBox.Show(browzer.Url);
                //  string temp_link = link_string[iram];
                try
                {
                    parsing_opisanie_ram_by();
                    str.RemoveAt(i);
                    File.WriteAllText(strs, string.Empty);
                    for (int i = 0; i < str.Count; i++)
                    {
                        writer_in_file(strs, str[i]);
                        //tempers_getlink++;
                        //   writer_in_file(fileName1, prods[i].Text);
                    }
                }
                catch
                {
                    str.RemoveAt(i);
                    File.WriteAllText(strs, string.Empty);
                    for (int i = 0; i < str.Count; i++)
                    {
                        writer_in_file(strs, str[i]);
                        //tempers_getlink++;
                        //   writer_in_file(fileName1, prods[i].Text);
                    }
                    LogWrite("ERRORR parsing_opisanie_ram_by");
                }
              
                Thread.Sleep(300);
                /// browzer.Close();
                // browzer.SwitchTo().Window(BeforeTabs[0]);
                // MessageBox.Show("all");
                //// // browzer.Navigate().GoToUrl(temp_url);     
                //o++;

            }
            LogWrite("Переход на следущую страницу RAM");
            // }

            DateTime in_end = DateTime.Now;
            //DateTime delta = in_end - in_end;
            //       MessageBox.Show((in_end.Minute - ib_begin.Minute).ToString() + ":" + (in_end.Second - ib_begin.Second).ToString());
            //            List<string> str = new List<string>(prods[0].Text.Split('r'));

            /*    }
                catch
                {
                    LogWrite("Ошибка при открытии сайта");
                    ram_by("txt/НоутбукиLink.txt");
                }*/

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            headphones();
        }


        private void headphones()///Выбор категорий ноутбуки на сайте Deal.by //Техника и электроника/Компьютерная техника и ПО/	Ноутбуки и нетбуки
        {
          //  browzer.Navigate().GoToUrl("https://my.deal.by/cms/product/create");
            browzer.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            IWebElement tovar_categories = browzer.FindElement(By.XPath("/html/body/div[1]/div[3]/div/div[2]/div[2]/div[2]/div/div[4]/div[2]/div/div[1]/div"));
            tovar_categories.Click();
            //html body div.b-cms div div div.b-content div div.b-section.b-section_type_margin-20.b-product-edit div.b-product-edit__wrapper div.b-product-edit__table div.b-product-edit__field div.b-recommended-cat div.b-input div div.b-smart-selector.b-smart-selector_type_dd div div.b-smart-selector__body.b-smart-selector__body_max-height_520.b-smart-selector__body_min-height_250 ul.b-smart-selector__list li.b-smart-selector__item div.b-smart-selector__text-wrapper div ul.b-smart-selector__list.b-smart-selector__list_type_child li.b-smart-selector__item div.b-smart-selector__text-wrapper span.b-smart-selector__dropdown-caption.b-pseudo-link span.b-smart-selector__text span
            //  List<IWebElement> tovar_categories1 = browzer.FindElements(By.XPath("html body div.b-cms div div div.b-content div div.b-section.b-section_type_margin-20.b-product-edit div.b-product-edit__wrapper div.b-product-edit__table div.b-product-edit__field div.b-recommended-cat div.b-input div div.b-smart-selector.b-smart-selector_type_dd div div.b-smart-selector__body.b-smart-selector__body_max-height_520.b-smart-selector__body_min-height_250 ul.b-smart-selector__list li.b-smart-selector__item div.b-smart-selector__text-wrapper div ul.b-smart-selector__list.b-smart-selector__list_type_child li.b-smart-selector__item div.b-smart-selector__text-wrapper span.b-smart-selector__dropdown-caption.b-pseudo-link span.b-smart-selector__text span")).ToList();
            //li.b-smart-selector__item:nth-child(4) > div:nth-child(2) > span:nth-child(1) > span:nth-child(2) > span:nth-child(1)
            tovar_categories = browzer.FindElement(By.CssSelector("li.b-smart-selector__item:nth-child(22) > div:nth-child(2) > span:nth-child(1) > span:nth-child(2) > span:nth-child(1)"));  //Техника и электроника
            tovar_categories.Click();

            tovar_categories = browzer.FindElement(By.CssSelector("body > div.b-cms > div:nth-child(3) > div > div.b-content > div:nth-child(2) > div:nth-child(2) > div > div:nth-child(4) > div.b-product-edit__field > div > div.b-input > div > div.b-smart-selector.b-smart-selector_type_dd > div:nth-child(2) > div.b-smart-selector__body.b-smart-selector__body_max-height_520.b-smart-selector__body_min-height_250 > ul > li > div.b-smart-selector__text-wrapper > div > ul > li:nth-child(22) > div.b-smart-selector__text-wrapper > div > ul > li:nth-child(5) > div.b-smart-selector__text-wrapper > span.b-smart-selector__dropdown-caption.b-pseudo-link > span > span"));//Компьютерная техника и ПО
            tovar_categories.Click();

            tovar_categories = browzer.FindElement(By.CssSelector("body > div.b-cms > div:nth-child(3) > div > div.b-content > div:nth-child(2) > div:nth-child(2) > div > div:nth-child(4) > div.b-product-edit__field > div > div.b-input > div > div.b-smart-selector.b-smart-selector_type_dd > div:nth-child(2) > div.b-smart-selector__body.b-smart-selector__body_max-height_520.b-smart-selector__body_min-height_250 > ul > li > div.b-smart-selector__text-wrapper > div > ul > li:nth-child(22) > div.b-smart-selector__text-wrapper > div > ul > li:nth-child(5) > div.b-smart-selector__text-wrapper > div > ul > li:nth-child(6) > div.b-smart-selector__text-wrapper > span:nth-child(1) > span > span"));//Компьютерная техника и ПО
            tovar_categories.Click();


            // tovar_categories = browzer.FindElement(By.CssSelector("body > div.b-cms > div:nth-child(3) > div > div.b-content > div:nth-child(2) > div:nth-child(2) > div > div:nth-child(4) > div.b-product-edit__field > div > div.b-input > div > div.b-smart-selector.b-smart-selector_type_dd > div:nth-child(2) > div:nth-child(2) > div.b-smart-selector__footer > div"));//	Ноутбуки и нетбуки
            //  tovar_categories.Click();

            //body > div.b-cms > div:nth-child(3) > div > div.b-content > div:nth-child(2) > div:nth-child(2) > div > div:nth-child(4) > div.b-product-edit__field > div > div.b-input > div > div.b-smart-selector.b-smart-selector_type_dd > div:nth-child(2) > div:nth-child(2) > div.b-smart-selector__footer > div
            ///

            List<IWebElement> element = browzer.FindElements(By.ClassName("b-input")).ToList();//Компьютерная техника и ПО

            Actions action = new Actions(browzer);
            action.MoveToElement(element[0]).Click().Perform();

            element[4].Click();
            //    MessageBox.Show("2");
      /// ...     tovar_categories = browzer.FindElement(By.PartialLinkText("Мультимедиа"));//	Ноутбуки и нетбуки
          ///  tovar_categories.Click();

            tovar_categories = browzer.FindElement(By.CssSelector("body > div.b-cms > div:nth-child(3) > div > div.b-content > div:nth-child(2) > div:nth-child(2) > div > div:nth-child(2) > div.b-product-edit__field > div > div > div > div.b-smart-selector.b-smart-selector_type_dd > div:nth-child(2) > div.b-smart-selector__body.b-smart-selector__body_max-height_520.b-smart-selector__body_min-height_250 > ul > li:nth-child(2) > div.b-smart-selector__text-wrapper > span:nth-child(1) > span > span"));//	Ноутбуки и нетбуки
            tovar_categories.Click();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            browzer.Navigate().GoToUrl(textBox2.Text);
            ////*[@id]/div/div/div/p
            List<IWebElement> questions = browzer.FindElements(By.XPath("//*[@id]/div/div/div/p")).ToList();           
            List<IWebElement> asks = browzer.FindElements(By.XPath("//*[@id]/div[2]/div[2]/div/div")).ToList();
           /* for (int i = 0; i < questions.Count; i++)
            {
                if (questions[i].Text != " ")
                {
                    questions.RemoveAt(i);
                }
            }
            for (int i = 0; i < asks.Count; i++)
            {
                if (asks[i].Text != " ")
                {
                    asks.RemoveAt(i);
                }
            }*/
            
            string s = "aaa" + (1 > 0 ? "bbb" : "ccc");
            int counter = questions.Count < asks.Count ? questions.Count : asks.Count;

            try
            {
                for (int i = 0; i < counter; i++)
                {
                    if (questions[i].Text != " ")
                    {
                        LogWrite(questions[i].Text);
                        LogWrite(asks[i].Text);
                        writer_in_file(@"txt/" + textBox4.Text + ".txt", questions[i].Text);
                        writer_in_file(@"txt/" + textBox4.Text + ".txt", asks[i].Text + "\n");
                    }
                    else
                    {
                        questions.RemoveAt(i);
                        i--;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка НЕТ это костыль=)");
            }
            // MessageBox.Show("");
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            browzer.Quit();
            Close();
        }
    }


}