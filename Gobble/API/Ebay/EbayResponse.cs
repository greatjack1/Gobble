using System;
namespace Gobble.API.Ebay
{
    using System;
    using System.Net;
    using System.Collections.Generic;

    using Newtonsoft.Json;
    using J = Newtonsoft.Json.JsonPropertyAttribute;

    public partial class EbayResponse
    {
        [J("findItemsByProductResponse")] public FindItemsByProductResponse[] FindItemsByProductResponse { get; set; }
    }

    public partial class FindItemsByProductResponse
    {
        [J("ack")] public string[] Ack { get; set; }
        [J("version")] public string[] Version { get; set; }
        [J("timestamp")] public DateTime[] Timestamp { get; set; }
        [J("searchResult")] public SearchResult[] SearchResult { get; set; }
        [J("paginationOutput")] public PaginationOutput[] PaginationOutput { get; set; }
        [J("itemSearchURL")] public string[] ItemSearchUrl { get; set; }
    }

    public partial class SearchResult
    {
        [J("@count")] public string Count { get; set; }
        [J("item")] public Item[] Item { get; set; }
    }

    public partial class Item
    {
        [J("itemId")] public string[] ItemId { get; set; }
        [J("title")] public string[] Title { get; set; }
        [J("globalId")] public string[] GlobalId { get; set; }
        [J("subtitle")] public string[] Subtitle { get; set; }
        [J("primaryCategory")] public PrimaryCategory[] PrimaryCategory { get; set; }
        [J("galleryURL")] public string[] GalleryUrl { get; set; }
        [J("viewItemURL")] public string[] ViewItemUrl { get; set; }
        [J("productId")] public ProductId[] ProductId { get; set; }
        [J("paymentMethod")] public string[] PaymentMethod { get; set; }
        [J("autoPay")] public string[] AutoPay { get; set; }
        [J("postalCode")] public string[] PostalCode { get; set; }
        [J("location")] public string[] Location { get; set; }
        [J("country")] public string[] Country { get; set; }
        [J("shippingInfo")] public ShippingInfo[] ShippingInfo { get; set; }
        [J("sellingStatus")] public SellingStatus[] SellingStatus { get; set; }
        [J("listingInfo")] public ListingInfo[] ListingInfo { get; set; }
        [J("returnsAccepted")] public string[] ReturnsAccepted { get; set; }
        [J("condition")] public Condition[] Condition { get; set; }
        [J("isMultiVariationListing")] public string[] IsMultiVariationListing { get; set; }
        [J("topRatedListing")] public string[] TopRatedListing { get; set; }
    }

    public partial class ShippingInfo
    {
        [J("shippingServiceCost")] public ConvertedCurrentPrice[] ShippingServiceCost { get; set; }
        [J("shippingType")] public string[] ShippingType { get; set; }
        [J("shipToLocations")] public string[] ShipToLocations { get; set; }
        [J("expeditedShipping")] public string[] ExpeditedShipping { get; set; }
        [J("oneDayShippingAvailable")] public string[] OneDayShippingAvailable { get; set; }
        [J("handlingTime")] public string[] HandlingTime { get; set; }
    }

    public partial class SellingStatus
    {
        [J("currentPrice")] public ConvertedCurrentPrice[] CurrentPrice { get; set; }
        [J("convertedCurrentPrice")] public ConvertedCurrentPrice[] ConvertedCurrentPrice { get; set; }
        [J("sellingState")] public string[] SellingState { get; set; }
        [J("timeLeft")] public string[] TimeLeft { get; set; }
        [J("bidCount")] public string[] BidCount { get; set; }
    }

    public partial class ConvertedCurrentPrice
    {
        [J("@currencyId")] public string CurrencyId { get; set; }
        [J("__value__")] public string Value { get; set; }
    }

    public partial class ProductId
    {
        [J("@type")] public string Type { get; set; }
        [J("__value__")] public string Value { get; set; }
    }

    public partial class PrimaryCategory
    {
        [J("categoryId")] public string[] CategoryId { get; set; }
        [J("categoryName")] public string[] CategoryName { get; set; }
    }

    public partial class ListingInfo
    {
        [J("bestOfferEnabled")] public string[] BestOfferEnabled { get; set; }
        [J("buyItNowAvailable")] public string[] BuyItNowAvailable { get; set; }
        [J("startTime")] public DateTime[] StartTime { get; set; }
        [J("endTime")] public DateTime[] EndTime { get; set; }
        [J("listingType")] public string[] ListingType { get; set; }
        [J("gift")] public string[] Gift { get; set; }
        [J("watchCount")] public string[] WatchCount { get; set; }
    }

    public partial class Condition
    {
        [J("conditionId")] public string[] ConditionId { get; set; }
        [J("conditionDisplayName")] public string[] ConditionDisplayName { get; set; }
    }

    public partial class PaginationOutput
    {
        [J("pageNumber")] public string[] PageNumber { get; set; }
        [J("entriesPerPage")] public string[] EntriesPerPage { get; set; }
        [J("totalPages")] public string[] TotalPages { get; set; }
        [J("totalEntries")] public string[] TotalEntries { get; set; }
    }

 
}
