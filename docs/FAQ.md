# Frequently Asked Questions

## Installation & Setup

**Q: Do I need to install anything?**
A: No! The app is completely portable. Just download the EXE and run it. No installation, no admin rights required (though some features may need elevation).

**Q: What are the system requirements?**
A: Windows 7 or later, and .NET Framework (which is usually already installed). About 29 KB of disk space.

**Q: Can I run this on Windows 11?**
A: Yes, it works perfectly on Windows 11, Windows 10, and Windows 7+.

## Usage Questions

**Q: Can the shutdown run after I close the app?**
A: Yes, for shutdown and restart timers. These are scheduled through Windows and will run even if you close the app. For sleep, hibernate, lock, and log off, you need to keep the app open until the timer completes.

**Q: Can I set a custom time?**
A: Absolutely! You can enter any number of hours and minutes. There are also quick preset buttons for 15 min, 30 min, 1 hour, 2 hours, and "tonight".

**Q: Can I run multiple timers at once?**
A: Yes, you can open multiple instances of the app, each with its own independent timer.

**Q: How do I cancel a scheduled action?**
A: Click the "Cancel" button in the app. For shutdown/restart, the Windows scheduler will be cancelled. For other actions, closing the app will also cancel them.

## Safety & Security

**Q: Is this safe to use?**
A: Yes. The app uses Windows' native built-in commands. It includes a confirmation dialog before executing any power action. Always save your work before confirming.

**Q: Does this app collect any data?**
A: No. It's open source and completely offline. No telemetry, no analytics, no data collection.

**Q: Is it safe to use with antivirus software?**
A: Yes. Since it's open source and uses only native Windows commands, it should be safe. If your antivirus flags it, you can always build it yourself from source.

## Technical Questions

**Q: How does it work internally?**
A: It uses Windows' native `shutdown` command for shutdown/restart, and native Windows APIs for other actions. See the "How It Works" section in the README for details.

**Q: Can I use this with Task Scheduler?**
A: This app is simpler than Task Scheduler and designed for quick one-time timers. If you need recurring schedules, Task Scheduler is better suited.

**Q: What if I accidentally schedule a shutdown?**
A: Click the "Cancel" button immediately. If the app is closed, you can open Command Prompt and run: `shutdown /a`

**Q: Can I schedule actions at specific times?**
A: This app is designed for timers (X minutes/hours from now). For specific times, use Windows Task Scheduler instead.

## Troubleshooting

**Q: The app won't start**
A: Make sure you have .NET Framework installed. If you're still having issues, try running as administrator.

**Q: The shutdown won't trigger**
A: Ensure you have the proper permissions. Some actions may require administrator privileges. Try running the app as administrator.

**Q: The app closed unexpectedly**
A: This may have cancelled your timer. If you had scheduled a shutdown, you can cancel it with: `shutdown /a`

**Q: Can I use this on a network?**
A: The app is designed for local machine control only. It won't work on remote machines.

## Build & Development

**Q: Can I modify the source code?**
A: Yes! It's open source under the MIT License. You're free to modify and redistribute it.

**Q: How do I build it myself?**
A: See the "Build From Source" section in the README. You'll need Windows with the .NET Framework C# compiler.

**Q: Can I contribute?**
A: Absolutely! Please check our [Discussions](https://github.com/pavanbadempet/Tiny-Windows-Shutdown-Scheduler/discussions) or create an [Issue](https://github.com/pavanbadempet/Tiny-Windows-Shutdown-Scheduler/issues) with your ideas.

---

**Still have questions?** Visit our [Discussions](https://github.com/pavanbadempet/Tiny-Windows-Shutdown-Scheduler/discussions) page!
