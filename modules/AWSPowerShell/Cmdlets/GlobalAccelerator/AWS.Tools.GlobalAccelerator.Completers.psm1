# Auto-generated argument completers for parameters of SDK ConstantClass-derived type used in cmdlets.
# Do not modify this file; it may be overwritten during version upgrades.

$psMajorVersion = $PSVersionTable.PSVersion.Major
if ($psMajorVersion -eq 2) 
{ 
	Write-Verbose "Dynamic argument completion not supported in PowerShell version 2; skipping load."
	return 
}

# PowerShell's native Register-ArgumentCompleter cmdlet is available on v5.0 or higher. For lower
# version, we can use the version in the TabExpansion++ module if installed.
$registrationCmdletAvailable = ($psMajorVersion -ge 5) -Or !((Get-Command Register-ArgumentCompleter -ea Ignore) -eq $null)

# internal function to perform the registration using either cmdlet or manipulation
# of the options table
function _awsArgumentCompleterRegistration()
{
    param
    (
        [scriptblock]$scriptBlock,
        [hashtable]$param2CmdletsMap
    )

    if ($registrationCmdletAvailable)
    {
        foreach ($paramName in $param2CmdletsMap.Keys)
        {
             $args = @{
                "ScriptBlock" = $scriptBlock
                "Parameter" = $paramName
            }

            $cmdletNames = $param2CmdletsMap[$paramName]
            if ($cmdletNames -And $cmdletNames.Length -gt 0)
            {
                $args["Command"] = $cmdletNames
            }

            Register-ArgumentCompleter @args
        }
    }
    else
    {
        if (-not $global:options) { $global:options = @{ CustomArgumentCompleters = @{ }; NativeArgumentCompleters = @{ } } }

        foreach ($paramName in $param2CmdletsMap.Keys)
        {
            $cmdletNames = $param2CmdletsMap[$paramName]

            if ($cmdletNames -And $cmdletNames.Length -gt 0)
            {
                foreach ($cn in $cmdletNames)
                {
                    $fqn =  [string]::Concat($cn, ":", $paramName)
                    $global:options['CustomArgumentCompleters'][$fqn] = $scriptBlock
                }
            }
            else
            {
                $global:options['CustomArgumentCompleters'][$paramName] = $scriptBlock
            }
        }

        $function:tabexpansion2 = $function:tabexpansion2 -replace 'End\r\n{', 'End { if ($null -ne $options) { $options += $global:options} else {$options = $global:options}'
    }
}

# To allow for same-name parameters of different ConstantClass-derived types 
# each completer function checks on command name concatenated with parameter name.
# Additionally, the standard code pattern for completers is to pipe through 
# sort-object after filtering against $wordToComplete but we omit this as our members 
# are already sorted.

# Argument completions for service AWS Global Accelerator


