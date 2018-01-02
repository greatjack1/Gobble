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
        public GobbleBuilder addProviderList(List<Provider> providers){
            mProviders = providers;
            return this;
        }
        public GobbleBuilder addKeystore(IApiKeystore store){
            keystore = store;
            return this;
        }
        public GobbleBuilder setUPC(String UPC) {
            mUPC = UPC;
            return this;
        }
        public async Task<List<IProduct>> getProductsAsync() {
            Task<List<IProduct>> task = new Task<List<IProduct>>(() =>
            {
                List<IProduct> products = new List<IProduct>();
                foreach (Provider prov in mProviders)
                {
                    switch (prov)
                    {
                        case Provider.Amazon:
                            IProvider provider = new Amazon.AmazonApi();
                            provider.setApiKeys(keystore.getKey(Provider.Amazon));
                            provider.setUPC(mUPC);
                            products.AddRange(provider.queryProducts());
                            break;
                        case Provider.Ebay:
                            IProvider EbayProvider = new Ebay.EbayApi();
                            EbayProvider.setApiKeys(keystore.getKey(Provider.Ebay));
                            EbayProvider.setUPC(mUPC);
                            products.AddRange(EbayProvider.queryProducts());
                            break;
                        case Provider.Jet:
                            break;
                        case Provider.Kohls:
                            break;
                        case Provider.Target:
                            break;
                        case Provider.Walmart:
                            break;

                    }
                }
                return products;
            });
            task.Start();
            await Task.WhenAll(task);
            return task.Result;
        }
        public List<IProduct> getProducts() {
            List<IProduct> products = new List<IProduct>();
            foreach (Provider prov in mProviders)
            {
                switch (prov)
                {
                    case Provider.Amazon:
                        IProvider provider = new Amazon.AmazonApi();
                        provider.setApiKeys(keystore.getKey(Provider.Amazon));
                        provider.setUPC(mUPC);
                        products.AddRange(provider.queryProducts());
                        break;
                    case Provider.Ebay:
                        IProvider EbayProvider = new Ebay.EbayApi();
                        EbayProvider.setApiKeys(keystore.getKey(Provider.Ebay));
                        EbayProvider.setUPC(mUPC);
                        products.AddRange(EbayProvider.queryProducts());
                        break;
                    case Provider.Jet:
                        break;
                    case Provider.Kohls:
                        break;
                    case Provider.Target:
                        break;
                    case Provider.Walmart:
                        break;

                }
            }
            return products;
        }
        /// <summary>
        /// Gets the product results.
        /// This method when called executes the query.
        /// It goes thorugh all providers, gets the products and returns the reponses in the form of List<IProduct>
        /// </summary>
        /// <returns>The product results.</returns>
        public List<IProduct> GetProductResults(){
            return null;
        }
    }
}
