using System;
using System.Collections.Generic;
using Gobble.Products;
using Nager.AmazonProductAdvertising;
using Nager.AmazonProductAdvertising.Model;

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
            //create the list to store the amazon products
            List<IProduct> products = new List<IProduct>();
            var response = wrapper.Lookup(itemUPC);
            foreach (var item in response.Items.Item)
            {
                //create three products to represent the lowest new, lowest used, and lowest refurbished
                AmazonProduct product = new AmazonProduct();
                AmazonProduct productUsed = new AmazonProduct();
                AmazonProduct productRefurb = new AmazonProduct();
                product.Name = item.ItemAttributes.Title;
                productUsed.Name = item.ItemAttributes.Title;
                productRefurb.Name = item.ItemAttributes.Title;
                //parse all of the item features together to create a description
                String desc = "";
                foreach (String line in item.ItemAttributes.Feature)
                {
                    desc = desc + line + Environment.NewLine;
                }
                product.Description = desc;
                productUsed.Description = desc;
                productRefurb.Description = desc;
                product.UPC = item.ItemAttributes.UPC;
                productUsed.UPC = item.ItemAttributes.UPC;
                productRefurb.UPC = item.ItemAttributes.UPC;
                //set the conditions based on the product type
                product.Condition = "New";
                productUsed.Condition = "Used";
                productRefurb.Condition = "Refurbished";
                //set the prices for the products from the lowest offers section
                product.Price = Double.Parse(item.OfferSummary.LowestNewPrice.Amount);
                productUsed.Price = Double.Parse(item.OfferSummary.LowestUsedPrice.Amount);
                productRefurb.Price = Double.Parse(item.OfferSummary.LowestRefurbishedPrice.Amount);
                //set the formatted price for each item
                product.FormattedPrice = item.OfferSummary.LowestNewPrice.FormattedPrice;
                productUsed.FormattedPrice = item.OfferSummary.LowestUsedPrice.FormattedPrice;
                productRefurb.FormattedPrice = item.OfferSummary.LowestRefurbishedPrice.FormattedPrice;
                //set the currency for each price
                product.CurrentCurrency = item.OfferSummary.LowestNewPrice.CurrencyCode;
                productUsed.CurrentCurrency = item.OfferSummary.LowestUsedPrice.CurrencyCode;
                productRefurb.CurrentCurrency = item.OfferSummary.LowestRefurbishedPrice.CurrencyCode;
                //add the three products to the list
                products.Add(product);
                products.Add(productUsed);
                products.Add(productRefurb);
            }
            return products;
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
