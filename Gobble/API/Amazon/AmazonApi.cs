using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public List<IProduct> QueryProducts()
        {
            //create the list to store the amazon products
            List<IProduct> products = new List<IProduct>();
            try
            {
                AmazonAuthentication auth = new AmazonAuthentication();
                auth.AccessKey = accessKey;
                auth.SecretKey = secretKey;
                AmazonWrapper wrapper = new AmazonWrapper(auth, AmazonEndpoint.US, "wyrecorp-20");

                var response = wrapper.Lookup(itemUPC);
                //if the item array is null then there are no items to retreive and return the prodcuts list blank
                if (response.Items is null)
                {
                    return products;
                }


                foreach (var item in response.Items.Item)
                {
                    String desc = "";
                    //ioslate any null pointer errors in the description variable
                    try
                    {
                        //parse all of the item features together to create a description for the product
                        foreach (String line in item.ItemAttributes.Feature)
                        {
                            desc = desc + line + Environment.NewLine;
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Error reading description from amazon in amazon api. Error Message" + ex.Message);
                        desc = "No description available";
                    }
                    //create the new product only if the lowest price for this version of the product is not null, because if it null that means that there is no price
                    if (!(item.OfferSummary.LowestNewPrice is null))
                    {
                        AmazonProduct product = new AmazonProduct
                        {
                            Name = item.ItemAttributes.Title ?? "No Title Available",
                            Merchant = "Amazon",
                            Description = desc ?? "No Description Available",
                            UPC = item.ItemAttributes.UPC ?? "No UPC Available",
                            Condition = "New",
                            Price = Double.Parse(item.OfferSummary.LowestNewPrice.FormattedPrice.Substring(1)),
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
                            Price = Double.Parse(item.OfferSummary.LowestUsedPrice.FormattedPrice.Substring(1)),
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
                            Price = Double.Parse(item.OfferSummary.LowestRefurbishedPrice.FormattedPrice.Substring(1)),
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
            }catch (Exception ex){
                Debug.WriteLine("Error when getting product information from the Amazon Api, please check api keys and upc and try again later. Error Message:" + ex.Message);
                return products;
            }
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
