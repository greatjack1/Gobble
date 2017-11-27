using System;

namespace Gobble
{
    /// <summary>
    /// This class represents a product in the api.
    /// Products contain all of the importent information of an Item.
    /// This includes the item name, description, price, upc etc.
    /// It is used as a commen base class for all kinds of products.
    /// </summary>
    public abstract class Product
    {
        public String ItemName { get; set; }
        public String ItemDescription { get; set; }
        public double ItemPrice { get; set; }
        public String ItemUPC { get; set; }
    }


}
