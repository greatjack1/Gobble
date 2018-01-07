using System;
using System.Collections.Generic;
using System.Text;

namespace Gobble.API.Walmart
{
    
    using Newtonsoft.Json;
    /// <summary>
    /// A class used to serialize the json to
    /// </summary>
    public partial class WalmartResponse
    {
        [JsonProperty("items")]
        public Item[] Items { get; set; }
    }

    public partial class Item
    {
        [JsonProperty("itemId")]
        public long ItemId { get; set; }

        [JsonProperty("parentItemId")]
        public long ParentItemId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("msrp")]
        public double Msrp { get; set; }

        [JsonProperty("salePrice")]
        public double SalePrice { get; set; }

        [JsonProperty("upc")]
        public string Upc { get; set; }

        [JsonProperty("categoryPath")]
        public string CategoryPath { get; set; }

        [JsonProperty("shortDescription")]
        public string ShortDescription { get; set; }

        [JsonProperty("longDescription")]
        public string LongDescription { get; set; }

        [JsonProperty("brandName")]
        public string BrandName { get; set; }

        [JsonProperty("thumbnailImage")]
        public string ThumbnailImage { get; set; }

        [JsonProperty("mediumImage")]
        public string MediumImage { get; set; }

        [JsonProperty("largeImage")]
        public string LargeImage { get; set; }

        [JsonProperty("productTrackingUrl")]
        public string ProductTrackingUrl { get; set; }

        [JsonProperty("ninetySevenCentShipping")]
        public bool NinetySevenCentShipping { get; set; }

        [JsonProperty("standardShipRate")]
        public double StandardShipRate { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("marketplace")]
        public bool Marketplace { get; set; }

        [JsonProperty("shipToStore")]
        public bool ShipToStore { get; set; }

        [JsonProperty("freeShipToStore")]
        public bool FreeShipToStore { get; set; }

        [JsonProperty("modelNumber")]
        public string ModelNumber { get; set; }

        [JsonProperty("productUrl")]
        public string ProductUrl { get; set; }

        [JsonProperty("customerRating")]
        public string CustomerRating { get; set; }

        [JsonProperty("numReviews")]
        public long NumReviews { get; set; }

        [JsonProperty("customerRatingImage")]
        public string CustomerRatingImage { get; set; }

        [JsonProperty("categoryNode")]
        public string CategoryNode { get; set; }

        [JsonProperty("bundle")]
        public bool Bundle { get; set; }

        [JsonProperty("clearance")]
        public bool Clearance { get; set; }

        [JsonProperty("preOrder")]
        public bool PreOrder { get; set; }

        [JsonProperty("stock")]
        public string Stock { get; set; }

        [JsonProperty("attributes")]
        public Attributes Attributes { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("addToCartUrl")]
        public string AddToCartUrl { get; set; }

        [JsonProperty("affiliateAddToCartUrl")]
        public string AffiliateAddToCartUrl { get; set; }

        [JsonProperty("freeShippingOver50Dollars")]
        public bool FreeShippingOver50Dollars { get; set; }

        [JsonProperty("imageEntities")]
        public ImageEntity[] ImageEntities { get; set; }

        [JsonProperty("offerType")]
        public string OfferType { get; set; }

        [JsonProperty("isTwoDayShippingEligible")]
        public bool IsTwoDayShippingEligible { get; set; }

        [JsonProperty("availableOnline")]
        public bool AvailableOnline { get; set; }
    }

    public partial class ImageEntity
    {
        [JsonProperty("thumbnailImage")]
        public string ThumbnailImage { get; set; }

        [JsonProperty("mediumImage")]
        public string MediumImage { get; set; }

        [JsonProperty("largeImage")]
        public string LargeImage { get; set; }

        [JsonProperty("entityType")]
        public string EntityType { get; set; }
    }

    public partial class Attributes
    {
        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }

        [JsonProperty("storeSharedSHEligibility")]
        public string StoreSharedShEligibility { get; set; }
    }
}
