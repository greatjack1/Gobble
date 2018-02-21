using System;
using System.Collections.Generic;
using System.Text;
using Gobble.Products;
using Newtonsoft.Json;
using System.Diagnostics;
//walmart vsn of provider
namespace Gobble.API.Walmart
{
    class WalmartApi : Providers.BaseProvider
    {
        public override List<IProduct> QueryProducts()
        {
            List<IProduct> products = new List<IProduct>();
            try
            {
                var walmartResponse = JsonConvert.DeserializeObject<WalmartResponse>(SimpleWebRequester("http://api.walmartlabs.com/v1/items?apiKey=" + mKeys["apikey"] + "&upc=" + mUPC));
                foreach (var item in walmartResponse.Items)
                {
                    if (item.Stock != "Not available")
                    {
                        BaseProduct prod = new BaseProduct()
                        {
                            Name = item.Name,
                            Condition = "No Condition Available",
                            Description = item.ShortDescription,
                            Merchant = "Walmart",
                            UPC = item.Upc,
                            Price = item.SalePrice + item.StandardShipRate,
                            FormattedPrice = "$" + (item.SalePrice + item.StandardShipRate),
                            Url = item.ProductUrl,

                        };
                        products.Add(prod);
                    }
                }
            }
            catch (Exception ex) {
                Debug.WriteLine("There was a error when trying to get product information from the walmart open api. Please check that you provided a valid api key and valid upc and try again later. Error Message:" + ex.Message);
                //return the current products list even if empty to prevet a interrupt to program flow
                return products;
            }
            return products;
            }
        }
    }

