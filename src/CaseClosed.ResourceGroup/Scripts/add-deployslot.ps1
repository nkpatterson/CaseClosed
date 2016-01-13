[CmdletBinding()]
Param(
   [Parameter(Mandatory=$True)]
   [string]$AppName,

   [Parameter(Mandatory=$True)]
   [string]$ResourceGroupName,
   
   [Parameter(Mandatory=$True)]
   [string]$SlotName,
   
   [Parameter(Mandatory=$True)]
   [string]$Location,
   
   [Parameter(Mandatory=$True)]
   [string]$AppServicePlan,

   [int]$TrafficPercentage = 25
)

Switch-AzureMode -Name AzureResourceManager

Write-Host "Creating deployment slot: $SlotName for $AppName."
New-AzureWebApp -ResourceGroupName $ResourceGroupName -Name $AppName -SlotName $SlotName -Location $Location -AppServicePlan $AppServicePlan
#Remove-AzureResource -ResourceGroupName $ResourceGroupName -ResourceType Microsoft.Web/sites/slots –Name '$AppName/$SlotName' -ApiVersion 2015-07-01 -Force
Write-Host "Done"