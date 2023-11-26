using System.Collections.Generic;
using GameElements;
using TankBattle.BulletComponents;
using UnityEngine;

namespace TankBattle.TankWeapons
{
    public class WeaponCollection : MonoBehaviour, IGameInitElement
    {
        [SerializeField] private List<Weapon> _weapons;

        private Weapon _currentWeapon;
        private int _currentWeaponIndex;

        void IGameInitElement.InitGame(IGameContext context)
        {
            _currentWeaponIndex = 0;
            _currentWeapon = _weapons[_currentWeaponIndex];
        }

        public void Shoot(Bullet bullet)
        {
            bullet.Init(_currentWeapon.Damage);
            bullet.transform.position = _currentWeapon.ShootPoint.position;
            
            bullet.Mover.Move(_currentWeapon.ShootPoint.forward);
        }

        public void TakeNextWeapon()
        {
            _currentWeaponIndex++;

            if (_currentWeaponIndex > _weapons.Count - 1)
            {
                _currentWeaponIndex = 0;
            }
            
            _currentWeapon = _weapons[_currentWeaponIndex];
        }

        public void TakePreviousWeapon()
        {
            _currentWeaponIndex--;
            
            if (_currentWeaponIndex < 0)
            {
                _currentWeaponIndex = _weapons.Count - 1;
            }
            
            _currentWeapon = _weapons[_currentWeaponIndex];
        }
    }
}