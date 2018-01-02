using System;
namespace Gobble.Products
{
    public interface IProduct
    {
        String Name { get; set; }
        String Description { get; set; }
        String Condition { get; set; }
        double Price { get; set; }
        String FormattedPrice { get; set; }
        String CurrentCurrency { get; set; }
        String UPC { get; set; }
        String Url { get; set; }
        String Merchant { get; set; }
    }
}
