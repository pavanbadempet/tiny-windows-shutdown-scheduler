using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace TinyWindowsShutdownScheduler
{
    public class MainForm : Form
    {
        private readonly NumericUpDown hoursInput;
        private readonly NumericUpDown minutesInput;
        private readonly ComboBox actionInput;
        private readonly Label countdownLabel;
        private readonly Label statusLabel;
        private readonly Timer countdownTimer;

        private DateTime scheduledAt;
        private string scheduledAction = "";
        private bool appScheduledAction;

        public MainForm()
        {
            Text = "Tiny Windows Shutdown Scheduler";
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(520, 360);
            BackColor = Color.FromArgb(246, 248, 251);
            Font = new Font("Segoe UI", 9F);

            var title = new Label
            {
                Text = "Tiny Windows Shutdown Scheduler",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.FromArgb(17, 24, 39),
                Location = new Point(22, 18),
                AutoSize = true
            };

            var about = new Button
            {
                Text = "About",
                Location = new Point(430, 22),
                Size = new Size(68, 30),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(233, 238, 247)
            };
            about.FlatAppearance.BorderSize = 0;
            about.Click += delegate { ShowAbout(); };

            var subtitle = new Label
            {
                Text = "Choose an action and delay. Confirm once, then keep this app open for non-shutdown actions.",
                ForeColor = Color.FromArgb(82, 92, 110),
                Location = new Point(24, 62),
                Size = new Size(470, 38)
            };

            AddPreset("15 min", 24, 108, 0, 15);
            AddPreset("30 min", 104, 108, 0, 30);
            AddPreset("1 hour", 184, 108, 1, 0);
            AddPreset("2 hours", 264, 108, 2, 0);
            AddPreset("Tonight", 344, 108, 0, MinutesUntilTonight());

            var actionLabel = MakeLabel("Action", 24, 154);
            actionInput = new ComboBox
            {
                Location = new Point(154, 150),
                Size = new Size(340, 26),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            actionInput.Items.AddRange(new object[] { "Shutdown", "Restart", "Sleep", "Hibernate", "Lock", "Log off" });
            actionInput.SelectedIndex = 0;

            var hoursLabel = MakeLabel("Hours", 24, 190);
            hoursInput = MakeNumberInput(154, 186, 0, 999, 0);

            var minutesLabel = MakeLabel("Minutes", 24, 226);
            minutesInput = MakeNumberInput(154, 222, 0, 59, 30);

            var schedule = new Button
            {
                Text = "Schedule",
                Location = new Point(24, 270),
                Size = new Size(230, 38),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                BackColor = Color.FromArgb(37, 99, 235),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            schedule.FlatAppearance.BorderSize = 0;
            schedule.Click += delegate { ScheduleAction(); };

            var cancel = new Button
            {
                Text = "Cancel",
                Location = new Point(266, 270),
                Size = new Size(230, 38),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.FromArgb(17, 24, 39),
                BackColor = Color.FromArgb(233, 238, 247),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            cancel.FlatAppearance.BorderSize = 0;
            cancel.Click += delegate { CancelAction(); };

            countdownLabel = new Label
            {
                Text = "",
                Location = new Point(24, 316),
                Size = new Size(180, 28),
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(17, 24, 39)
            };

            statusLabel = new Label
            {
                Text = "No action scheduled.",
                Location = new Point(210, 318),
                Size = new Size(286, 34),
                ForeColor = Color.FromArgb(75, 85, 99)
            };

            countdownTimer = new Timer();
            countdownTimer.Interval = 1000;
            countdownTimer.Tick += delegate { UpdateCountdown(); };

            Controls.AddRange(new Control[] {
                title, about, subtitle, actionLabel, actionInput, hoursLabel, hoursInput,
                minutesLabel, minutesInput, schedule, cancel, countdownLabel, statusLabel
            });
        }

        private Label MakeLabel(string text, int x, int y)
        {
            return new Label
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(120, 24),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(31, 41, 55)
            };
        }

        private NumericUpDown MakeNumberInput(int x, int y, int min, int max, int value)
        {
            return new NumericUpDown
            {
                Location = new Point(x, y),
                Size = new Size(340, 26),
                Minimum = min,
                Maximum = max,
                Value = value
            };
        }

        private void AddPreset(string text, int x, int y, int hours, int minutes)
        {
            var button = new Button
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(72, 30),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White
            };
            button.FlatAppearance.BorderColor = Color.FromArgb(210, 216, 226);
            button.Click += delegate
            {
                int total = hours * 60 + minutes;
                hoursInput.Value = total / 60;
                minutesInput.Value = total % 60;
            };
            Controls.Add(button);
        }

        private int MinutesUntilTonight()
        {
            DateTime now = DateTime.Now;
            DateTime target = new DateTime(now.Year, now.Month, now.Day, 23, 0, 0);
            if (target <= now)
            {
                target = target.AddDays(1);
            }
            return Math.Max(1, (int)(target - now).TotalMinutes);
        }

        private void ScheduleAction()
        {
            int seconds = ((int)hoursInput.Value * 60 + (int)minutesInput.Value) * 60;
            if (seconds <= 0)
            {
                MessageBox.Show("Enter at least 1 minute.", "Invalid time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            scheduledAction = actionInput.SelectedItem.ToString();
            scheduledAt = DateTime.Now.AddSeconds(seconds);
            string timeText = scheduledAt.ToString("h:mm tt");

            DialogResult confirm = MessageBox.Show(
                "Schedule " + scheduledAction.ToLowerInvariant() + " in " + FormatDuration(seconds) + "?\n\nTime: " + timeText,
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (confirm != DialogResult.Yes)
            {
                return;
            }

            appScheduledAction = scheduledAction != "Shutdown" && scheduledAction != "Restart";
            if (!appScheduledAction)
            {
                RunHidden("shutdown.exe", (scheduledAction == "Restart" ? "/r" : "/s") + " /t " + seconds);
            }

            statusLabel.Text = scheduledAction + " scheduled for " + timeText + ".";
            countdownTimer.Start();
            UpdateCountdown();
        }

        private void CancelAction()
        {
            countdownTimer.Stop();
            countdownLabel.Text = "";

            if (!appScheduledAction)
            {
                RunHidden("shutdown.exe", "/a");
            }

            statusLabel.Text = "Scheduled action canceled.";
            appScheduledAction = false;
            scheduledAction = "";
        }

        private void UpdateCountdown()
        {
            int remaining = (int)(scheduledAt - DateTime.Now).TotalSeconds;
            if (remaining <= 0)
            {
                countdownTimer.Stop();
                countdownLabel.Text = "Now";
                if (appScheduledAction)
                {
                    ExecuteImmediate(scheduledAction);
                }
                return;
            }

            countdownLabel.Text = FormatClock(remaining);
        }

        private string FormatClock(int totalSeconds)
        {
            int hours = totalSeconds / 3600;
            int minutes = (totalSeconds % 3600) / 60;
            int seconds = totalSeconds % 60;
            return hours > 0
                ? string.Format("{0}:{1:00}:{2:00}", hours, minutes, seconds)
                : string.Format("{0}:{1:00}", minutes, seconds);
        }

        private string FormatDuration(int totalSeconds)
        {
            int hours = totalSeconds / 3600;
            int minutes = (totalSeconds % 3600) / 60;
            if (hours > 0 && minutes > 0) return hours + " hour(s) " + minutes + " minute(s)";
            if (hours > 0) return hours + " hour(s)";
            return minutes + " minute(s)";
        }

        private void ExecuteImmediate(string action)
        {
            if (action == "Sleep")
            {
                RunHidden("rundll32.exe", "powrprof.dll,SetSuspendState 0,1,0");
            }
            else if (action == "Hibernate")
            {
                RunHidden("shutdown.exe", "/h");
            }
            else if (action == "Lock")
            {
                RunHidden("rundll32.exe", "user32.dll,LockWorkStation");
            }
            else if (action == "Log off")
            {
                RunHidden("shutdown.exe", "/l");
            }
        }

        private void RunHidden(string fileName, string arguments)
        {
            var process = new ProcessStartInfo(fileName, arguments);
            process.CreateNoWindow = true;
            process.UseShellExecute = false;
            process.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(process);
        }

        private void ShowAbout()
        {
            MessageBox.Show(
                "Tiny Windows Shutdown Scheduler 1.0.0\n\nTiny Windows utility for shutdown, restart, sleep, hibernate, lock, and log off timers.",
                "About Tiny Windows Shutdown Scheduler",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
