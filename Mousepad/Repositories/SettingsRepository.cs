using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Xml.Serialization;
using Gamepad;
using Mousepad.Models;

namespace Mousepad.Repositories
{
    class SettingsRepository
    {
        private Settings _settings;

        public Settings Get()
        {
            if (_settings != null)
                return _settings;

            string xmlPath = SettingsXMLFilePath();
            if (!File.Exists(xmlPath))
                return GetDefault();

            using (StreamReader myWriter = new StreamReader(xmlPath))
            {
                XmlSerializer mySerializer = new XmlSerializer(typeof(Settings));
                return (Settings) mySerializer.Deserialize(myWriter);
            }
        }

        public Settings GetDefault()
        {
            return new Settings
            {
                Mappings = new Settings.ButtonMappings
                {
                    XMapping = GamepadButtonAction.LeftClick,
                    BMapping = GamepadButtonAction.RightClick,
                    YMapping = GamepadButtonAction.MiddleClick,
                    StartMapping = GamepadButtonAction.ShowKeyboard,
                    LeftThumbOffsetMapping = GamepadThumbStickAction.MoveMouse,
                    RightThumbOffsetMapping = GamepadThumbStickAction.Scroll,
                    DpadUpMapping = GamepadButtonAction.MediaPause,
                    DpadDownMapping = GamepadButtonAction.Mute,
                    DpadLeftMapping = GamepadButtonAction.VolumeDown,
                    DpadRightMapping = GamepadButtonAction.VolumeUp
                },
                DisableGamepadCombination = new List<ButtonNames>
                {
                    ButtonNames.LeftThumb,
                    ButtonNames.RightThumb,
                    ButtonNames.Back
                }
            };
        }

        public void Save(Settings settings)
        {
            string xmlPath = SettingsXMLFilePath();
            if (!File.Exists(xmlPath))
                File.Create(xmlPath).Close();

            using (StreamWriter myWriter = new StreamWriter(xmlPath, false))
            {
                XmlSerializer mySerializer = new XmlSerializer(typeof(Settings));
                mySerializer.Serialize(myWriter, settings);
                _settings = settings;
            }
        }

        private string SettingsXMLFilePath()
        {
            return Path.GetFullPath(Application.Current.FindResource("SettingsPath").ToString());
        }
    }
}
