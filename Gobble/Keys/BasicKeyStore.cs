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
        private Dictionary<Provider, Dictionary<String, String>> keys = new Dictionary<Provider, Dictionary<String, String>>();

        public BasicKeyStore()
        {
            
        }
       /// <summary>
       /// Adds the key.
       /// </summary>
       /// <param name="provider">Provider. The Provider to associate the key with</param>
       /// <param name="keysForProvider">Key. A dictionary containing key names and values for a provider</param>
        public BasicKeyStore addKey(Provider provider,Dictionary<String, String> keysForProvider){
            keys.Add(provider, keysForProvider);
            return this;
        }
        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <returns>The key associated with the provider arguement</returns>
        /// <param name="provider">The Provider to retreive the key for</param>
        public Dictionary<String, String> getKey(Provider provider)
        {
            return keys[provider];
        }
    }
}
