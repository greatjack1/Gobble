using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Gobble.Products;

namespace Gobble.Infastructure.ExtensionMethods
{
    public static class ConcurrentBag
    {
        public static void AddRange(this ConcurrentBag<IProduct> bag, List<IProduct> list)
        {
            foreach (var item in list)
            {
                bag.Add(item);
            }
        }
    }
}
