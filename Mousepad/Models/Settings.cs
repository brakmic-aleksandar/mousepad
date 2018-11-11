using System;
using System.Collections.Generic;
using Gamepad;

namespace Mousepad.Models
{
    public class Settings
    {
        public bool HorizontalScrollingEnabled { get; set; } = true;
        public bool VerticalScrollingEnabled { get; set; } = true;
        public ButtonMappings Mappings { get; set; }
        public List<ButtonNames> DisableGamepadCombination { get; set; }

        public GamepadButtonAction GetActionForButton(ButtonNames button)
        {
            switch (button)
            {
                case ButtonNames.DpadUp:
                    return Mappings.DpadUpMapping;
                case ButtonNames.DpadDown:
                    return Mappings.DpadDownMapping;
                case ButtonNames.DpadLeft:
                    return Mappings.DpadLeftMapping;
                case ButtonNames.DpadRight:
                    return Mappings.DpadRightMapping;
                case ButtonNames.Start:
                    return Mappings.StartMapping;
                case ButtonNames.Back:
                    return Mappings.BackMapping;
                case ButtonNames.LeftThumb:
                    return Mappings.LeftThumbMapping;
                case ButtonNames.RightThumb:
                    return Mappings.RightThumbMapping;
                case ButtonNames.LeftShoulder:
                    return Mappings.LeftShoulderMapping;
                case ButtonNames.RightShoulder:
                    return Mappings.RightShoulderMapping;
                case ButtonNames.A:
                    return Mappings.AMapping;
                case ButtonNames.B:
                    return Mappings.BMapping;
                case ButtonNames.X:
                    return Mappings.XMapping;
                case ButtonNames.Y:
                    return Mappings.YMapping;
                case ButtonNames.LeftTrigger:
                    return Mappings.LeftTriggerMapping;
                case ButtonNames.RightTrigger:
                    return Mappings.RightTriggerMapping;
                default:
                    throw new ArgumentException();
            }
        }

        public GamepadThumbStickAction GetThumbStickAction(ButtonNames button)
        {
            switch (button)
            {
                case ButtonNames.LeftThumb:
                    return Mappings.LeftThumbOffsetMapping;
                case ButtonNames.RightThumb:
                    return Mappings.RightThumbOffsetMapping;
                default:
                    throw new ArgumentException();
            }
        }

        public void SetThumbStickAction(ButtonNames button, GamepadThumbStickAction action)
        {
            switch (button)
            {
                case ButtonNames.LeftThumb:
                    Mappings.LeftThumbOffsetMapping = action;
                    break;
                case ButtonNames.RightThumb:
                    Mappings.RightThumbOffsetMapping = action;
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        public void SetActionForButton(ButtonNames button, GamepadButtonAction action)
        {
            switch (button)
            {
                case ButtonNames.DpadUp:
                    Mappings.DpadUpMapping = action;
                    break;
                case ButtonNames.DpadDown:
                    Mappings.DpadDownMapping = action;
                    break;
                case ButtonNames.DpadLeft:
                    Mappings.DpadLeftMapping = action;
                    break;
                case ButtonNames.DpadRight:
                    Mappings.DpadRightMapping = action;
                    break;
                case ButtonNames.Start:
                    Mappings.StartMapping = action;
                    break;
                case ButtonNames.Back:
                    Mappings.BackMapping = action;
                    break;
                case ButtonNames.LeftThumb:
                    Mappings.LeftThumbMapping = action;
                    break;
                case ButtonNames.RightThumb:
                    Mappings.RightThumbMapping = action;
                    break;
                case ButtonNames.LeftShoulder:
                    Mappings.LeftShoulderMapping = action;
                    break;
                case ButtonNames.RightShoulder:
                    Mappings.RightShoulderMapping = action;
                    break;
                case ButtonNames.A:
                    Mappings.AMapping = action;
                    break;
                case ButtonNames.B:
                    Mappings.BMapping = action;
                    break;
                case ButtonNames.X:
                    Mappings.XMapping = action;
                    break;
                case ButtonNames.Y:
                    Mappings.YMapping = action;
                    break;
                case ButtonNames.LeftTrigger:
                    Mappings.LeftTriggerMapping = action;
                    break;
                case ButtonNames.RightTrigger:
                    Mappings.RightTriggerMapping = action;
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        public class ButtonMappings
        {
            public GamepadButtonAction XMapping { get; set; }
            public GamepadButtonAction YMapping { get; set; }
            public GamepadButtonAction AMapping { get; set; }
            public GamepadButtonAction BMapping { get; set; }
            public GamepadButtonAction LeftTriggerMapping { get; set; }
            public GamepadButtonAction RightTriggerMapping { get; set; }
            public GamepadButtonAction DpadUpMapping { get; set; }
            public GamepadButtonAction DpadDownMapping { get; set; }
            public GamepadButtonAction DpadLeftMapping { get; set; }
            public GamepadButtonAction DpadRightMapping { get; set; }
            public GamepadButtonAction StartMapping { get; set; }
            public GamepadButtonAction BackMapping { get; set; }
            public GamepadButtonAction LeftShoulderMapping { get; set; }
            public GamepadButtonAction RightShoulderMapping { get; set; }
            public GamepadButtonAction LeftThumbMapping { get; set; }
            public GamepadButtonAction RightThumbMapping { get; set; }
            public GamepadThumbStickAction LeftThumbOffsetMapping { get; set; }
            public GamepadThumbStickAction RightThumbOffsetMapping { get; set; }
        }
    }
}
