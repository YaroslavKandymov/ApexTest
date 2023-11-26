using GameElements;
using TankBattle.InputComponents;
using TankBattle.Interfaces;
using TankBattle.Services;
using Zenject;

namespace TankBattle.Player
{
    public class PlayerShooter : IGameInitElement, IGameFinishElement
    {
        [Inject] private KeyboardShootInput _keyboardShootInput;
        [Inject] private PlayerService _playerService;

        private IShootComponent _shootComponent;

        void IGameInitElement.InitGame(IGameContext context)
        {
            _shootComponent = _playerService.GetCharacter().Get<IShootComponent>();
            
            _keyboardShootInput.Clicked += OnClicked;
        }

        void IGameFinishElement.FinishGame(IGameContext context)
        {
            _keyboardShootInput.Clicked -= OnClicked;
        }

        private void OnClicked()
        {
            _shootComponent.Shoot();
        }
    }
}