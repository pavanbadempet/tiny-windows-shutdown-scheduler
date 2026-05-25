# Tiny Windows Shutdown Scheduler

A tiny Windows GUI app for scheduling shutdown and related power actions.

Tiny Windows Shutdown Scheduler is a portable shutdown timer for Windows. It is built as a small native WinForms executable with no Python, Electron, installer, or background service.

## Features

- Hours and minutes input
- Quick presets: 15 min, 30 min, 1 hour, 2 hours, Tonight
- Actions: Shutdown, Restart, Sleep, Hibernate, Lock, Log off
- Confirmation before scheduling
- Shows exact action time
- Live countdown after scheduling
- Cancel scheduled shutdown/restart, or cancel in-app timers before they fire
- Small native Windows executable, no terminal window

## Download

Use the executable from the latest GitHub Release:

```text
Tiny Windows Shutdown Scheduler.exe
```

The app is portable. Download the EXE, run it, choose an action and delay, then confirm.

## Build EXE

Requires the .NET Framework C# compiler included with Windows.

Build:

```powershell
build.bat
```

The executable will be created at:

```text
dist\Tiny Windows Shutdown Scheduler.exe
```

## Notes

This app uses Windows' built-in commands for power actions:

- `shutdown /s /t <seconds>` to schedule shutdown
- `shutdown /r /t <seconds>` to schedule restart
- `shutdown /a` to cancel a pending shutdown
- `shutdown /h` to hibernate
- `rundll32 user32.dll,LockWorkStation` to lock

Save your work before scheduling a power action.

Shutdown and restart timers are scheduled through Windows, so they can still run after closing the app. Sleep, hibernate, lock, and log off timers are handled by the app, so keep it open until the timer finishes.

## Keywords

windows shutdown timer, windows shutdown scheduler, portable shutdown timer, restart timer, sleep timer, hibernate timer, lock timer, tiny windows utility

## License

MIT
