cd "C:\Development\EM\PDFProducer"
Get-ChildItem -include bin,obj,packages,'.vs',TestResults -Force -Recurse | foreach ($_) { remove-item $_.fullname -Force -Recurse -ErrorAction SilentlyContinue -Verbose}