# Usage Guide

## Quick Start

1. **Download** the executable from the [Releases](https://github.com/pavanbadempet/Tiny-Windows-Shutdown-Scheduler/releases) page
2. **Run** the EXE file (no installation needed)
3. **Select** your action (Shutdown, Restart, Sleep, etc.)
4. **Set** the time (use presets or custom hours/minutes)
5. **Confirm** the action
6. **Wait** for the timer to count down or close the app

## Actions Explained

### Shutdown
Turns off your computer completely.
- Works after closing the app: ✅ Yes
- Requires admin rights: ⚠️ Sometimes

### Restart
Restarts your computer.
- Works after closing the app: ✅ Yes
- Requires admin rights: ⚠️ Sometimes

### Sleep
Puts your computer to sleep (low power mode, can wake with mouse/keyboard).
- Works after closing the app: ❌ No (keep app open)
- Requires admin rights: ❌ No

### Hibernate
Saves state to disk and turns off (uses more power than sleep, but preserves everything).
- Works after closing the app: ❌ No (keep app open)
- Requires admin rights: ❌ No

### Lock
Locks your user session (like pressing Windows+L).
- Works after closing the app: ❌ No (keep app open)
- Requires admin rights: ❌ No

### Log Off
Signs out of your Windows account.
- Works after closing the app: ❌ No (keep app open)
- Requires admin rights: ⚠️ Sometimes

## Setting the Timer

### Using Presets
Click one of the quick buttons:
- **15 min** - 15 minutes from now
- **30 min** - 30 minutes from now
- **1 hr** - 1 hour from now
- **2 hr** - 2 hours from now
- **Tonight** - Usually 23:59 or configured time

### Using Custom Time
1. Enter hours in the hours field
2. Enter minutes in the minutes field
3. Click the action button

### Maximum Time
The app supports any reasonable time duration (hours and minutes are customizable).

## Cancelling an Action

### Before Confirmation
Simply close the app without confirming.

### After Confirmation
Click the **Cancel** button in the app.

For shutdown/restart that has already been scheduled:
1. Open Command Prompt
2. Run: `shutdown /a`

## Live Countdown

Once you confirm an action, the app displays a live countdown showing:
- Time remaining
- Action that will be executed
- A cancel button

## Tips & Tricks

### For Shutdown/Restart
- These run through Windows scheduler, so you can close the app
- They'll still execute even if you turn off the monitor
- You can cancel with `shutdown /a` in Command Prompt

### For Sleep/Hibernate/Lock/Log Off
- Keep the app open or minimized
- Place the app on another monitor if you have multiple displays
- Consider pinning it to your taskbar for quick access

### Schedule for Later
- Calculate the time until you want the action
- Add that to your current time
- Enter the hours and minutes

### Multiple Timers
- Open the app multiple times to run several timers
- Each window will be independent

## Troubleshooting

### Timer Won't Execute
- **Shutdown/Restart**: Try running the app as administrator
- **Sleep/Hibernate/Lock/Log Off**: Keep the app open until completion
- Make sure you have enough permissions on your account

### App Won't Start
- Install/update .NET Framework
- Try running as administrator
- Check Windows Event Viewer for errors

### Timer Cancelled Unexpectedly
- Check if another program interfered
- Look for Windows update prompts
- Ensure you have proper permissions

---

**Need more help?** Check our [FAQ](FAQ.md) or visit [Discussions](https://github.com/pavanbadempet/Tiny-Windows-Shutdown-Scheduler/discussions)!
