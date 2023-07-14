using Azure.Identity;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;


/*
Mutli-tenant app registration information

crafted response: make sure to update the ClientID in the URL
`https://login.microsoftonline.com/organizations/oauth2/v2.0/authorize?response_type=code&response_mode=query&scope=openid&client_id=your_client_ID`
*/
class Program
{
    static void Main(string[] args)
    {
        // Tenant ID of the target Azure AD tenant 
        string tenantId = "todo";

        // Client ID of the service principal in the target tenant created from multi-tenanted app
        string clientId = "todo"; 

        // Client secret of the service principal created by multi-tenanted app
        string clientSecret = "todo";

        // Storage account name in target tenant
        string storageAccountName = "todo";

        // Storage container name in target tenant
        string containerName = "todo";

        // Initialize the client credentials
        var clientCredential = new ClientSecretCredential(
            tenantId: tenantId,
            clientId: clientId,
            clientSecret: clientSecret
        );

        // Create a blob service client using the client credentials
        var blobServiceClient = new BlobServiceClient(
            new Uri($"https://{storageAccountName}.blob.core.windows.net"),
            clientCredential
        );

        // Get a reference to the container
        var containerClient = blobServiceClient.GetBlobContainerClient(containerName);

        // List all blobs in the container
        foreach (BlobItem blobItem in containerClient.GetBlobs())
        {
            Console.WriteLine($"Blob Name: {blobItem.Name}");
        }
    }
}
