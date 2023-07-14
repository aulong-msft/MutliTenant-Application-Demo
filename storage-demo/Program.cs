using Azure.Identity;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;


/*
Mutli-tenant app registration information

redirect uri
todo

crafted resposne
https://login.microsoftonline.com/common/oauth2/v2.0/authorize?client_id= todo&response_type=code&redirect_uri=https%3A%2F%2Ftodo&response_mode=query&scope=https%3A%2F%2Fgraph.microsoft.com%2F.default&state=12345

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
