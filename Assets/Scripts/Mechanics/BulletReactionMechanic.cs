using Elementary;
using GameElements;
using TankBattle.BulletComponents;
using UnityEngine;

namespace TankBattle.Mechanics
{
    public class BulletReactionMechanic : MonoBehaviour, IGameStartElement, IGameFinishElement
    {
        [SerializeField] private MonsterCreator _monsterCreator;
        [SerializeField] private FloatEventReceiver _damageReceiver;
        
        void IGameStartElement.StartGame(IGameContext context)
        {
            _monsterCreator.Monster.Trigger.TriggerEntered += OnTriggerEntered;
        }

        void IGameFinishElement.FinishGame(IGameContext context)
        {
            _monsterCreator.Monster.Trigger.TriggerEntered -= OnTriggerEntered;
        }

        private void OnTriggerEntered(Collider collider)
        {
            if (collider.TryGetComponent(out Bullet bullet))
            {
                _damageReceiver.Call(bullet.Damage);
                bullet.gameObject.SetActive(false);
            }
        }
    }
}