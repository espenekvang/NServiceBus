using NServiceBus.Config;
using NServiceBus.Config.ConfigurationSource;

namespace SecurityServiceAdapter
{
    public class ConfigOverride : IProvideConfiguration<RijndaelEncryptionServiceConfig>
    {
        public RijndaelEncryptionServiceConfig GetConfiguration()
        {
            return new RijndaelEncryptionServiceConfig
                {
                    Key = "gdDbqRpqdRbTs3mhdZh9qCaDaxJX1+e7"
                };
        }
    }
}
