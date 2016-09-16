@echo off
echo.
echo.
echo =======[ Backing Up YUP ]=========================================
cd ..\..
YUP\Tools\7za.exe a -r -tzip YUP.zip YUP\*
cd YUP\Tools
echo =======[ COMPLETE ]===============================
echo.