[CmdletBinding()]
Param(
   [Parameter(Mandatory=$True)]
   [string] $EndpointUrl,
   [string] $CurrentVersion,
   [string] $BetaVersion,
   [string] $BetaUrl
)

$url = "https://" + $EndpointUrl + "/api/AppConfig"
$body = @{
	CurrentVersion = $CurrentVersion
	BetaVersion = $BetaVersion
	BetaUrl = $BetaUrl
}

Invoke-RestMethod -Method Post -Uri $url -Body $body