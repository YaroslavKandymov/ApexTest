using System;
using Entities;
using GameElements;
using Zenject;

namespace TankBattle.Services
{
    public class GameFinishService : IGameInitElement, IGameFinishElement
    {
        [Inject] private PlayerService _playerService;
        [Inject] private DeathService _deathService;
        
        public event Action PlayerDead;

        void IGameInitElement.InitGame(IGameContext context)
        {
            _deathService.Dead += OnDead;
        }

        void IGameFinishElement.FinishGame(IGameContext context)
        {
            _deathService.Dead -= OnDead;
        }

        private void OnDead(IEntity entity)
        {
            if (_playerService.GetCharacter().Equals(entity))
            {
                PlayerDead?.Invoke();
            }
        }
    }
}