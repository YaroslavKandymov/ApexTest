using GameElements;
using TankBattle.Elementary;
using UnityEngine;

namespace TankBattle.Mechanics
{
    public class NavMeshMoveMechanic : MonoBehaviour, IGameInitElement, IGameFinishElement
    {
        [SerializeField] private Vector3EventReceiver _targetReceiver;
        [SerializeField] private MonsterCreator _monsterCreator;
        
        void IGameInitElement.InitGame(IGameContext context)
        {
            _targetReceiver.Event += OnEvent;
        }

        void IGameFinishElement.FinishGame(IGameContext context)
        {
            _targetReceiver.Event -= OnEvent;
        }

        private void OnEvent(Vector3 point)
        {
            _monsterCreator.Monster.NavMeshAgent.SetDestination(point);
        }
    }
}