using System;
using System.Collections.Generic;
using Gobble.Products;
using Nager.AmazonProductAdvertising;

namespace Gobble.API.Amazon
{
    /// <summary>
    /// Amazon API.
    /// </summary>
    public class AmazonApi : Providers.IProvider
    {
        private String accessKey = "";
        private String secretKey = "";
        private String itemUPC = "";
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gobble.API.Amazon.AmazonApi"/> class.
        /// </summary>
        public AmazonApi()
        {
            
        }
        /// <summary>
        /// Queries the products.
        /// This method triggures the query that returns amazon products for the specified upc
        /// </summary>
        /// <returns>The products.</returns>
        public List<IProduct> queryProducts()
        {
            AmazonAuthentication auth = new AmazonAuthentication();
            auth.AccessKey = accessKey;
            auth.SecretKey = secretKey;
            AmazonWrapper wrapper = new AmazonWrapper(auth, AmazonEndpoint.US, "wyrecorp-20");
           var response = wrapper.Lookup(itemUPC);
            foreach(var item in response.Items.Item){
              
            }
            return null;
        }
        /// <summary>
        /// Sets the API keys.
        /// Gives the amazon part of the api a dictionary conatining the api keys that the api needs to query products
        /// </summary>
        /// <param name="keys">Keys.</param>
        public void setApiKeys(Dictionary<string, string> keys)
        {
            accessKey = keys["AccessKey"];
            secretKey = keys["SecretKey"];
        }
        /// <summary>
        /// Sets the upc.
        /// </summary>
        /// <param name="upc">Upc. The upc to use in the query</param>
        public void setUPC(string upc)
        {
            itemUPC = upc;
        }
    }
}
