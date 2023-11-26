using GameElements;
using TankBattle.InputComponents;
using TankBattle.Interfaces;
using TankBattle.Services;
using UnityEngine;
using Zenject;

namespace TankBattle.Player
{
    public class PlayerMover : IGameInitElement, IGameFinishElement
    {
        [Inject] private KeyboardAxisInput _keyboardAxisInput;
        [Inject] private PlayerService _playerService;

        private IChangeTransformComponent _transformComponent;
        
        void IGameInitElement.InitGame(IGameContext context)
        {
            _transformComponent = _playerService.GetCharacter().Get<IChangeTransformComponent>();
            
            _keyboardAxisInput.DirectionChanged += OnDirectionChanged;
        }

        void IGameFinishElement.FinishGame(IGameContext context)
        {
            _keyboardAxisInput.DirectionChanged -= OnDirectionChanged;
        }

        private void OnDirectionChanged(Vector3 direction)
        {
            _transformComponent.Change(direction);
        }
    }
}