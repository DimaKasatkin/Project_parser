using OpenQA.Selenium;
using Simple1C;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VKBot
{
    public partial class Form2 : Form
    {
        IWebDriver browzer;

        public Form2()
        {
            InitializeComponent();
            reader_file_db();
          
        }
        List<string> str;
        List<string> str_in_db;
        public static MatchCollection matches_2;
        private void button1_Click(object sender, EventArgs e)
        {
            
            StreamReader srts = new StreamReader("prods.txt");
            string srtu = srts.ReadToEnd();
            srts.Close();

            str = new List<string>(srtu.Split('\t'));



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
                if (str[i].CompareTo(str[i-1])==0)
                    str.RemoveAt(i);
            }
            write_file_in_rich_box();
            LogWrite("Файл загружен");

            
            //MessageBox.Show("");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (var i = str.Count - 1; i > -1; i--)
            {
                if (str[i].Contains(textBox1.Text))
                {
                    LogWrite("Удален элемент #"+i);
                    str.RemoveAt(i);
                    ///  MessageBox.Show("rem");
                }
            }
            write_file_in_rich_box();
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

        private void button3_Click(object sender, EventArgs e)
        {
            for(int i=0;i<str.Count;i++)
            {
                writer_in_file("txt/prods_temp_find.txt", str[i]+"+");
            }
            LogWrite("Файл сохранен");
        }

        private void LogWrite(string txt)
        {
            richTextBox2.AppendText(txt + Environment.NewLine);
            richTextBox2.SelectionStart = richTextBox2.Text.Length;
        }

        private void write_file_in_rich_box()
        {

            richTextBox1.Clear();
            for (int i = 0; i < str.Count; i++)
            {
                richTextBox1.AppendText(i.ToString() + " : " + str[i] + Environment.NewLine);
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                //write_file_in_rich_box();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            File.WriteAllText(@"txt/links.txt", string.Empty);
            File.WriteAllText(@"txt/products_and_cost.txt", string.Empty);


            //  StreamReader srts = new StreamReader("txt/Test.txt");

            //prods_21vek_find

            StreamReader srts = new StreamReader("txt/prods_21vek_find.txt");
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
             Random rnd = new Random();
            int value;
            for (int o = 0; o < 8; o++)
            {
                value = rnd.Next(0, str.Count);
                Regex newReg = new Regex(@" : ");
                string s = newReg.Replace(str[value], "\t");
                List<string> name_and_link = new List<string>(s.Split('\t'));

                for(int y=0;y< str_in_db.Count;y++)
                {
                    //   if (str_in_db[y].CompareTo(name_and_link[0]) == 0)
                    if (name_and_link[0].CompareTo(str_in_db[y]) == 0)
                    {
                        // MessageBox.Show(str_in_db[y]+"  :: "+y+" : \r\n :0 "+ name_and_link[0]);
                        // MessageBox.Show(str_in_db[y + 3]);


                        writer_in_file("txt/links.txt", name_and_link[0]+" : "+ name_and_link[1]);
                        writer_in_file("txt/products_and_cost.txt", str_in_db[y]+"           "+ str_in_db[y + 3]);
                        //y = str_in_db.Count; 
                        str.RemoveAt(value);
                    }
                }
               
            //    MessageBox.Show(name_and_link[0]+ "\r\n"+name_and_link[1]);
            }

            // File.WriteAllText(@"txt/prods_21vek_find.txt", string.Empty);

            //  File.WriteAllText(@"txt/prods_21vek_find.txt", string.Empty);

            File.WriteAllText(@"txt/prods_21vek_find.txt", string.Empty);
            for (int i = 0; i < str.Count; i++)
            {
                writer_in_file("txt/prods_21vek_find.txt", str[i]);
            }
            LogWrite("Файл сохранен");



    
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

        private void button5_Click(object sender, EventArgs e)
        {
            OpenQA.Selenium.Chrome.ChromeOptions co = new OpenQA.Selenium.Chrome.ChromeOptions();
            co.AddArgument(@"user-data-dir=C:\Users\Admin\AppData\Local\Google\Chrome\User Data");
            browzer = new OpenQA.Selenium.Chrome.ChromeDriver(co);
            browzer.Manage().Window.Maximize();

        }
    }
}