$GACL_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.GlobalAccelerator.ClientAffinity
        {
            ($_ -eq "New-GACLListener/ClientAffinity") -Or
            ($_ -eq "Update-GACLListener/ClientAffinity")
        }
        {
            $v = "NONE","SOURCE_IP"
            break
        }

        # Amazon.GlobalAccelerator.HealthCheckProtocol
        {
            ($_ -eq "New-GACLEndpointGroup/HealthCheckProtocol") -Or
            ($_ -eq "Update-GACLEndpointGroup/HealthCheckProtocol")
        }
        {
            $v = "HTTP","HTTPS","TCP"
            break
        }

        # Amazon.GlobalAccelerator.IpAddressType
        {
            ($_ -eq "New-GACLAccelerator/IpAddressType") -Or
            ($_ -eq "New-GACLCustomRoutingAccelerator/IpAddressType") -Or
            ($_ -eq "Update-GACLAccelerator/IpAddressType") -Or
            ($_ -eq "Update-GACLCustomRoutingAccelerator/IpAddressType")
        }
        {
            $v = "DUAL_STACK","IPV4"
            break
        }

        # Amazon.GlobalAccelerator.Protocol
        {
            ($_ -eq "New-GACLListener/Protocol") -Or
            ($_ -eq "Update-GACLListener/Protocol")
        }
        {
            $v = "TCP","UDP"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$GACL_map = @{
    "ClientAffinity"=@("New-GACLListener","Update-GACLListener")
    "HealthCheckProtocol"=@("New-GACLEndpointGroup","Update-GACLEndpointGroup")
    "IpAddressType"=@("New-GACLAccelerator","New-GACLCustomRoutingAccelerator","Update-GACLAccelerator","Update-GACLCustomRoutingAccelerator")
    "Protocol"=@("New-GACLListener","Update-GACLListener")
}

_awsArgumentCompleterRegistration $GACL_Completers $GACL_map

$GACL_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.GACL.$($commandName.Replace('-', ''))Cmdlet]"
    if (-not $cmdletType) {
        return
    }
    $awsCmdletAttribute = $cmdletType.GetCustomAttributes([Amazon.PowerShell.Common.AWSCmdletAttribute], $false)
    if (-not $awsCmdletAttribute) {
        return
    }
    $type = $awsCmdletAttribute.SelectReturnType
    if (-not $type) {
        return
    }

    $splitSelect = $wordToComplete -Split '\.'
    $splitSelect | Select-Object -First ($splitSelect.Length - 1) | ForEach-Object {
        $propertyName = $_
        $properties = $type.GetProperties(('Instance', 'Public', 'DeclaredOnly')) | Where-Object { $_.Name -ieq $propertyName }
        if ($properties.Length -ne 1) {
            break
        }
        $type = $properties.PropertyType
        $prefix += "$($properties.Name)."

        $asEnumerableType = $type.GetInterface('System.Collections.Generic.IEnumerable`1')
        if ($asEnumerableType -and $type -ne [System.String]) {
            $type =  $asEnumerableType.GetGenericArguments()[0]
        }
    }

    $v = @( '*' )
    $properties = $type.GetProperties(('Instance', 'Public', 'DeclaredOnly')).Name | Sort-Object
    if ($properties) {
        $v += ($properties | ForEach-Object { $prefix + $_ })
    }
    $parameters = $cmdletType.GetProperties(('Instance', 'Public')) | Where-Object { $_.GetCustomAttributes([System.Management.Automation.ParameterAttribute], $true) } | Select-Object -ExpandProperty Name | Sort-Object
    if ($parameters) {
        $v += ($parameters | ForEach-Object { "^$_" })
    }

    $v |
        Where-Object { $_ -match "^$([System.Text.RegularExpressions.Regex]::Escape($wordToComplete)).*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$GACL_SelectMap = @{
    "Select"=@("Add-GACLCustomRoutingEndpoint",
               "Add-GACLEndpoint",
               "Start-GACLAdvertisingByoipCidr",
               "Enable-GACLCustomRoutingTraffic",
               "New-GACLAccelerator",
               "New-GACLCrossAccountAttachment",
               "New-GACLCustomRoutingAccelerator",
               "New-GACLCustomRoutingEndpointGroup",
               "New-GACLCustomRoutingListener",
               "New-GACLEndpointGroup",
               "New-GACLListener",
               "Remove-GACLAccelerator",
               "Remove-GACLCrossAccountAttachment",
               "Remove-GACLCustomRoutingAccelerator",
               "Remove-GACLCustomRoutingEndpointGroup",
               "Remove-GACLCustomRoutingListener",
               "Remove-GACLEndpointGroup",
               "Remove-GACLListener",
               "Disable-GACLCustomRoutingTraffic",
               "Remove-GACLByoipCidrProvision",
               "Get-GACLAccelerator",
               "Get-GACLAcceleratorAttribute",
               "Get-GACLCrossAccountAttachment",
               "Get-GACLCustomRoutingAccelerator",
               "Get-GACLCustomRoutingAcceleratorAttribute",
               "Get-GACLCustomRoutingEndpointGroup",
               "Get-GACLCustomRoutingListener",
               "Get-GACLEndpointGroup",
               "Get-GACLListener",
               "Get-GACLAcceleratorList",
               "Get-GACLByoipCidrList",
               "Get-GACLCrossAccountAttachmentList",
               "Get-GACLCrossAccountResourceAccountList",
               "Get-GACLCrossAccountResourceList",
               "Get-GACLCustomRoutingAcceleratorList",
               "Get-GACLCustomRoutingEndpointGroupList",
               "Get-GACLCustomRoutingListenerList",
               "Get-GACLCustomRoutingPortMappingList",
               "Get-GACLCustomRoutingPortMappingsByDestinationList",
               "Get-GACLEndpointGroupList",
               "Get-GACLListenerList",
               "Get-GACLResourceTag",
               "Add-GACLByoipCidrProvision",
               "Remove-GACLCustomRoutingEndpoint",
               "Remove-GACLEndpoint",
               "Add-GACLResourceTag",
               "Remove-GACLResourceTag",
               "Update-GACLAccelerator",
               "Update-GACLAcceleratorAttribute",
               "Update-GACLCrossAccountAttachment",
               "Update-GACLCustomRoutingAccelerator",
               "Update-GACLCustomRoutingAcceleratorAttribute",
               "Update-GACLCustomRoutingListener",
               "Update-GACLEndpointGroup",
               "Update-GACLListener",
               "Stop-GACLAdvertisingByoipCidr")
}

_awsArgumentCompleterRegistration $GACL_SelectCompleters $GACL_SelectMap

