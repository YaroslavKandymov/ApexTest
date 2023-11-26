using Elementary;
using GameElements;
using UnityEngine;

namespace TankBattle.Mechanics
{
    public class TakeDamageMechanic : MonoBehaviour, IGameInitElement, IGameFinishElement
    {
        private const float AbsoluteValue = 1f;
        
        [SerializeField] private FloatEventReceiver _damageReceiver;
        [SerializeField] private FloatBehaviour _health;
        [SerializeField] private FloatBehaviour _defence;
        
        void IGameInitElement.InitGame(IGameContext context)
        {
            _damageReceiver.Event += OnEvent;
        }

        void IGameFinishElement.FinishGame(IGameContext context)
        {
            _damageReceiver.Event -= OnEvent;
        }

        private void OnEvent(float value)
        {
            _health.Minus(value * (AbsoluteValue - _defence.Value));
        }
    }
}