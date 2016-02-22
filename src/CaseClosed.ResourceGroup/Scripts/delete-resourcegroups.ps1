[CmdletBinding()]
Param(
   [Parameter(Mandatory=$True)]
   [string]$ResourceGroupNamePattern
)

Switch-AzureMode -Name AzureServiceManagement

Write-Output "Finding resource groups starting with: $ResourceGroupNamePattern..."

$rgs = Get-AzureRmResourceGroup -Name $ResourceGroupNamePattern | Select-Object -Property ResourceGroupName

if (!$rgs) {
	Write-Output "Did not find any matching resource groups."
}
else {
	Write-Output "Found $(rgs.Count) groups: " + $rgs -join ", "

	ForEach ($rg in $rgs)  {
		Write-Output "Deleting: $rg..."

		# TODO: Remove-AzureRmResourceGroup -Name $rg
	}
}