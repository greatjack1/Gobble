using System;
using System.Collections.Generic;
using System.Text;
using Gobble.Products;
using System.Net;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Gobble.API.Ebay
{
    class EbayApi : Providers.BaseProvider
    {
       
        public override List<IProduct> QueryProducts()
        {
           
            List<IProduct> products = new List<IProduct>();
            try
            {
                EbayResponse product = JsonConvert.DeserializeObject<EbayResponse>(SimpleWebRequester("http://svcs.ebay.com/services/search/FindingService/v1?OPERATION-NAME=findItemsByProduct&SERVICE-VERSION=1.0.0&SECURITY-APPNAME=" + mKeys["appid"] + "&RESPONSE-DATA-FORMAT=JSON&REST-PAYLOAD&paginationInput.entriesPerPage=5&productId.@type=UPC&productId=" + mUPC));
                foreach (var item in product.FindItemsByProductResponse[0].SearchResult[0].Item)
                {
                    EbayProduct prod = new EbayProduct
                    {
                        Name = item.Title[0] ?? "No title available",
                        Condition = item.Condition[0].ConditionDisplayName[0] ?? "No condition available",
                        CurrentCurrency = item.SellingStatus[0].ConvertedCurrentPrice[0].CurrencyId ?? "No currency information available",
                        Price = Double.Parse(item.SellingStatus[0].ConvertedCurrentPrice[0].Value ?? "-1.0"),
                        FormattedPrice = item.SellingStatus[0].ConvertedCurrentPrice[0].Value ?? "No formmatted price available",
                        UPC = mUPC,
                        Url = item.ViewItemUrl[0] ?? "No item url available",
                        Description = item.Title[0] ?? "No description available",
                        Merchant = "Ebay"
                    };
                    products.Add(prod);
                }
            }
            catch (Exception ex) {
                //log the error to console
                Debug.WriteLine("Error when getting product data from ebay for a upc of " + mUPC + " and with a appid key of " + mKeys["appid"] + ". Error Message is " + ex.Message);
                //Return the empty products
                return products;
            }
            return products;
        }
    }
}
