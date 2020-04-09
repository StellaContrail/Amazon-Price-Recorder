using System;
using System.Net;

namespace Amazon_Price_Recorder
{
    [Serializable]
    public class Setting
    {
        // 通知に用いるメールアドレス
        public string Email { get; set; }
        // メールアカウント ID / PASSWORD
        public string Id { get; set; }
        public string Pass { get; set; }
        // 商品価格を更新する間隔 (単位：秒)
        public decimal Interval { get; set; }

        public Setting()
        {
            Email = "";
            Id = "";
            Pass = "";
            Interval = 120;
        }

        public Setting(string _email, string _id, string _pass)
        {
            Email = _email;
            Id = _id;
            Pass = _pass;
            Interval = 120;
        }

        public Setting(string _email, string _id, string _pass, decimal _interval)
        {
            Email = _email;
            Id = _id;
            Pass = _pass;
            Interval = _interval;
        }
    }
}
