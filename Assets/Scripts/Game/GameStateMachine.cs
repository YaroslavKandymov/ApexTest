using GameElements;
using TankBattle.Services;
using UnityEngine;
using Zenject;

namespace TankBattle.Game
{
    public class GameStateMachine : MonoBehaviour
    {
        [Inject] private IGameContext _gameContext;
        [Inject] private GameFinishService _gameFinishService;

        private void OnEnable()
        {
            _gameFinishService.PlayerDead += OnPlayerDead;
        }

        private void OnDisable()
        {
            _gameFinishService.PlayerDead -= OnPlayerDead;
        }

        private void Start()
        {
            _gameContext.InitGame();
            _gameContext.ReadyGame();
            _gameContext.StartGame();
        }

        private void OnPlayerDead()
        {
            _gameContext.FinishGame();
        }
    }
}