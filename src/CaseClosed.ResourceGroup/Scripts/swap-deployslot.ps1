[CmdletBinding()]
Param(
	[Parameter(Mandatory=$True)]
	[string]$ResourceGroupName,

   [Parameter(Mandatory=$True)]
   [string]$AppName,
   
   [Parameter(Mandatory=$True)]
   [string]$SlotName
)

Write-Host "Swapping $SlotName with $AppName."
Invoke-AzureRmResourceAction -ResourceGroupName $ResourceGroupName -ResourceType Microsoft.Web/sites/slots -ResourceName "$AppName/$SlotName" -Action slotsswap -Parameters @{targetSlot="production"} -ApiVersion 2015-08-01 -Force