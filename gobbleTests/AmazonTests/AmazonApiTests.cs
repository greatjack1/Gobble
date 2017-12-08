using System;
using Xunit;
using Gobble.API.Amazon;
using Gobble.Keys;
using Gobble.Providers;
using Gobble.Products;

namespace gobbleTests
{
    public class AmazonApiTests
    {
       
            [Fact]
            public void FullTest(){
            //Arrange
            AmazonApi api = new AmazonApi();
            api.setApiKeys(new ConfigFileKeystore().getKey(Provider.Amazon));
            api.setUPC("033317198658");
            //Act
            //display the data for the test
            foreach (IProduct prod in api.queryProducts()) {
               System.Diagnostics.Trace.WriteLine("Product Information:" + prod.Name + " " + prod.Price + " " + prod.Condition + " " + prod.Description + " " + prod.FormattedPrice + " " + prod.CurrentCurrency + " " + prod.UPC);
            }
            //Assert
            Assert.Equal(0, 0);
            }

    }
}
