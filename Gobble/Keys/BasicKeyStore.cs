using System;
using System.Collections.Generic;
using Gobble.Providers;

namespace Gobble.Keys
{
    /// <summary>
    /// BasicKeyStore
    /// This is a basic implementation of the IApiKeystore
    /// It allows you to add keys using a addKey method
    /// It stores all keys in a non peristent Dictionary
    /// </summary>
    public class BasicKeyStore : IApiKeystore
    {
        private Dictionary<Provider, String> keys = new Dictionary<Provider, string>();

        public BasicKeyStore()
        {
            
        }
       /// <summary>
       /// Adds the key.
       /// </summary>
       /// <param name="provider">Provider. The Provider to associate the key with</param>
       /// <param name="key">Key. The key for the provider</param>
        public BasicKeyStore addKey(Provider provider,String key){
            keys.Add(provider, key);
            return this;
        }
        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <returns>The key associated with the provider arguement</returns>
        /// <param name="provider">The Provider to retreive the key for</param>
        public string getKey(Provider provider)
        {
            return keys[provider];
        }
    }
}
