using System.Windows;
using Gamepad;
using Mousepad.Models;
using Mousepad.Services;

namespace Mousepad.ViewModels
{
    class SettingsViewModel : ViewModelBase
    {
        private SettingsService _settingsService = (SettingsService) Application.Current.FindResource("SettingsService");

        public GamepadButtonAction LeftTriggerAction
        {
            get => GetMapping(ButtonNames.LeftTrigger);
            set => SetMapping(ButtonNames.LeftTrigger, value);
        }

        public GamepadButtonAction LeftShoulderAction
        {
            get => GetMapping(ButtonNames.LeftShoulder);
            set => SetMapping(ButtonNames.LeftShoulder, value);
        }

        public GamepadButtonAction BackAction
        {
            get => GetMapping(ButtonNames.Back);
            set => SetMapping(ButtonNames.Back, value);
        }

        public GamepadButtonAction LeftThumbStickAction
        {
            get => GetMapping(ButtonNames.LeftThumb);
            set => SetMapping(ButtonNames.LeftThumb, value);
        }

        public GamepadThumbStickAction LeftThumbStickMovementAction
        {
            get => GetThumbStickMapping(ButtonNames.LeftThumb);
            set => SetThumbStickMapping(ButtonNames.LeftThumb, value);
        }

        public GamepadButtonAction DpadUpAction
        {
            get => GetMapping(ButtonNames.DpadUp);
            set => SetMapping(ButtonNames.DpadUp, value);
        }

        public GamepadButtonAction DpadLeftAction
        {
            get => GetMapping(ButtonNames.DpadLeft);
            set => SetMapping(ButtonNames.DpadLeft, value);
        }

        public GamepadButtonAction DpadDownAction
        {
            get => GetMapping(ButtonNames.DpadDown);
            set => SetMapping(ButtonNames.DpadDown, value);
        }

        public GamepadButtonAction DpadRightAction
        {
            get => GetMapping(ButtonNames.DpadRight);
            set => SetMapping(ButtonNames.DpadRight, value);
        }

        public GamepadButtonAction RightTriggerAction
        {
            get => GetMapping(ButtonNames.RightTrigger);
            set => SetMapping(ButtonNames.RightTrigger, value);
        }

        public GamepadButtonAction RightShoulderAction
        {
            get => GetMapping(ButtonNames.RightShoulder);
            set => SetMapping(ButtonNames.RightShoulder, value);
        }

        public GamepadButtonAction StartAction
        {
            get => GetMapping(ButtonNames.Start);
            set => SetMapping(ButtonNames.Start, value);
        }

        public GamepadButtonAction RightThumbStickAction
        {
            get => GetMapping(ButtonNames.RightThumb);
            set => SetMapping(ButtonNames.RightThumb, value);
        }

        public GamepadThumbStickAction RightThumbStickMovementAction
        {
            get => GetThumbStickMapping(ButtonNames.RightThumb);
            set => SetThumbStickMapping(ButtonNames.RightThumb, value);
        }

        public GamepadButtonAction YAction
        {
            get => GetMapping(ButtonNames.Y);
            set => SetMapping(ButtonNames.Y, value);
        }

        public GamepadButtonAction XAction
        {
            get => GetMapping(ButtonNames.X);
            set => SetMapping(ButtonNames.X, value);
        }

        public GamepadButtonAction AAction
        {
            get => GetMapping(ButtonNames.A);
            set => SetMapping(ButtonNames.A, value);
        }

        public GamepadButtonAction BAction
        {
            get => GetMapping(ButtonNames.B);
            set => SetMapping(ButtonNames.B, value);
        }

        private GamepadButtonAction GetMapping(ButtonNames button) => _settingsService.GetButtonMapping(button);
        private GamepadThumbStickAction GetThumbStickMapping(ButtonNames button) => _settingsService.GetThumbStickMapping(button);

        private void SetMapping(ButtonNames button, GamepadButtonAction mapping) => _settingsService.UpdateButtonMapping(button, mapping);
        private void SetThumbStickMapping(ButtonNames button, GamepadThumbStickAction mapping) => _settingsService.UpdateThumbStickMapping(button, mapping);
    }
}
