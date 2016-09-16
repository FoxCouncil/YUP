@echo off

if not "%1" == "_Final" goto skip

call backup.bat
call merge.bat %1

echo Final.bat Complete
goto end

:skip
echo Skipping Final
goto end

:end
echo.
echo.