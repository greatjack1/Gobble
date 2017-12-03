using System;
using Xunit;
using Gobble.Keys;
using Gobble.Providers;
using System.Collections.Generic;

namespace gobbleTests
{
    public class KeyStoreTests
    {
        [Fact]
        public void TestBasicKeyStore()
        {
            //Arrange
            BasicKeyStore store = new BasicKeyStore();
            Dictionary<String, String> keys = new Dictionary<string, string>();
            keys.Add("TestkeyOne", "12345");
            keys.Add("TestkeyTwo", "12345678");
            store.addKey(Provider.Amazon, keys);
            //Act
            String amazonKeyOne = store.getKey(Provider.Amazon)["TestkeyOne"];
            String amazonKeyTwo = store.getKey(Provider.Amazon)["TestkeyTwo"];
            //Assert
            Assert.Equal(amazonKeyOne, "12345");
            Assert.Equal(amazonKeyTwo, "12345678");
        }

        [Fact]
        public void TestConfigFileKeystore()
        {
            //Arrange
         //Write the config.xml file to test
            //Act
            String amazonKeyOne = store.getKey(Provider.Amazon)["TestkeyOne"];
            String amazonKeyTwo = store.getKey(Provider.Amazon)["TestkeyTwo"];
            //Assert
            Assert.Equal(amazonKeyOne, "12345");
            Assert.Equal(amazonKeyTwo, "12345678");
        }
    }
}
