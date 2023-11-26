using Elementary;
using GameElements;
using UnityEngine;

namespace TankBattle.Mechanics
{
    public class RestartMechanic : MonoBehaviour, IGameInitElement, IGameFinishElement
    {
        [SerializeField] private EventReceiver _eventReceiver;
        [SerializeField] private FloatBehaviour _currentHealth;
        [SerializeField] private FloatBehaviour _maxHealth;
        
        void IGameInitElement.InitGame(IGameContext context)
        {
            _eventReceiver.Event += OnEvent;
        }

        void IGameFinishElement.FinishGame(IGameContext context)
        {
            _eventReceiver.Event -= OnEvent;
        }

        private void OnEvent()
        {
            _currentHealth.Assign(_maxHealth.Value);
        }
    }
}