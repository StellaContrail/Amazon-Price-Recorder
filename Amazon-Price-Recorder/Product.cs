using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_Price_Recorder
{
    [Serializable]
    class Product
    {
        // 登録時に取得できれば更新の必要なし
        public string ASIN { get; }
        public string Name { get; }
        public int ReferencePrice { get; }

        // 毎回更新する必要があるデータ
        public Dictionary<DateTime, int> PriceHistory = new Dictionary<DateTime, int>();

        [NonSerialized]
        string _status;
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        [NonSerialized]
        int _newStockCount;
        public int NewStockCount
        {
            get { return _newStockCount; }
            set { _newStockCount = value; }
        }
        [NonSerialized]
        int _usedStockCount;
        public int UsedStockCount
        {
            get { return _usedStockCount; }
            set { _usedStockCount = value; }
        }
        [NonSerialized]
        int _price;
        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }
        [NonSerialized]
        int _newStockPrice;
        public int NewStockPrice
        {
            get { return _newStockPrice; }
            set { _newStockPrice = value; }
        }
        [NonSerialized]
        int _usedStockPrice;
        public int UsedStockPrice
        {
            get { return _usedStockPrice; }
            set { _usedStockPrice = value; }
        }
        [NonSerialized]
        int _priceSaving;
        public int PriceSaving
        {
            get { return _priceSaving; }
            set { _priceSaving = value; }
        }
        [NonSerialized]
        string _ranking;
        public string Ranking
        {
            get { return _ranking; }
            set { _ranking = value; }
        }
        [NonSerialized]
        MerchantStatus _merchantStatus;
        public MerchantStatus MerchantStatus
        {
            get { return _merchantStatus; }
            set { _merchantStatus = value; }
        }

        // 通知設定
        public bool whenStatusChanges = false;
        public bool whenPriceGoesDown = false;
        public decimal thresholdPrice = 0;
        public bool whenNewStockCountGoesDown = false;
        public decimal thresholdNewStockCount = 0;
        public bool whenUsedStockCountGoesDown = false;
        public decimal thresholdUsedStockcount = 0;

        // コンストラクタ及びメソッド
        public Product(string _ASIN, string _name, int _referencePrice)
        {
            ASIN = _ASIN;
            Name = _name;
            ReferencePrice = _referencePrice;
        }
        public Product()
        {

            ASIN = "";
            Name = "";
            ReferencePrice = 0;
            Price = 0;
            PriceSaving = 0;
            NewStockCount = 0;
            NewStockPrice = 0;
            UsedStockCount = 0;
            UsedStockPrice = 0;
            MerchantStatus = 0;
            Ranking = "";
            Status = "";
        }
        public void SetStockInfo(int _NewStockPrice, int _NewStockCount, int _UsedStockPrice, int _UsedStockCount)
        {
            NewStockPrice = _NewStockPrice;
            NewStockCount = _NewStockCount;
            UsedStockPrice = _UsedStockPrice;
            UsedStockCount = _UsedStockCount;
        }
    }
}
