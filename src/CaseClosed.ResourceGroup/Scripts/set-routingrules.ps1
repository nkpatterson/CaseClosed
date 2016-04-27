[CmdletBinding()]
Param(
	[Parameter(Mandatory=$True)]
	[string]$AppName,

	[Parameter(Mandatory=$True)]
	[string]$SlotName,

	[Parameter(Mandatory=$True)]
	[int]$ReroutePercentage
)

$rule = New-Object Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.WebEntities.RampUpRule
$rule.ActionHostName = "$AppName-$SlotName.azurewebsites.net"
$rule.ReroutePercentage = $ReroutePercentage
$rule.Name = "$SlotName reroute rules"

Set-AzureWebsite $AppName -Slot Production -RoutingRules $rule