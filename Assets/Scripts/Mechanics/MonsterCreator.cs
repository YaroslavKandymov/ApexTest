using GameElements;
using TankBattle.Elementary;
using TankBattle.MonsterComponents;
using TankBattle.ScriptableObjects;
using UnityEngine;

namespace TankBattle.Mechanics
{
    public class MonsterCreator : MonoBehaviour, IGameInitElement, IGameFinishElement
    {
        [SerializeField] private ScriptableObjectEventReceiver _scriptableObjectEventReceiver;
        [SerializeField] private Transform _parent;

        public Monster Monster { get; private set; }

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
                Create(monsterData);
            }
        }

        private void Create(MonsterData monsterData)
        {
            Monster = Instantiate(monsterData.Prefab, _parent);
        }
    }
}