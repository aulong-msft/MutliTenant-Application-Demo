# Mult-tenant Application Demo
This demo is to showcase how 

## Steps 

1. set up multi-tenant app to create a service principal
	1. http://www.lseg.com as the redirect URI
1. Set up a client secret
	1. go to the multi-tenant application and create a client secret
1. Set up the service principal RBAC for the provider storage account
1. Provision the new identity in the customer tenant with crafted login
1. Assign RBAC to the new identity to talk to a KV in the customer tenant
1. Provider sends over the client secret to the customer in a call to the customers keyvault
1. The customer then can craft a call to the providers storage account