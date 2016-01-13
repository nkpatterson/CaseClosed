[CmdletBinding()]
Param(
   [Parameter(Mandatory=$True)]
   [string]$AppName
)

Write-Host "Stopping web app: $AppName"
Stop-AzureWebsite -Name $AppName
Write-Host "Done"