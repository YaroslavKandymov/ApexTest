using GameElements;
using TankBattle.Enums;
using TankBattle.InputComponents;
using TankBattle.Interfaces;
using TankBattle.Services;
using Zenject;

namespace TankBattle.Player
{
    public class PlayerWeaponSwitcher : IGameInitElement, IGameFinishElement
    {
        [Inject] private KeyboardSwitchWeaponInput _keyboardInput;
        [Inject] private PlayerService _playerService;

        private IWeaponSwitchComponent _weaponSwitchComponent;

        void IGameInitElement.InitGame(IGameContext context)
        {
            _weaponSwitchComponent = _playerService.GetCharacter().Get<IWeaponSwitchComponent>();
            
            _keyboardInput.NextButtonClicked += OnNextClicked;
            _keyboardInput.PreviousButtonClicked += OnPreviousClicked;
        }

        void IGameFinishElement.FinishGame(IGameContext context)
        {
            _keyboardInput.NextButtonClicked += OnNextClicked;
            _keyboardInput.PreviousButtonClicked += OnPreviousClicked;
        }

        private void OnNextClicked()
        {
            _weaponSwitchComponent.Switch(QueueMoveType.Next);
        }

        private void OnPreviousClicked()
        {
            _weaponSwitchComponent.Switch(QueueMoveType.Previous);
        }
    }
}