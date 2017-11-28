using System;
using System.Collections.Generic;
using Gobble.Keys;
using Gobble.Products;
using Gobble.Providers;
namespace Gobble.API
{
    public class GobbleBuilder
    {
        private List<Provider> mProviders;
        private IApiKeystore keystore;
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
