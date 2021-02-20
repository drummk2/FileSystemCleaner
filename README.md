# FileSystemCleaner

A simple tool that can be used to clean up one's file system. This cleaning process consists of some menial tasks such as:
* Deleting all duplicate files starting from the directory from which the exe is executed
* Deleting all empty directories starting from the directory from which the exe is executed
* Deleting the TEMP directory
* Deleting all files that have not been modified in three months (planned to be a configurable time period in a future release) from from the directory from which the exe is executed
    
This tool is used on the command line in the following way.

* Run all commands
```bat
FileSystemCleaner.exe /all
```

* Remove duplicate files (confirmation needed before every folder is deleted)</br>
```bat
FileSystemCleaner.exe /duplicate
```

* Remove empty directories (confirmation needed before every folder is deleted)</br>
```bat
FileSystemCleaner.exe /empty
```

* Remove empty directories (no confirmation needed)</br>
```bat
FileSystemCleaner.exe /empty /quiet
```

* Remove all old files on the file system (confirmation needed before every delete)</br>
```bat
FileSystemCleaner.exe /old /quiet
```

* Remove all old files on the file system (no confirmation needed)</br>
```bat
FileSystemCleaner.exe /old
```

* Clear the TEMP directory
```bat
FileSystemCleaner.exe /temp
```
