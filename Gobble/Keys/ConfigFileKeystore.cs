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
        private Dictionary<Provider, String> keys = new Dictionary<Provider, string>();
        private String path = System.IO.Directory.GetCurrentDirectory() + "/keys.xml";
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gobble.Keys.ConfigFileKeystore"/> class.
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
                        keys.Add(prov, node.InnerText);
                        //break out of the for loop since we found a macth
                        break;
                    }
                }
            }
        }
       public string getKey(Provider provider)
        {
            return keys[provider];
        }
    }
}
