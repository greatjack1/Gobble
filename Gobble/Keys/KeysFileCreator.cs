using Gobble.Providers;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;

namespace Gobble.Keys
{
    /// <summary>
    /// A helper class to create the keys.xml file require by the application
    /// </summary>
    class KeysFileCreator
    {
        private String path = Directory.GetCurrentDirectory() + "\\keys.xml";
        private List<Provider> providers;
        private List<Dictionary<String, String>> keys;
        public KeysFileCreator() {

        }
        /// <summary>
        /// Use this method to add keys for providers for the xml file that will be printed
        /// </summary>
        /// <param name="provider">The name of the provider from Gobble.Providers to add keys for</param>
        /// <param name="keys">The dictionary of keys to add for the specified provider</param>
        public void addProviderAndKeys(List<Provider> provider, List<Dictionary<String,String>> keys) {
            this.keys = keys;
            this.providers = provider;
        }
        /// <summary>
        /// This method creates the actual config file for the application file to use
        /// </summary>
        /// <returns>true if the file was able to be created, false if we were unable to create the file</returns>
        public Boolean createKeysFile() {
            //check if keys or provider is null, and if they are then return false since we cant write the xml file then
            if (keys == null||providers==null) {
                return false;
            }
            //declare and setup the xml document
            XmlDocument doc = new XmlDocument();
            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);
//add in the keys element
            XmlElement element1 = doc.CreateElement(string.Empty, "keys", string.Empty);
            doc.AppendChild(element1);
            //add in each of the providers and their keys
            int numUpTo = 0;
            foreach (Provider prov in providers)
            { 
                XmlElement subElement = doc.CreateElement(string.Empty, prov.ToString(), string.Empty);
                element1.AppendChild(element1);
                foreach (KeyValuePair<string, string> entry in keys[numUpTo])
                {
                    
                }
                numUpTo++;
            }
        }
    }
}
