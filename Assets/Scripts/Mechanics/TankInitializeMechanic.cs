using Elementary;
using GameElements;
using TankBattle.Elementary;
using TankBattle.ScriptableObjects;
using UnityEngine;

namespace TankBattle.Mechanics
{
    public class TankInitializeMechanic : MonoBehaviour, IGameInitElement, IGameFinishElement
    {
        [SerializeField] private ScriptableObjectEventReceiver _dataReceiver;
        [SerializeField] private FloatBehaviour _health;
        [SerializeField] private FloatBehaviour _speed;
        [SerializeField] private FloatBehaviour _defence;
        
        void IGameInitElement.InitGame(IGameContext context)
        {
            _dataReceiver.Event += OnEvent;
        }

        void IGameFinishElement.FinishGame(IGameContext context)
        {
            _dataReceiver.Event -= OnEvent;
        }

        private void OnEvent(ScriptableObject data)
        {
            if (data is TankData tankData)
            {
                Initialize(tankData);
            }
        }

        private void Initialize(TankData tankData)
        {
            _health.Assign(tankData.Health);
            _speed.Assign(tankData.Speed);
            _defence.Assign(tankData.DefenceValue);
        }
    }
}