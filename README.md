# File_System_Cleaner

A simple tool that can be used to clean up one's file system. This cleaning process consists of some menial tasks such as:
* Deleting all empty directories starting from the directory from which the exe is executed
* Deleting the TEMP directory
* Deleting all files older than a given time period from from the directory from which the exe is executed
    
This tool is used on the command line in the following way.

* Remove empty directories (confirmation given before every folder is deleted)</br>
```bat
FileSystemCleaner.exe /empty
```

* Remove empty directories (no confirmation given)</br>
```bat
FileSystemCleaner.exe /empty /quiet
```
