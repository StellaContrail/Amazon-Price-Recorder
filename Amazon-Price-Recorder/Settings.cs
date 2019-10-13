using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_Price_Recorder
{
    [Serializable]
    public class Settings
    {
        public string email { get; set; }
        public string id { get; set; }
        public string pass { get; set; }
        // 更新間隔をミリ秒で保存
        public decimal interval { get; set; }

        public Settings(string _email, string _id, string _pass)
        {
            email = _email;
            id = _id;
            pass = _pass;
        }

        public Settings(string _email, string _id, string _pass, decimal _interval)
        {
            email = _email;
            id = _id;
            pass = _pass;
            interval = _interval;
        }
    }
}
