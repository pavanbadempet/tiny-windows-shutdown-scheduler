# Tiny Windows Shutdown Scheduler

**Tiny Windows Shutdown Scheduler** is a small portable **Windows shutdown timer** and **Windows shutdown scheduler** for shutdown, restart, sleep, hibernate, lock, and log off actions.

It is designed for people who want a fast, simple, no-install Windows power timer: download one EXE, choose a delay, confirm, and let Windows handle the action.

## Download

Download the latest release:

[Tiny Windows Shutdown Scheduler.exe](https://github.com/pavanbadempet/tiny-windows-shutdown-scheduler/releases/latest)

The app is portable. No installer, no Python, no Electron, no account, no background service.

## Why Use It

- Tiny native Windows executable, about 29 KB
- Simple Windows shutdown timer with hours and minutes
- Restart timer, sleep timer, hibernate timer, lock timer, and log off timer
- Presets for 15 minutes, 30 minutes, 1 hour, 2 hours, and tonight
- Confirmation before scheduling a power action
- Live countdown while the timer is running
- Cancel button for scheduled shutdown/restart and in-app timers
- No terminal window
- Open source under the MIT License

## Features

| Feature | Supported |
| --- | --- |
| Schedule shutdown | Yes |
| Schedule restart | Yes |
| Schedule sleep | Yes |
| Schedule hibernate | Yes |
| Schedule lock | Yes |
| Schedule log off | Yes |
| Live countdown | Yes |
| Preset timers | Yes |
| Portable EXE | Yes |
| Installer required | No |

## Common Searches This App Solves

This project is meant to be a clean open-source answer for:

- Windows shutdown timer
- Windows shutdown scheduler
- Portable shutdown timer for Windows
- Tiny shutdown timer EXE
- Schedule Windows shutdown after 30 minutes
- Schedule Windows restart timer
- Windows sleep timer
- Windows hibernate timer
- Lock Windows after timer
- Log off Windows after timer

## How It Works

For shutdown and restart, the app uses Windows' built-in scheduler commands:

```text
shutdown /s /t <seconds>
shutdown /r /t <seconds>
shutdown /a
```

For hibernate, lock, and related actions, it uses standard Windows commands such as:

```text
shutdown /h
rundll32 user32.dll,LockWorkStation
```

Shutdown and restart timers are scheduled through Windows, so they can still run after closing the app. Sleep, hibernate, lock, and log off timers are handled by the app, so keep it open until the timer finishes.

Save your work before scheduling a shutdown, restart, sleep, hibernate, lock, or log off action.

## Build From Source

Requires Windows with the .NET Framework C# compiler.

```powershell
build.bat
```

The executable is created at:

```text
dist\Tiny Windows Shutdown Scheduler.exe
```

## Project Positioning

Tiny Windows Shutdown Scheduler is intentionally small. It is not an Electron app, not a Python bundle, and not a heavy automation suite. It focuses on one job: a fast, portable Windows shutdown scheduler that is easy to understand and easy to verify.

## License

MIT License. See [LICENSE](LICENSE).
