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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_down
{
    public partial class Form1 : Form
    {
        //*Парсим*теги*изображений
        private static readonly Regex ImgRegex = new Regex(@"\<img.+?src=\""(?<imgsrc>.+?)\"".+?\>",
            RegexOptions.ExplicitCapture | RegexOptions.Compiled);


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var urls = new[] {
                "http://www.yandex.ru",
                "http://www.mail.ru",
                "http://pn.com.ua",
            };

            // Загружаем параллельно все сайты
            Parallel.ForEach(urls, DownloadFiles);

            Console.WriteLine("Загрузка закончена");
            Console.ReadKey();
        }
        private static void DownloadFiles(string site)
        {
            string data;
            Console.WriteLine(site);
            Console.WriteLine("Загрузка страницы");
            using (WebClient client = new WebClient())
            {
                using (Stream stream = client.OpenRead(site))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        data = reader.ReadToEnd();
                    }
                }
            }

            Console.WriteLine("Загрузка картинок");

            // Создаём директорию под картинки
            string directory = new Uri(site).Host;
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            ImgRegex.Matches(data)
                .Cast<Match>()
                //*Данный*из*группы*регулярного*выражения
                .Select(m => m.Groups["imgsrc"].Value.Trim())
                // Удаляем повторяющиеся
                .Distinct()
                //*Добавляем*название*сайта,*если*ссылки*относительные
                .Select(url => url.Contains("http://") ? url : (site + url))
                //*Получаем*название*картинки
                .Select(url => new { url, name = url.Split(new[] { '/' }).Last() })
                //*Проверяем*его
                .Where(arg => Regex.IsMatch(arg.name, @"[^\s\/]\.(jpg|png|gif|bmp)\z"))
                // Параллелим на 6 потоков
                .AsParallel()
                .WithDegreeOfParallelism(6)
                // Загружаем асинхронно
                .ForAll(value => {
                    string savePath = Path.Combine(directory, value.name);



                    using (WebClient localClient = new WebClient())
                    {
                        localClient.DownloadFile(value.url, savePath);
                    }
                    Console.WriteLine("{0} загружен", value.name);
                });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (WebClient localClient = new WebClient())
            {
                localClient.DownloadFile("https://ram.by/media/product/300x300/0/_/0_ym_10_10_2018__11_51_45.jpg", "s.jpg");
            }
            Console.WriteLine("{0} загружен");
        }
    }
}
