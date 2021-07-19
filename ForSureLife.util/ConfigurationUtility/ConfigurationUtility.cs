using System;
using System.Collections.Generic;
using System.Text;

namespace ForSureLife.util.ConfigurationUtility
{
    public class ConfigurationUtility
    {
        public static string GetSetting(string key)
        {
            return "SomeValue";
       /*     if (!string.IsNullOrEmpty(CloudConfigurationManager.GetSetting("EnableEncryption"))
                && CloudConfigurationManager.GetSetting("EnableEncryption") == "true"
                && EncryptedConfiguration.Fields.Contains(key))
            {
                var encryptedValue = CloudConfigurationManager.GetSetting(key);
                var encryptionCert = CloudConfigurationManager.GetSetting("EncryptionCertThumbprint");
                var encryptionKey = CloudConfigurationManager.GetSetting("EncryptionKey");

                return EncryptionUtility.Decrypt(encryptedValue, encryptionCert, encryptionKey);
            }
            else
            {
                return CloudConfigurationManager.GetSetting(key);
            }*/
        }
    }
}
