using Elementary;
using GameElements;
using TankBattle.MonsterComponents;
using UnityEngine;

namespace TankBattle.Mechanics
{
    public class CollisionDamageMechanic : MonoBehaviour, IGameInitElement, IGameFinishElement
    {
        [SerializeField] private CollisionEventReceiver _collisionReceiver;
        [SerializeField] private FloatEventReceiver _damage;
        
        void IGameInitElement.InitGame(IGameContext context)
        {
            _collisionReceiver.CollisionEntered += OnCollisionEntered;
        }

        void IGameFinishElement.FinishGame(IGameContext context)
        {
            _collisionReceiver.CollisionEntered -= OnCollisionEntered;
        }

        private void OnCollisionEntered(Collision collision)
        {
            if (collision.collider.TryGetComponent(out Monster monster))
            {
                _damage.Call(monster.Damage);
            }
        }
    }
}