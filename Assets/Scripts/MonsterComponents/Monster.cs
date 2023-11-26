using Elementary;
using UnityEngine;
using UnityEngine.AI;

namespace TankBattle.MonsterComponents
{
    public class Monster : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private TriggerEventReceiver _trigger;

        public NavMeshAgent NavMeshAgent => _navMeshAgent;
        public TriggerEventReceiver Trigger => _trigger;
        public float Damage { get; private set; }

        public void Init(float damage)
        {
            Damage = damage;
        }
    }
}