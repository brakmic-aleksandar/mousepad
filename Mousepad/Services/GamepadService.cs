using System;
using System.Collections.Generic;
using System.Linq;
using WindowsInput;
using WindowsInput.Native;
using Gamepad;
using Mousepad.Models;
using Application = System.Windows.Application;
using Cursor = System.Windows.Forms.Cursor;

namespace Mousepad.Services
{
    class GamepadService
    {
        private GamepadController _gamepadController = (GamepadController) Application.Current.Resources["GamepadController"];
        private SettingsService _settingsService = (SettingsService) Application.Current.Resources["SettingsService"];
        private OnScreenKeyboardService _onScreenKeyboardService = (OnScreenKeyboardService) Application.Current.Resources["OnScreenKeyboardService"];
        private InputSimulator _inputSimulator = new InputSimulator();

        private const float Multiplier = 2;
        private List<Gamepad.Gamepad> _disabledGamepads = new List<Gamepad.Gamepad>();

        public GamepadService()
        {
            _gamepadController.OnWhileGamepadThumbStickPositionNotZero += OnWhileGamepadThumbStickPositionNotZero;
            _gamepadController.OnGamepadButtonPressed += OnGamepadButtonPressed;
            _gamepadController.OnGamepadButtonReleased += OnGamepadButtonReleased;
        }

        private void OnWhileGamepadThumbStickPositionNotZero(object sender, WhileThumbStickPositionNotZeroEventArgs args)
        {
            if (IsGamepadEnabled((Gamepad.Gamepad) sender))
                PerformThumbOffset(args.ThumbStick.Name, args.ThumbStick.Magnitude, args.ThumbStick.X, args.ThumbStick.Y);
        }

        private void OnGamepadButtonPressed(object sender, ButtonPressedEventArgs args)
        {
            Gamepad.Gamepad gamepad = (Gamepad.Gamepad) sender;
            List<ButtonNames> pressedButtons = gamepad.PressedButtonNames;

            if (pressedButtons.Count == _settingsService.GetDisableCombination().Count && pressedButtons.All(i => _settingsService.GetDisableCombination().Contains(i)))
            {
                ToggleGamepadEnabled(gamepad);
                return;
            }

            if (IsGamepadEnabled((Gamepad.Gamepad) sender))
                PerformButtonPressedAction(args.Button.Name);
        }

        private void OnGamepadButtonReleased(object sender, ButtonReleasedEventArgs args)
        {
            if (IsGamepadEnabled((Gamepad.Gamepad) sender))
                PerformButtonReleasedAction(args.Button.Name);
        }

        private void ToggleGamepadEnabled(Gamepad.Gamepad gamepad)
        {
            if (IsGamepadEnabled(gamepad))
                DisableGamepad(gamepad);
            else
                EnableGamepad(gamepad);
        }

        private void EnableGamepad(Gamepad.Gamepad gamepad)
        {
            _disabledGamepads.Remove(gamepad);
        }

        private void DisableGamepad(Gamepad.Gamepad gamepad)
        {
            _disabledGamepads.Add(gamepad);
        }

        private bool IsGamepadEnabled(Gamepad.Gamepad gamepad)
        {
            return !_disabledGamepads.Contains(gamepad);
        }

        private void PerformThumbOffset(ButtonNames button, float magnitude, float x, float y)
        {
            GamepadThumbStickAction mapping = _settingsService.GetThumbStickMapping(button);
            switch (mapping)
            {
                case GamepadThumbStickAction.Scroll:
                    Cursor.Current.MoveWheel((int)(y / Math.Abs(y)));
                    break;
                case GamepadThumbStickAction.MoveMouse:
                    int sensitivity = 5 + (int)(Math.Log(magnitude / 10000) * 20); 
                    for (int i = 0; i < sensitivity; i++)
                        Cursor.Current.MoveBy((int)(x * Multiplier), -(int)(y * Multiplier));
                    break;
            }
        }

        private void PerformButtonPressedAction(ButtonNames button)
        {
            GamepadButtonAction mapping = _settingsService.GetButtonMapping(button);
            switch (mapping)
            {
                case GamepadButtonAction.None:
                    break;
                case GamepadButtonAction.LeftClick:
                    Cursor.Current.LeftMouseButtonDown();
                    break;
                case GamepadButtonAction.RightClick:
                    Cursor.Current.RightMouseButtonDown();
                    break;
                case GamepadButtonAction.MiddleClick:
                    Cursor.Current.MiddleMouseButtonDown();
                    break;
                case GamepadButtonAction.ShowKeyboard:
                    break;
                case GamepadButtonAction.MediaPause:
                    _inputSimulator.Keyboard.KeyDown(VirtualKeyCode.MEDIA_PLAY_PAUSE);
                    break;
                case GamepadButtonAction.MediaSkipForwards:
                    _inputSimulator.Keyboard.KeyDown(VirtualKeyCode.MEDIA_NEXT_TRACK);
                    break;
                case GamepadButtonAction.MediaGoBack:
                    _inputSimulator.Keyboard.KeyDown(VirtualKeyCode.MEDIA_PREV_TRACK);
                    break;
                case GamepadButtonAction.VolumeUp:
                    _inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VOLUME_UP);
                    break;
                case GamepadButtonAction.VolumeDown:
                    _inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VOLUME_DOWN);
                    break;
                case GamepadButtonAction.Mute:
                    _inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VOLUME_MUTE);
                    break;
            }
        }
  
        private void PerformButtonReleasedAction(ButtonNames button)
        {
            GamepadButtonAction mapping = _settingsService.GetButtonMapping(button);
            switch (mapping)
            {
                case GamepadButtonAction.None:
                    break;
                case GamepadButtonAction.LeftClick:
                    Cursor.Current.LeftMouseButtonUp();
                    break;
                case GamepadButtonAction.RightClick:
                    Cursor.Current.RightMouseButtonUp();
                    break;
                case GamepadButtonAction.MiddleClick:
                    Cursor.Current.MiddleMouseButtonUp();
                    break;
                case GamepadButtonAction.ShowKeyboard:
                    _onScreenKeyboardService.Toggle();
                    break;
                case GamepadButtonAction.MediaPause:
                    _inputSimulator.Keyboard.KeyUp(VirtualKeyCode.MEDIA_PLAY_PAUSE);
                    break;
                case GamepadButtonAction.MediaSkipForwards:
                    _inputSimulator.Keyboard.KeyUp(VirtualKeyCode.MEDIA_NEXT_TRACK);
                    break;
                case GamepadButtonAction.MediaGoBack:
                    _inputSimulator.Keyboard.KeyUp(VirtualKeyCode.MEDIA_PREV_TRACK);
                    break;
                case GamepadButtonAction.VolumeUp:
                    _inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VOLUME_UP);
                    break;
                case GamepadButtonAction.VolumeDown:
                    _inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VOLUME_DOWN);
                    break;
                case GamepadButtonAction.Mute:
                    _inputSimulator.Keyboard.KeyUp(VirtualKeyCode.VOLUME_MUTE);
                    break;
            }
        }
    }
}
