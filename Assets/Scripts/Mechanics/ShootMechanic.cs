using Elementary;
using GameElements;
using TankBattle.Factories;
using TankBattle.TankWeapons;
using UnityEngine;
using Zenject;

namespace TankBattle.Mechanics
{
    public class ShootMechanic : MonoBehaviour, IGameInitElement, IGameFinishElement
    {
        [SerializeField] private EventReceiver _shootReceiver;
        [SerializeField] private WeaponCollection _weaponCollection;

        [Inject] private BulletFactory _bulletFactory;
        
        void IGameInitElement.InitGame(IGameContext context)
        {
            _shootReceiver.Event += OnEnvent;
        }

        void IGameFinishElement.FinishGame(IGameContext context)
        {
            _shootReceiver.Event -= OnEnvent;
        }

        private void OnEnvent()
        {
            Shoot();
        }

        private void Shoot()
        {
            var bullet = _bulletFactory.Get();
            
            if(bullet == null)
                return;
            
            _weaponCollection.Shoot(bullet);
        }
    }
}