using System;
using System.Collections.Generic;
using Gobble.Keys;
using Gobble.Products;
using Gobble.Providers;
using System.Threading.Tasks;

namespace Gobble.API
{
    public class GobbleBuilder
    {
        private List<Provider> mProviders;
        private IApiKeystore keystore;
        private String mUPC = "";
        public GobbleBuilder()
        {
            
        }
        public GobbleBuilder AddProviderList(List<Provider> providers){
            mProviders = providers;
            return this;
        }
        public GobbleBuilder AddKeystore(IApiKeystore store){
            keystore = store;
            return this;
        }
        public GobbleBuilder SetUPC(String UPC) {
            mUPC = UPC;
            return this;
        }
        /// <summary>
        /// This is the Async version of the GetProducts method
        /// It is used to retreive prices of a item using the upc, provider list and api keys that were provided
        /// </summary>
        /// <returns></returns>
        public async Task<List<IProduct>> GetProductsAsync() {
            Task<List<IProduct>> task = new Task<List<IProduct>>(() =>
            {
                return InternalGetProducts();
            });
            task.Start();
            await Task.WhenAll(task);
            return task.Result;
        }
        /// <summary>
        /// This is the reguler version of the GetProducts method
        ///  It is used to retreive prices of a item using the upc, provider list and api keys that were provided
        /// </summary>
        /// <returns></returns>
        public List<IProduct> GetProducts() {
            return InternalGetProducts();
        }
        /// <summary>
        /// This is a internal class method that is used to get the products.
        /// It is sperated from the public method to allow two versions of the public method to use this functionality
        /// We require to versions of the public method so that we can make one Async for people using the api in such patterns
        /// </summary>
        /// <returns></returns>
        private List<IProduct> InternalGetProducts() {
            List<IProduct> products = new List<IProduct>();
            foreach (Provider prov in mProviders)
            {
                switch (prov)
                {
                    case Provider.Amazon:
                        IProvider provider = new Amazon.AmazonApi();
                        provider.setApiKeys(keystore.getKey(Provider.Amazon));
                        provider.setUPC(mUPC);
                        products.AddRange(provider.QueryProducts());
                        break;
                    case Provider.Ebay:
                        IProvider EbayProvider = new Ebay.EbayApi();
                        EbayProvider.setApiKeys(keystore.getKey(Provider.Ebay));
                        EbayProvider.setUPC(mUPC);
                        products.AddRange(EbayProvider.QueryProducts());
                        break;
                    case Provider.Jet:
                        break;
                    case Provider.Kohls:
                        break;
                    case Provider.Target:
                        break;
                    case Provider.Walmart:
                        IProvider WalmartProvider = new Walmart.WalmartApi();
                        WalmartProvider.setApiKeys(keystore.getKey(Provider.Walmart));
                       WalmartProvider.setUPC(mUPC);
                        products.AddRange(WalmartProvider.QueryProducts());
                        break;

                }
            }
            return products;

        }
       
    }
}
