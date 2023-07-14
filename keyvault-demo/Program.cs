using Azure.Identity;
using  Azure.Security.KeyVault.Secrets;
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        // Tenant ID of the target Azure AD tenant (client tenant) 
        string tenantId = "todo";

        // Client ID of the service principal in the target tenant
        string clientId = "todo";

        // Client secret of the service principal
        string clientSecret = "todo";

        // Name of the secret in key vault
        string secretName = "todo";

        // Key Vault URI
        Uri keyVaultUri = new Uri("todo");

        // Initialize the client credentials
        var clientCredential = new ClientSecretCredential(
            tenantId: tenantId,
            clientId: clientId,
            clientSecret: clientSecret
        );

        // Initialize the secret client
        var secretClient = new SecretClient(keyVaultUri, clientCredential);

        // Create or update the secret in the Key Vault
        KeyVaultSecret createdSecret = await secretClient.SetSecretAsync(secretName, clientSecret);

        Console.WriteLine($"Secret created with name: {createdSecret.Name}");
    }
}
