[CmdletBinding()]
Param(
  [Parameter(Mandatory=$True,Position=1)]
   [string]$ResourceGroupName,
	
   [Parameter(Mandatory=$True)]
   [string]$AppName
)

Stop-AzureRmWebApp -ResourceGroupName $ResourceGroupName -Name $AppName