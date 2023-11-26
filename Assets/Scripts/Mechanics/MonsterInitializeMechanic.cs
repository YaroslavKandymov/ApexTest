using Elementary;
using GameElements;
using TankBattle.Elementary;
using TankBattle.ScriptableObjects;
using UnityEngine;

namespace TankBattle.Mechanics
{
    public class MonsterInitializeMechanic : MonoBehaviour, IGameInitElement, IGameFinishElement
    {
        [SerializeField] private ScriptableObjectEventReceiver _scriptableObjectEventReceiver;
        [SerializeField] private FloatBehaviour _currentHealth;
        [SerializeField] private FloatBehaviour _maxHealth;
        [SerializeField] private FloatBehaviour _defenceValue;
        [SerializeField] private MonsterCreator _monsterCreator;

        void IGameInitElement.InitGame(IGameContext context)
        {
            _scriptableObjectEventReceiver.Event += OnEnvent;
        }

        void IGameFinishElement.FinishGame(IGameContext context)
        {
            _scriptableObjectEventReceiver.Event -= OnEnvent;
        }

        private void OnEnvent(ScriptableObject scriptableObject)
        {
            if (scriptableObject is MonsterData monsterData)
            {
                Initialize(monsterData);
            }
        }

        private void Initialize(MonsterData monsterData)
        {
            _currentHealth.Assign(monsterData.Health);
            _maxHealth.Assign(monsterData.Health);
            _monsterCreator.Monster.Init(monsterData.Damage);
            _defenceValue.Assign(monsterData.DefenceValue);
            _monsterCreator.Monster.NavMeshAgent.speed = monsterData.Speed;
        }
    }
}