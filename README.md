# Multi-tenant Application Demo
This demo is to showcase how a multi-tenant app registration from Tenant A can provision a service principal identity and secret into Tenant B. This is done with the following Microsoft technologies: A multi-tenanted application registration, a serivce principal identity and client secret, a key vault.

For demoing purposes i will also create a storage account in Tenant A to showcase the new credential beind used. This demo is to demonstrate a multi-tenant capability where Tenant A creates and controlls a service principal identity to Tenant B, and places least priviledge RBAC on that identity so Tenant B can access limited technologies in Tenant A.

## Process

### Tenant A
1. set up multi-tenant app to create a service principal
	1. When creating a multi-teant application that will be provisioned in another tenant, please select one of the following options:
		1. Accounts in any organizational directory (Any Azure AD directory - Multitenant) *this is the best option to select if Tenant B is another Entra ID tenant.*
		1. Accounts in any organizational directory (Any Azure AD directory - Multitenant) and personal Microsoft accounts (e.g. Skype, Xbox) *this is best to use if the other tenant is a personal accout.*
		1. include the redirect URI to be https://entra.microsoft.com if you do not have a redirect url on hand.
1. Set up a client secret for that multi-tenant application under the "Certificates & secrets" blade.
1. Update the clientID in the following URL and send Tenant B the link to provision the service principal into their Entra ID tenant: `https://login.microsoftonline.com/organizations/oauth2/v2.0/authorize?response_type=code&response_mode=query&scope=openid&client_id=your_client_ID`
1. Set up the Stroage account, with a container, and place a test blob in the container. (this is not created in this sample code) *Best RBAC for this scenario: Storage Blob Data Contributor*
1. Setup service principal RBAC for the provider storage account.
1. Eventually once Tenant B provides Tenant A with a Keyvault URI, we can look at keyvault-demo code to showcase how to send over the client secret in code.

### Tenant B

1. Provision the new identity in the customer tenant with crafted login be clicking on the link above.
1. Create a Key Vault where the customer can share the service principal identity.
1. Assign RBAC to the new identity to talk to a KV in the customer tenant. *Note Key Vault Secrets Officer is a great option for users writing secrets to another key vault*
1. Inform Tenant A to send over the clientsecret by providing them a Keyvault URI.
1. Once the client secret is retrieved, Tenant B then can craft a call to the providers storage account, we can look at storage-demo to showcase how to use the provided credentials to look at Tenant A's blob.
