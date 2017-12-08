using System;
using System.Collections.Generic;
using System.Text;
using Gobble.Products;

namespace Gobble.API.Ebay
{
    class EbayApi : Providers.IProvider
    {
        private Dictionary<String, String> mKeys;
        private String mUPC;
        public List<IProduct> queryProducts()
        {
            throw new NotImplementedException();
        }

        public void setApiKeys(Dictionary<string, string> keys)
        {
            mKeys = keys;
        }

        public void setUPC(string upc)
        {
            mUPC = upc;
        }
    }
}
