using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace VK_pro_consoles
{
    class Program
    {
        static void Main(string[] args)
        {

            var api = new VkApi();

            api.Authorize(new ApiAuthParams
            {
                ApplicationId = 6992485,
                Login = "+375447228549",
                Password = "Ыфылу159",
                Settings = Settings.Friends
            });
            Console.WriteLine(api.Token);
            var res = api.Groups.Get(new GroupsGetParams());

            Console.WriteLine(res.TotalCount);

            Console.ReadLine();
        }
    }
}
