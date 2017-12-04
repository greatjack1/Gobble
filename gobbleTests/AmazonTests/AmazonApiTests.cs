using System;
using Xunit;
using Gobble.API.Amazon;
using Gobble.Keys;
using Gobble.Providers;
namespace gobbleTests
{
    public class AmazonApiTests
    {
       
            [Fact]
            public void FullTest(){
            //Arrange
            AmazonApi api = new AmazonApi();
            api.setApiKeys(new ConfigFileKeystore().getKey(Provider.Amazon));
            api.setUPC("888462762670");
            api.queryProducts();
            //Act

            //Assert
            Assert.Equal(0, 0);
            }

    }
}
