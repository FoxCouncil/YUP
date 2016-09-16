@echo off
cd ..\YUP\bin\_Final\
echo.
echo =======[ Starting YUP Merge ]======================================
echo  * This merge is latex safe.
..\..\..\Tools\ILMerge /out:YUPapp.exe YUP.exe Interop.ShockwaveFlashObjects.dll AxInterop.ShockwaveFlashObjects.dll
echo =======[ COMPLETE ]================================================
echo.
echo.
echo =======[ Deleting Used Objects ]===================================
echo  * Deleting is dangerous.
echo  * Children should be adult supervised.
rem del AxInterop.ShockwaveFlashObjects.dll
rem del Interop.ShockwaveFlashObjects.dll
del YUP.exe
echo =======[ COMPLETE ]================================================
echo.
echo.
echo =======[ Moving Original EXE ]=====================================
echo  * Move along home.
move YUPapp.exe YUP.exe
echo =======[ COMPLETE ]================================================