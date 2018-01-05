using System;
using System.Collections.Generic;
using System.Text;
using Gobble.Products;
using System.Net;
using System.IO;

namespace Gobble.Providers
{
    /// <summary>
    /// A base implementation of a provider that can be used as a boiler plate for adding other providers to the api
    /// </summary>
    class BaseProvider : IProvider
    {
        protected string mUPC = "";
        protected Dictionary<string, string> mKeys;
        public virtual List<IProduct> QueryProducts()
        {
            throw new NotImplementedException();
        }

        public virtual void setApiKeys(Dictionary<string, string> keys)
        {
            mKeys = keys;
        }

        public virtual void setUPC(string upc)
        {
            mUPC = upc;
        }
        /// <summary>
        /// A helper method to make http get requests to the providers web service
        /// </summary>
        /// <param name="url">The url used to get the string response</param>
        /// <returns>A string contating the response from the web server</returns>
        public string SimpleWebRequester(string url) {
            //Create request
            WebRequest request = WebRequest.Create(url);
            //set the http method to get
            request.Method = "GET";
            //Get the response
            WebResponse wr = request.GetResponse();
            Stream receiveStream = wr.GetResponseStream();
            StreamReader reader = new StreamReader(receiveStream, Encoding.UTF8);
            return reader.ReadToEnd();
        }
    }
}
