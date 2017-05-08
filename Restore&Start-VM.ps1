$password = convertto-securestring -AsPlainText -Force -String 7Dintr-olovitura
$credentials = New-Object System.Management.Automation.PSCredential("TestServer\Administrator",$password)
Invoke-Command -ComputerName TestServer -Credential $credentials -ScriptBlock { $VMsArray = @('IE9-Win7', 'IE10-Win7'); 
Foreach ($VM in $VMsArray) { $name = $VM.ToString(); 
Restore-VMSnapshot -Name 'ConfiguredJenkinsSlave' -VMName $name -Confirm:$false; Start-VM $name } }