using System;
using Gobble.Products;
namespace Gobble.API.Amazon
{
    public class AmazonProduct : IProduct
    {
        private String mName;
        private String mCondition;
        private String mDescription;
        private double mPrice;
        private String mFormattedPrice;
        private String mCurrentCurrency;
        private String mUPC;
        public AmazonProduct()
        {

        }

        public string Name
        {
            get { return mName; }
            
            set
            {
                mName = value;
            }
        }
        public string Description { get => mDescription; set => mDescription = value; }
        public string Condition { get => mCondition; set => mCondition = value; }
        public double Price { get => mPrice; set => mPrice = value; }
        public string FormattedPrice { get => mFormattedPrice; set => mFormattedPrice = value; }
        public string CurrentCurrency { get => mCurrentCurrency; set => mCurrentCurrency = value; }
        public string UPC { get => mUPC; set => mUPC = value; }
    }
}
