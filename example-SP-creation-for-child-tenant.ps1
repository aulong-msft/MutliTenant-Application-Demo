#example how to grant a service principal in a child tenant whose application settings are in a parent tenant

$TenantId = "" #remote child's tenant ID
$AppID = "" #client id generated from the app registration from the parent tenant

# Login - needs at least Cloud Application Administrator role
Connect-MgGraph -Scopes "Application.ReadWrite.All" -TenantId $TenantId
New-MgServicePrincipal -AppId $AppId

# https://learn.microsoft.com/powershell/module/microsoft.graph.applications/new-mgserviceprincipal