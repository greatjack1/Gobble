using System;
namespace Gobble.Products
{
    public interface IProduct
    {
        String getName();
        String getDescription();
        double getPrice();
        String getCurrenCurrency();
        String getUPC();

    }
}
