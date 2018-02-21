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
            providers.Add(Provider.BestBuy);
            Dictionary<String, String> keys = new Dictionary<string, string>();
            BasicKeyStore store = new BasicKeyStore();
            store.addKey(Gobble.Providers.Provider.BestBuy, keys);
            var products =  new GobbleBuilder().AddKeystore(store).AddProviderList(providers).SetUPC("190198342560ds").GetProducts();
            Console.WriteLine("Writing products");
            //sort by price
            products.Sort((n, m) =>
            {
                if (n.Price > m.Price)
                {
                    return 1;
                }
                else if (n.Price < m.Price)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            });
            //display them
            foreach (var prod in products) {
                Console.WriteLine("Name: " + prod.Name + " Price:" + prod.Price + " Condition: " + prod.Condition);
            }
            Console.ReadLine();
        }
    }
}
