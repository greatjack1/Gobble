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
            //if the item array is null then there are no items to retreive and return the prodcuts list blank
            if (response.Items is null) {
                return products;
            }
            foreach (var item in response.Items.Item)
            {
                //parse all of the item features together to create a description for the product
                String desc = "";
                foreach (String line in item.ItemAttributes.Feature)
                {
                    desc = desc + line + Environment.NewLine;
                }
                //create the new product only if the lowest price for this version of the product is not null, because if it null that means that there is no price
                if (!(item.OfferSummary.LowestNewPrice is null)) {
                    AmazonProduct product = new AmazonProduct
                    {
                        Name = item.ItemAttributes.Title ?? "No Title Available",
                        Merchant = "Amazon",
                        Description = desc ?? "No Description Available",
                        UPC = item.ItemAttributes.UPC ?? "No UPC Available",
                        Condition = "New",
                        Price = Double.Parse(item.OfferSummary.LowestNewPrice.Amount),
                        FormattedPrice = item.OfferSummary.LowestNewPrice.FormattedPrice ?? "No Formatted Price Available",
                        CurrentCurrency = item.OfferSummary.LowestNewPrice.CurrencyCode ?? "No Currency Code Available",
                        Url = item.DetailPageURL ?? "No Url Available"
                    };
                    products.Add(product);
                }
                if (!(item.OfferSummary.LowestUsedPrice is null))
                {
                    AmazonProduct productUsed = new AmazonProduct
                    {
                        Name = item.ItemAttributes.Title ?? "No Title Available",
                        Merchant = "Amazon",
                        Description = desc ?? "No Description Available",
                        Condition = "Used",
                        UPC = item.ItemAttributes.UPC ?? "No UPC Available",
                        Price = Double.Parse(item.OfferSummary.LowestUsedPrice.Amount),
                        FormattedPrice = item.OfferSummary.LowestUsedPrice.FormattedPrice ?? "No Formatted Price Available",
                        CurrentCurrency = item.OfferSummary.LowestUsedPrice.CurrencyCode,
                        Url = item.DetailPageURL ?? "No Url Available"
                    };
                    products.Add(productUsed);
                }
                if (!(item.OfferSummary.LowestRefurbishedPrice is null))
                {
                    AmazonProduct productRefurb = new AmazonProduct
                    {
                        Name = item.ItemAttributes.Title ?? "No Title Available",
                        Merchant = "Amazon",
                        Description = desc ?? "No Description Available",
                        UPC = item.ItemAttributes.UPC ?? "No UPC Available",
                        //set the conditions based on the product type
                        Condition = "Refurbished",
                        //set the prices for the products from the lowest offers section
                        Price = Double.Parse(item.OfferSummary.LowestRefurbishedPrice.Amount),
                        //set the formatted price for each item      
                        FormattedPrice = item.OfferSummary.LowestRefurbishedPrice.FormattedPrice ?? "No Formatted Price Available",
                        //set the currency for each price           
                        CurrentCurrency = item.OfferSummary.LowestRefurbishedPrice.CurrencyCode ?? "No Currency Code Available",
                        Url = item.DetailPageURL ?? "No Url Available"
                    };
                    //add the three products to the list           
                    products.Add(productRefurb);
                }
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
