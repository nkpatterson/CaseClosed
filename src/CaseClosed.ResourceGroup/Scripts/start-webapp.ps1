[CmdletBinding()]
Param(
   [Parameter(Mandatory=$True)]
   [string]$AppName
)

Write-Host "Starting web app: $AppName"
Start-AzureWebsite -Name $AppName
Write-Host "Done"