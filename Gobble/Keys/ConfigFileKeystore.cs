using System;
using System.Collections.Generic;
using Gobble.Providers;
using System.Xml;
using System.IO;
namespace Gobble.Keys
{
    /// <summary>
    /// Config file keystore.
    /// A Keystore for api keys that relies on a xml file to provider provider keys
    /// </summary>
    public class ConfigFileKeystore : IApiKeystore
    {
        private Dictionary<Provider, Dictionary<String, String>> keys = new Dictionary<Provider, Dictionary<String,String>>();
        private String path = System.IO.Directory.GetCurrentDirectory() + "/keys.xml";
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gobble.Keys.ConfigFileKeystore"/> class. Using the default
        /// path which is the currentdirectory with a keys.xml file
        /// </summary>
        public ConfigFileKeystore()
        {
            
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gobble.Keys.ConfigFileKeystore"/> class.
        /// </summary>
        /// <param name="filePath">The path to the configuration file</param>
        public ConfigFileKeystore(String filePath)
        {
            path = filePath;
        }

        private void readKeys(){
            //if the path doesnt exist through a file not found exception
            if(!Directory.Exists(path)){
                throw new FileNotFoundException();
            }
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            foreach(XmlNode node in doc.DocumentElement.ChildNodes){
                //if the element name a provider, then add that provider and the key to the dictionary
                foreach(Provider prov in Enum.GetValues(typeof(Provider))){
                    if(node.Name==prov.ToString()){
                        //create a dictionary to hold the keyname and values for that provider
                        Dictionary<String, String> providerKeys = new Dictionary<string, string>();
                        //loop through each node to get a list of keynames and values
                        foreach (XmlNode childNode in node.ChildNodes) {
                            providerKeys.Add(childNode.Name, childNode.InnerText);
                        }
                        //add the keys and the provider name to the dictionary
                        keys.Add(prov, providerKeys);
                        //break out of the for loop since we found a macth
                        break;
                    }
                }
            }
        }
       public Dictionary<String,String> getKey(Provider provider)
        {
            return keys[provider];
        }
    }
}
