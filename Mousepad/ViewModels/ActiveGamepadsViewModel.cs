using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Gamepad;

namespace Mousepad.ViewModels
{
    public class ActiveGamepadsViewModel : ViewModelBase
    {
        private GamepadController _gamepadController = (GamepadController) Application.Current.FindResource("GamepadController");

        public IList<Gamepad.Gamepad> ActiveGamepads => _gamepadController.Gamepads.Where(x => x.IsActive).ToList();

        public ActiveGamepadsViewModel()
        {
            _gamepadController.OnGamepadActivate += GamepadControllerActiveToggled;
            _gamepadController.OnGamepadDeactivate += GamepadControllerActiveToggled;
        }

        private void GamepadControllerActiveToggled(object sender, EventArgs eventArgs)
        {
            OnPropertyChanged(nameof(ActiveGamepads));
        }
    }
}
