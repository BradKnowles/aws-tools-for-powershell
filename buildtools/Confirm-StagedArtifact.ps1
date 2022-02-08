<#
.Synopsis
    Validates that the AWS Tools for PowerShell modules (AWSPowerShell and AWSPowerShell.NetCore) are
    both Authenticode signed and the module manifest has the expected version number.

.Description
    Validates that the built AWS Tools for PowerShell modules (for Windows PowerShell and PowerShell 6)
    are both Authenticode signed and have the expected version number in the module manifest and thus can
    be safely released.

.Notes
    The script must be run in a folder that contains subfolders holding the modules to be published
    (i.e. .\AWSPowerShell .\AWSPowerShell.NetCore and .\AWS.Tools).

.Example
    Confirm-StagedArtifact -ExpectedVersion 3.3.283.0
#>
Param (
    # The expected version of the module. This will be verified against
    # the module manifest and the running binary.
    [Parameter(Mandatory = $true, Position = 0)]
    [string]$ExpectedVersion,

    # Determines if signing will be verified. This must be true for production
    # release environments.
    [Parameter()]
    [string] $VerifySigning = "true"
)

function ValidateModule([string]$modulePath, [bool]$verifyChangeLog, [bool]$testVersion, [bool]$signingCheck, [string]$cmdletToTest) {

    $authenticodeSignatureStart = 'SIG # Begin signature block'

    Write-Host "Validating module $modulePath"

    $manifestPath = (Get-ChildItem -Path "$modulePath\*.psd1").FullName
    Write-Host "Verifying version in manifest $manifestPath"

    $manifest = Test-ModuleManifest $manifestPath -ErrorAction 'Stop'

    if ($testVersion) {
        $manifestVersion = $manifest.Version.ToString()
        Write-Host "Found version $manifestVersion"
    
        if ($manifestVersion -eq $ExpectedVersion) {
            Write-Host '...version check - PASS'
        }
        else {
            throw "Manifest has version $manifestVersion, not expected version $ExpectedVersion"
        }
    }

    if ($signingCheck) {
        Write-Host 'Verifying module files are Authenticode-signed'
        $filter = @('*.ps1', '*.psm1', '*.psd1', '*.ps1xml')
        $signableFiles = Get-ChildItem -Path $modulePath\* -Include $filter | Select-Object -ExpandProperty Name

        $signableFiles | ForEach-Object {
            Write-Host "......testing module file $_"
            $fileToTest = Join-Path $modulePath $_
            if (-not (Select-String -Path $fileToTest -Pattern $authenticodeSignatureStart -Quiet)) {
                throw "Failed to locate start of Authenticode signature, $authenticodeSignatureStart, in module file $_."
            }
        }
        Write-Host '...module files signing check - PASS'
    }

    if ($verifyChangeLog) {
        # validate that the change log contains the expected version header in the first line
        $changelogFile = Join-Path $modulePath 'CHANGELOG.txt'

        Write-Host "Verifying $changelogFile contains expected version details"
        $changelogHeader = Get-Content -TotalCount 1 -Path $changelogFile
        Write-Host "...inspecting latest changelog header: $changelogHeader"
        $headerParts = $changelogHeader.Split()
        if ($headerParts[1] -eq $ExpectedVersion) {
            Write-Host '...changelog file version check - PASS'
        }
        else {
            throw 'Changelog does not appear to contain details of the new version'
        }
    }

    Write-Host 'Testing module'
    if (-not ($PSVersionTable.PSVersion.Major -gt 6 -or ($PSVersionTable.PSVersion.Major -eq 6 -And $PSVersionTable.PSVersion.Minor -ge 1))) {
        throw "PowerShell version 6.1 or later is required, found version $($PSVersionTable.PSVersion)"
    }
    $testOutput = pwsh -noprofile -Command "`$ErrorActionPreference = 'Stop' ; Import-Module '$manifestPath' ; $cmdletToTest"
    if ($LastExitCode -eq 0) {
        Write-Host '...module loading - PASS'
    }
    else {
        throw "The module failed to load `n" + $testOutput
    }
}

if (Get-Module AWSPowerShell, AWSPowerShell.NetCore, AWS.Tools.*) {
    throw 'Cannot validate modules if any AWS Tools for PowerShell module is already imported'
}

$signingCheck = $true
if ($VerifySigning -eq 'false') {
    $signingCheck = $false
}

@('AWSPowerShell', 'AWSPowerShell.NetCore') | ForEach-Object {
    try {
        ValidateModule $_ $true $true $signingCheck { Get-S3Bucket -ProfileName test-runner }
        Write-Host "PASSED validation for module $_"
    }
    catch {
        throw "FAILED validation for module $_, error $error"
    }
}

$awsToolsDeploymentPath = Resolve-Path "$PSScriptRoot/AWS.Tools"

Import-Module PowerShellGet

$OldPath = $Env:PSModulePath
$Env:PSModulePath = $Env:PSModulePath + ';' + $awsToolsDeploymentPath

Get-ChildItem $awsToolsDeploymentPath -Directory | ForEach-Object {
    try {
        if ($_.Name -eq 'AWS.Tools.S3') {
            ValidateModule $_ $false $true $signingCheck { Get-S3Bucket -ProfileName test-runner }
        }
        elseif ($_.Name -eq 'AWS.Tools.Installer') {
            ValidateModule $_ $false $false $signingCheck { }
        }
        else {
            ValidateModule $_ $false $true $signingCheck { Get-AWSPowerShellVersion }
        }
        Write-Host "PASSED validation for module $_"
    }
    catch {
        throw "FAILED validation for module $_, error $error"
    }
}

$Env:PSModulePath = $OldPath