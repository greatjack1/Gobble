using System;
using Gobble.Keys;
using System.Collections.Generic;
using Gobble.API;
using Gobble.Providers;
using System.Threading.Tasks;

namespace GobblePlayground
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Running Gobble Playground");
            List<Provider> providers = new List<Provider>();
            providers.Add(Provider.Amazon);
            Dictionary<String, String> keys = new Dictionary<string, string>();
            BasicKeyStore store = new BasicKeyStore();
            store.addKey(Gobble.Providers.Provider.Amazon, keys);
            var products = await new GobbleBuilder().addKeystore(store).addProviderList(providers).setUPC("888462762670").getProductsAsync();
            Console.WriteLine("Writing products");
            foreach (var prod in products) {
                Console.WriteLine("Name: " + prod.Name + " Price:" + prod.Price + " Condition: " + prod.Condition);
            }
            Console.ReadLine();
        }
    }
}
