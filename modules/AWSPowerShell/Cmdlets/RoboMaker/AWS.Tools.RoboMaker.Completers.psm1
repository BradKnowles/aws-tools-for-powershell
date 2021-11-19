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

# Argument completions for service AWS RoboMaker


$ROBO_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.RoboMaker.Architecture
        "New-ROBORobot/Architecture"
        {
            $v = "ARM64","ARMHF","X86_64"
            break
        }

        # Amazon.RoboMaker.ComputeType
        "New-ROBOSimulationJob/Compute_ComputeType"
        {
            $v = "CPU","GPU_AND_CPU"
            break
        }

        # Amazon.RoboMaker.FailureBehavior
        "New-ROBOSimulationJob/FailureBehavior"
        {
            $v = "Continue","Fail"
            break
        }

        # Amazon.RoboMaker.RenderingEngineType
        {
            ($_ -eq "New-ROBOSimulationApplication/RenderingEngine_Name") -Or
            ($_ -eq "Update-ROBOSimulationApplication/RenderingEngine_Name")
        }
        {
            $v = "OGRE"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$ROBO_map = @{
    "Architecture"=@("New-ROBORobot")
    "Compute_ComputeType"=@("New-ROBOSimulationJob")
    "FailureBehavior"=@("New-ROBOSimulationJob")
    "RenderingEngine_Name"=@("New-ROBOSimulationApplication","Update-ROBOSimulationApplication")
}

_awsArgumentCompleterRegistration $ROBO_Completers $ROBO_map

$ROBO_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.ROBO.$($commandName.Replace('-', ''))Cmdlet]"
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

$ROBO_SelectMap = @{
    "Select"=@("Remove-ROBODeleteWorld",
               "Get-ROBOSimulationJobList",
               "Stop-ROBODeploymentJob",
               "Stop-ROBOSimulationJob",
               "Stop-ROBOSimulationJobBatch",
               "Stop-ROBOWorldExportJob",
               "Stop-ROBOWorldGenerationJob",
               "New-ROBODeploymentJob",
               "New-ROBOFleet",
               "New-ROBORobot",
               "New-ROBORobotApplication",
               "New-ROBORobotApplicationVersion",
               "New-ROBOSimulationApplication",
               "New-ROBOSimulationApplicationVersion",
               "New-ROBOSimulationJob",
               "New-ROBOWorldExportJob",
               "New-ROBOWorldGenerationJob",
               "New-ROBOWorldTemplate",
               "Remove-ROBOFleet",
               "Remove-ROBORobot",
               "Remove-ROBORobotApplication",
               "Remove-ROBOSimulationApplication",
               "Remove-ROBOWorldTemplate",
               "Unregister-ROBORobot",
               "Get-ROBODeploymentJob",
               "Get-ROBOFleet",
               "Get-ROBORobot",
               "Get-ROBORobotApplication",
               "Get-ROBOSimulationApplication",
               "Get-ROBOSimulationJob",
               "Get-ROBOSimulationJobBatch",
               "Get-ROBOWorld",
               "Get-ROBOWorldExportJob",
               "Get-ROBOWorldGenerationJob",
               "Get-ROBOWorldTemplate",
               "Get-ROBOWorldTemplateBody",
               "Get-ROBODeploymentJobList",
               "Get-ROBOFleetList",
               "Get-ROBORobotApplicationList",
               "Get-ROBORobotList",
               "Get-ROBOSimulationApplicationList",
               "Get-ROBOSimulationJobBatchList",
               "Get-ROBOSimulationJobSummary",
               "Get-ROBOResourceTag",
               "Get-ROBOWorldExportJobList",
               "Get-ROBOWorldGenerationJobList",
               "Get-ROBOWorldList",
               "Get-ROBOWorldTemplateList",
               "Register-ROBORobot",
               "Restart-ROBOSimulationJob",
               "Start-ROBOSimulationJobBatch",
               "Sync-ROBODeploymentJob",
               "Add-ROBOResourceTag",
               "Remove-ROBOResourceTag",
               "Update-ROBORobotApplication",
               "Update-ROBOSimulationApplication",
               "Update-ROBOWorldTemplate")
}

_awsArgumentCompleterRegistration $ROBO_SelectCompleters $ROBO_SelectMap

