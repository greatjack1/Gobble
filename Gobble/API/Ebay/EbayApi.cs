using System;
using System.Collections.Generic;
using System.Text;
using Gobble.Products;
using System.Net;
using System.Threading.Tasks;
using System.IO;

namespace Gobble.API.Ebay
{
    class EbayApi : Providers.IProvider
    {
        private Dictionary<String, String> mKeys;
        private String mUPC;
        public  String getRequestDataAsync() {
            
            //Create request
            WebRequest request = WebRequest.Create("http://open.api.ebay.com/shopping?callname=FindProducts&responseencoding=XML&appid=" + mKeys["appid"] + "&ProductID.Type=UPC­&ProductID.Value=7" + mUPC);
            request.Method = "GET";
 
            //Get the response
            WebResponse wr =  request.GetResponse();
            Stream receiveStream = wr.GetResponseStream();
            StreamReader reader = new StreamReader(receiveStream, Encoding.UTF8);
            return reader.ReadToEnd();
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
            throw new NotImplementedException();
        }
    }
}
