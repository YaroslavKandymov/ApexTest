using UnityEngine;

namespace TankBattle.TankWeapons
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private float _damage;

        public Transform ShootPoint => _shootPoint;
        public float Damage => _damage;
    }
}