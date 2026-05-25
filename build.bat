@echo off
set CSC=%WINDIR%\Microsoft.NET\Framework64\v4.0.30319\csc.exe
if not exist "dist" mkdir "dist"
"%CSC%" /nologo /target:winexe /optimize+ /win32icon:shutdown_timer.ico /out:"dist\Tiny Windows Shutdown Scheduler.exe" ShutdownTimer.cs
