using System;
using Gobble.Keys;
using System.Collections.Generic;
using Gobble.API;
using Gobble.Providers;

namespace GobblePlayground
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running Gobble Playground");
            List<Provider> providers = new List<Provider>();
            providers.Add(Provider.Amazon);
            Dictionary<String, String> keys = new Dictionary<string, string>();
    //put keys here in the keystore, ommited cuz this is going on github
            BasicKeyStore store = new BasicKeyStore();
            store.addKey(Gobble.Providers.Provider.Amazon, keys);
            var products = new GobbleBuilder().addKeystore(store).addProviderList(providers).setUPC("888462762670").getProducts();
            foreach (var prod in products) {
                Console.WriteLine("Name: " + prod.Name + " Price:" + prod.Price + " Condition: " + prod.Condition);
            }
            Console.ReadLine();
        }
    }
}
