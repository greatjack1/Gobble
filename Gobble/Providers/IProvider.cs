using System;
using System.Collections.Generic;
using Gobble.Products;

namespace Gobble.Providers
{
    public interface IProvider
    {
        void setApiKeys(Dictionary<String, String> keys);
        void setUPC(String upc);
        List<IProduct> QueryProducts();
    }
}
