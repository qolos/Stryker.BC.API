#// INIT
$currDir = Split-Path -Parent $MyInvocation.MyCommand.Definition
$currDir += "\"
$LogFile = $currDir + "Logs" + "\\" + "test-api-basic.results.txt";
$server = "https://localhost:7228";

#// Functions
Function LogClear {
  $dt = get-date
  write-host "Log Started " + $dt + " in " + $currDir + " on " + $server + "." > $LogFile
}
Function LogMsg {
  param ([string] $msg)
  #// Out-File -FilePath $LogFile $msg
  Write-Output $msg >> $LogFile
}

function test-error
{
    Param (
        [int]$val,
        [string]$obj, 
        [string]$verb, 
        [string]$typ
    )

    if ($val -ne 0)
    {
      $msg = "ERROR($val): " + $verb + ": " + $obj + ": " + $typ
      LogMsg $msg
    }
}


#// MAIN...
LogClear
LogMsg "Current script location: $currDir"
cd $currDir

#// ---------------
#// Object: Log
#// ---------------
#// GET tests
curl.exe -s GET "$server/api/Log" >> $LogFile # Get All
test-error $? "LOG" "GET " "All"
curl.exe -s GET "$server/api/Log/99"  >> $LogFile  # Get individual
test-error $? "LOG" "GET " "Individual"

#// POST tests
curl.exe -s "POST" -H "Content-Type: application/json" -d '{ \"logId\": 32, \"logMessage\": \"Vice-President Karmala failed to visit the border successfully.\", \"logType\": 1, \"logDate\": \"2024-07-26T12:32:46.6579039-05:00\" }'  "$server/api/Log" >> $LogFile
test-error $? "LOG" "POST" 


