using System;
using System.Collections.Generic;
using System.Text;
using Gobble.Products;
using System.Net;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
namespace Gobble.API.Ebay
{
    class EbayApi : Providers.IProvider
    {
        private Dictionary<String, String> mKeys;
        private String mUPC;
        public  String getRequestData() {
            
            //Create request
            WebRequest request = WebRequest.Create("http://svcs.ebay.com/services/search/FindingService/v1?OPERATION-NAME=findItemsByProduct&SERVICE-VERSION=1.0.0&SECURITY-APPNAME="+ mKeys["appid"] + "&RESPONSE-DATA-FORMAT=JSON&REST-PAYLOAD&paginationInput.entriesPerPage=5&productId.@type=UPC&productId=" + mUPC);
            request.Method = "GET";
 
            //Get the response
            WebResponse wr =  request.GetResponse();
            Stream receiveStream = wr.GetResponseStream();
            StreamReader reader = new StreamReader(receiveStream, Encoding.UTF8);
            String response = reader.ReadToEnd();
            return response;
        }
        public void setApiKeys(Dictionary<string, string> keys)
        {
            mKeys = keys;
        }

        public void setUPC(string upc)
        {
            mUPC = upc;
        }

        public List<IProduct> queryProducts()
        {
            List<IProduct> products = new List<IProduct>();
            EbayResponse product = JsonConvert.DeserializeObject<EbayResponse>(getRequestData());
            foreach(var item in product.FindItemsByProductResponse[0].SearchResult[0].Item){
                EbayProduct prod = new EbayProduct();
                prod.Name = item.Title[0] ?? "No title available";
                prod.Condition = item.Condition[0].ConditionDisplayName[0] ?? "No condition available";
                prod.CurrentCurrency = item.SellingStatus[0].ConvertedCurrentPrice[0].CurrencyId ?? "No currency information available";
                prod.Price = Double.Parse(item.SellingStatus[0].ConvertedCurrentPrice[0].Value ?? "-1.0");
                prod.FormattedPrice = item.SellingStatus[0].ConvertedCurrentPrice[0].Value ?? "No formmatted price available";
                prod.UPC = mUPC;
                prod.Url = item.ViewItemUrl[0] ?? "No item url available";
                prod.Description = item.Title[0] ?? "No description available";
                prod.Merchant = "Ebay";
                products.Add(prod);
            }
            return products;
        }
    }
}
