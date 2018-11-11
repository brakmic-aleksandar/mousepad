using System.Collections.Generic;
using System.Windows;
using Gamepad;
using Mousepad.Models;
using Mousepad.Repositories;

namespace Mousepad.Services
{
    public class SettingsService
    {
        private SettingsRepository _settingsRepository =
            (SettingsRepository) Application.Current.FindResource("SettingsRepository");

        public GamepadButtonAction GetButtonMapping(ButtonNames button) => _settingsRepository.Get()
            .GetActionForButton(button);

        public GamepadThumbStickAction GetThumbStickMapping(ButtonNames button) => _settingsRepository.Get()
            .GetThumbStickAction(button);

        public List<ButtonNames> GetDisableCombination() => _settingsRepository.Get().DisableGamepadCombination;

        public void UpdateButtonMapping(ButtonNames button, GamepadButtonAction action)
        {
            Settings settings = _settingsRepository.Get();
            settings.SetActionForButton(button, action);
            _settingsRepository.Save(settings);
        }

        public void UpdateThumbStickMapping(ButtonNames button, GamepadThumbStickAction action)
        {
            Settings settings = _settingsRepository.Get();
            settings.SetThumbStickAction(button, action);
            _settingsRepository.Save(settings);
        }

        public void UpdateDisableCombination(List<ButtonNames> combination)
        {
            Settings settings = _settingsRepository.Get();
            settings.DisableGamepadCombination = combination;
            _settingsRepository.Save(settings);
        }
    }
}
