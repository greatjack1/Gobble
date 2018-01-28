using System;
using System.Collections.Generic;
using System.Text;

namespace Gobble.API.BestBuy
{
    
    using Newtonsoft.Json;

    public partial class BestBuyResponse
    {
        [JsonProperty("from")]
        public long From { get; set; }

        [JsonProperty("to")]
        public long To { get; set; }

        [JsonProperty("currentPage")]
        public long CurrentPage { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("totalPages")]
        public long TotalPages { get; set; }

        [JsonProperty("queryTime")]
        public string QueryTime { get; set; }

        [JsonProperty("totalTime")]
        public string TotalTime { get; set; }

        [JsonProperty("partial")]
        public bool Partial { get; set; }

        [JsonProperty("canonicalUrl")]
        public string CanonicalUrl { get; set; }

        [JsonProperty("products")]
        public Product[] Products { get; set; }
    }

    public partial class Product
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("shortDescription")]
        public string ShortDescription { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("upc")]
        public string Upc { get; set; }

        [JsonProperty("salePrice")]
        public double SalePrice { get; set; }

        [JsonProperty("shippingCost")]
        public long ShippingCost { get; set; }

        [JsonProperty("condition")]
        public string Condition { get; set; }
    }
}
