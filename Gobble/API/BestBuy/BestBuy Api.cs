using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Gobble.Products;
using Newtonsoft.Json;
namespace Gobble.API.BestBuy
{
    class BestBuy_Api : Providers.BaseProvider
    {
        public override List<IProduct> QueryProducts()
        {
            try
            {
                string url = "https://api.bestbuy.com/v1/products(upc=" + mUPC + ")?sort=condition.asc&show=condition,name,salePrice,shippingCost,shortDescription,upc,url&format=json&apiKey=" + mKeys["apiKey"];
                BestBuyResponse response = JsonConvert.DeserializeObject<BestBuyResponse>(SimpleWebRequester(url));
                List<IProduct> products = new List<IProduct>();
                foreach (var item in response.Products)
                {
                    BaseProduct prod = new BaseProduct()
                    {
                        Name = item.Name,
                        Condition = item.Condition,
                        Url = item.Url,
                        UPC = item.Upc,
                        Description = item.ShortDescription,
                        Price = item.SalePrice + item.ShippingCost,
                        FormattedPrice = "$" + (item.SalePrice + item.ShippingCost)
                    };
                    products.Add(prod);
                }
                return products;
            } catch(Exception ex){
                Debug.WriteLine("The following error occured when getting products from the best buy api:" + ex.Message);
              //return a blank list to prevent all code paths must return a value error
                return new List<IProduct>();
            }
        
        }
    }
}
