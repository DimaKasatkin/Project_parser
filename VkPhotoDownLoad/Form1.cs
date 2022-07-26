using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace VkPhotoDownLoad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*   var api = new VkApi();

                api.Authorize(new ApiAuthParams{
                    ApplicationId = 986644512,
                    Login = "Login",
                    Password = "Password",
                    Settings = Settings.All
                });
                Console.WriteLine(api.Token);
                var res = api.Groups.Get(new GroupsGetParams());

                Console.WriteLine(res.TotalCount);

                Console.ReadLine();
                //Console.ReadLine();\\
                (*/

            var api = new VkApi();

            api.Authorize(new ApiAuthParams
            {
                ApplicationId = 123456,
                Login = "Login",
                Password = "Password"              
            });
            Console.WriteLine(api.Token);
            var res = api.Groups.Get(new GroupsGetParams());

            Console.WriteLine(res.TotalCount);

            Console.ReadLine();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WebClient webc = new WebClient();
           // pb1.Visible = true;
          //  pb1.Maximum = mList.Items.Count;
           // pb1.Minimum = 1;
          ///  pb1.Step = 1;
          //  pb1.Value = 1;
            int appID = 5272595;                      // ID приложения
            string email = "your email";         // email или телефон
            string pass = "your pwd";               // пароль для авторизации
            Settings scope = Settings.All;
            var vks = new VkApi();
          
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            VkApi Api = new VkApi();
            //   var upload = Api.Photo.GetUploadServer(00, 22822305);
            Api.Authorize(new ApiAuthParams
            {
                ApplicationId = 123456,
                Login = "Login",
                Password = "Password",
                Settings = Settings.All
            });
            PhotoGetParams photoParams = new PhotoGetParams();
            photoParams.AlbumId = VkNet.Enums.SafetyEnums.PhotoAlbumType.Wall;
            photoParams.OwnerId = -22822305;
            int n = 1;
            var photos = Api.Photo.Get(photoParams);
            using (WebClient webClient = new WebClient())
            {
                string file = @"https://vk.com/";
                foreach (var photo in photos)
                {
                    webClient.DownloadFile(file + photo.ToString(), photo.ToString());
                }
            }
        }
    }
}
