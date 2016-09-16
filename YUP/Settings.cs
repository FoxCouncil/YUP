using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Ca.Magrathean.Yup
{
    public static class Settings
    {
        // Global Setting
        public static Color DigitalDisplayColor
        {
            get
            {
                Color displayColor = YUP.SettingsDatabase.GetColorSetting("DigitalDisplayColor");

                if (displayColor == Color.Empty)
                {
                    YUP.SettingsDatabase.SetColorSetting("DigitalDisplayColor", Color.LimeGreen);
                    return Color.LimeGreen;
                }
                else
                {
                    return displayColor;
                }
            }
            set
            {
                YUP.SettingsDatabase.SetColorSetting("DigitalDisplayColor", value);
                YUP.MainForm.DisplaysColor = value;
            }
        }

        // Global Setting
        public static int YUPVolume
        {
            get
            {
                int? yupVolume = YUP.SettingsDatabase.GetIntegerSetting("YUPVolume");

                if (yupVolume == null)
                {
                    YUP.SettingsDatabase.SetIntegerSetting("YUPVolume", 8);
                    
                    return 8;
                }
                else
                {
                    return yupVolume.Value;
                }
            }
            set
            {
                if (YUP.MainForm.FlashPlayer.Volume != value)
                {
                    YUP.SettingsDatabase.SetIntegerSetting("YUPVolume", value);

                    YUP.MainForm.FlashPlayer.Volume = value;
                }
            }
        }

        public static int YUPSpinnerSegments
        {
            get
            {
                int? yupVolume = YUP.SettingsDatabase.GetIntegerSetting("YUPSpinnerSegments");

                if (yupVolume == null)
                {
                    YUP.SettingsDatabase.SetIntegerSetting("YUPSpinnerSegments", 12);

                    return 12;
                }
                else
                {
                    return yupVolume.Value;
                }
            }
            set
            {
                YUP.SettingsDatabase.SetIntegerSetting("YUPSpinnerSegments", value);

                YUP.MainForm.DisplaySegments = value;
            }
        }

        // Global Setting
        public static bool PauseWhenMinimized
        {
            get
            {
                bool? pauseWhenMinimized = YUP.SettingsDatabase.GetBoolSetting("PauseWhenMinimized");

                if (pauseWhenMinimized == null)
                {
                    YUP.SettingsDatabase.SetBoolSetting("PauseWhenMinimized", false);
                    return false;
                }
                else
                {
                    return pauseWhenMinimized.Value;
                }
            }
            set
            {
                YUP.SettingsDatabase.SetBoolSetting("PauseWhenMinimized", value);
            }
        }

        // Global Setting
        public static bool MaintainVideoSizeRatio
        {
            get
            {
                bool? maintaining = YUP.SettingsDatabase.GetBoolSetting("MaintainVideoSizeRatio");

                if (maintaining == null)
                {
                    YUP.SettingsDatabase.SetBoolSetting("MaintainVideoSizeRatio", true);
                    return true;
                }
                else
                {
                    return maintaining.Value;
                }
            }
            set
            {
                YUP.SettingsDatabase.SetBoolSetting("MaintainVideoSizeRatio", value);
                YUP.MainForm.FlashPlayer.MaintainAspectRatio(value);
            }
        }

        // Global Setting
        public static bool RewindVideo
        {
            get
            {
                bool? rewindVideo = YUP.SettingsDatabase.GetBoolSetting("RewindVideo");

                if (rewindVideo == null)
                {
                    YUP.SettingsDatabase.SetBoolSetting("RewindVideo", true);
                    return true;
                }
                else
                {
                    return rewindVideo.Value;
                }
            }
            set
            {
                YUP.SettingsDatabase.SetBoolSetting("RewindVideo", value);
                YUP.MainForm.FlashPlayer.RewindVideo(value);
            }
        }

        // Global Setting
        public static bool HDEnabled
        {
            get
            {
                bool? hdEnabled = YUP.SettingsDatabase.GetBoolSetting("HDEnabled");

                if (hdEnabled == null)
                {
                    YUP.SettingsDatabase.SetBoolSetting("HDEnabled", false);
                    return false;
                }
                else
                {
                    return hdEnabled.Value;
                }
            }
            set
            {
                YUP.SettingsDatabase.SetBoolSetting("HDEnabled", value);
            }
        }

        // Global Setting
        public static bool YUPDisplayStatus
        {
            get
            {
                bool? displayStatus = YUP.SettingsDatabase.GetBoolSetting("DisplayStatus");

                if (displayStatus == null)
                {
                    YUP.SettingsDatabase.SetBoolSetting("DisplayStatus", true);
                    return true;
                }
                else
                {
                    return displayStatus.Value;
                }
            }
            set
            {
                
                YUP.SettingsDatabase.SetBoolSetting("DisplayStatus", value);
            }
        }

        public static string YUPExporterPath
        {
            get
            {
                string exporterPath = YUP.SettingsDatabase.GetStringSetting("ExporterPath");

                if (exporterPath == null)
                {
                    string defaultPath = YUP.CommonAppDataPath + @"\ffmpeg.exe";

                    YUP.SettingsDatabase.SetStringSetting("ExporterPath", defaultPath);

                    return defaultPath;
                }

                return exporterPath;
            }
            set
            {
                YUP.SettingsDatabase.SetStringSetting("ExporterPath", value);
            }
        }

        // Global Setting
        public static YUPDisplay YUPDisplayStyle
        {
            get
            {
                int? displayStyle = YUP.SettingsDatabase.GetIntegerSetting("YUPDisplayStyle");

                if (displayStyle == null)
                {
                    YUP.SettingsDatabase.SetIntegerSetting("YUPDisplayStyle", (int)YUPDisplay.Taskbar);
                    return YUPDisplay.Taskbar;
                }
                else
                {
                    return (YUPDisplay)displayStyle.Value;
                }
            }
            set
            {
                YUP.SettingsDatabase.SetIntegerSetting("YUPDisplayStyle", (int)value);

                switch (value)
                {
                    case YUPDisplay.Taskbar:
                        {
                            YUP.MainForm.ShowInTaskbar = true;
                            YUP.MainForm.systrayIcon.Visible = false;
                        }
                        break;

                    case YUPDisplay.SystemTray:
                        {
                            YUP.MainForm.ShowInTaskbar = false;
                            YUP.MainForm.systrayIcon.Visible = true;
                        }
                        break;

                    case YUPDisplay.Both:
                        {
                            YUP.MainForm.ShowInTaskbar = true;
                            YUP.MainForm.systrayIcon.Visible = true;
                        }
                        break;
                }

                YUP.MainForm.ActivateChildWindows();
            }
        }
    }
}
