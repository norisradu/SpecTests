$password = convertto-securestring -AsPlainText -Force -String 7Dintr-olovitura
$credentials = New-Object System.Management.Automation.PSCredential("TestServer\Administrator",$password)
Invoke-Command -ComputerName TestServer -Credential $credentials -ScriptBlock { Restore-VMSnapshot -Name 'LoggedIn' -VMName 'IE10-Win7' -Confirm:$false ; Start-VM IE10-Win7}
net use \\IE10Win7 /user:Administrator 123456
$From = "\\DESKTOP-901LVC0\C$\Program Files (x86)\7-Zip\*"
$From2 = "\\DESKTOP-901LVC0\C$\Users\Junior Mind\Desktop\SDLTradosStudio2017_5746.exe"
$To = "\\IE10Win7\C$\7-Zip"
Copy-Item -Path $From -Destination $To
Copy-Item -Path $From2 -Destination $To
$virtualMachinePassword = convertto-securestring -AsPlainText -Force -String 123456
$virtualMachineCredentials = New-Object System.Management.Automation.PSCredential("Administrator",$virtualMachinePassword)
Invoke-Command -ComputerName IE10Win7 -Credential $virtualMachineCredentials -ScriptBlock { C:\7-Zip\7z.exe x "C:\7-Zip\SDLTradosStudio2017_5746.exe" -o"C:\temp" }
&"C:\Users\Junior Mind\Desktop\PSTools\PsExec.exe" \\IE10Win7 msiexec.exe /i C:\temp\SDLTradosStudio2017\modules\TranslationStudio5.msi /qn /l*v C:\temp\SDLTradosStudio2017\modules\InstallationLog.log
$From3 = "\\DESKTOP-901LVC0\C$\Jenkins\workspace\Trados Installer\UnitTestProject1\UnitTestProject1\bin\Debug\*"
Copy-Item -Path $From3 -Destination $To
$From4 = "\\DESKTOP-901LVC0\C$\Jenkins\workspace\Trados Installer\UnitTestProject1\packages\SpecRun.Runner.1.5.2\tools\*"
Copy-Item -Path $From4 -Destination $To
&"C:\Users\Junior Mind\Desktop\PSTools\PsExec.exe" -u Administrator -p 123456 -i 2 \\IE10Win7 C:\7-Zip\SpecRun.exe run "C:\7-Zip\UnitTestProject1.dll"