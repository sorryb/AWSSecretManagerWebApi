namespace TestSecretManagerWebApi
{
    public static class ExtensionsConfiguration
    {
        public static void AddAmazonSecretsManager(this IConfigurationBuilder configurationBuilder,
                                string region,
                                string secretName)
        {
            var configurationSource =
                    new AmazonSecretsManagerConfigurationSource(region, secretName);

            configurationBuilder.Add(configurationSource);
        }
    }
}
