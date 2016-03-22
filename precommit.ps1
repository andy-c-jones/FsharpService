.paket\paket.bootstrapper.exe
if($lastExitCode -eq 1){
    throw "paket bootstrap failed"
}

.paket\paket.exe restore
if($lastExitCode -eq 1) {
    throw "paket bootstrap failed"
}

packages\FAKE\tools\FAKE.exe build.fsx