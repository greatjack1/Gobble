using System;
using System.Collections.Generic;
using System.Text;

namespace Gobble.Products
{
   public class BaseProduct : IProduct
    {
        //feild level variables to hold propertie values
        private String mName;
        private String mCondition;
        private String mDescription;
        private double mPrice;
        private String mFormattedPrice;
        private String mCurrentCurrency;
        private String mUPC;
        private String mURL;
        private String mMerchant;
        public BaseProduct() { }

        //implementaion of all properties
        public string Description { get => mDescription; set => mDescription = value; }
        public string Condition { get => mCondition; set => mCondition = value; }
        public double Price { get => mPrice; set => mPrice = value; }
        public string FormattedPrice { get => mFormattedPrice; set => mFormattedPrice = value; }
        public string CurrentCurrency { get => mCurrentCurrency; set => mCurrentCurrency = value; }
        public string UPC { get => mUPC; set => mUPC = value; }
        public string Url { get => mURL; set => mURL = value; }
        public string Name { get => mName; set => mName = value; }
        public string Merchant { get => mMerchant; set => mMerchant= value; }
    }
}
