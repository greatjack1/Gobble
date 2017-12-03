using System;
using Xunit;
using Gobble.Keys;
using Gobble.Providers;
using System.Collections.Generic;
using System.IO;
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
        public void TestKeysFileCreator()
        {
            //Arrange
            KeysFileCreator creator = new Gobble.Keys.KeysFileCreator();
            Dictionary<String, String> keys = new Dictionary<string, string>();
            keys.Add("testkeyone", "12345");
            keys.Add("testkeytwo", "123456789");
            List<Dictionary<String, String>> keysList = new List<Dictionary<string, string>>();
            keysList.Add(keys);
            List<Provider> providers = new List<Provider>();
            providers.Add(Provider.Amazon);
            creator.addProviderAndKeys(providers, keysList);
            //Act
            bool created = creator.createKeysFile();
            //Assert
            Assert.Equal(created, true);
        }

        [Fact]
        public void TestConfigFileKeystore()
        {
            //Arrange
            //Write the keys.xml file to test
            String path = Directory.GetCurrentDirectory() + "\\keys.xml";
            StreamWriter writer = new StreamWriter(path,false);
            writer.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            writer.WriteLine("<keys><Amazon><testKey>12345</testKey><testKey2>123456789</testKey2></Amazon></keys>");
            writer.Close();
            writer.Dispose();
            //Act
          ConfigFileKeystore store = new ConfigFileKeystore();
            String testKey1 = store.getKey(Provider.Amazon)["testKey"];
            String testKey2 = store.getKey(Provider.Amazon)["testKey2"];
            //cleanup
            //delete the file since the xml was loaded
            File.Delete(path);
            //Assert
            Assert.Equal(testKey1, "12345");
            Assert.Equal(testKey2, "123456789");
        }
    }
}
