[CmdletBinding()]
Param(
   [Parameter(Mandatory=$True)]
   [string]$AppName,
   
   [Parameter(Mandatory=$True)]
   [string]$SlotName
)

Write-Host "Swapping $SlotName with $AppName."
Switch-AzureWebsiteSlot -Name $AppName -Slot1 $SlotName -Force