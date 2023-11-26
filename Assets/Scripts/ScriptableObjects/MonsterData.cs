using TankBattle.MonsterComponents;
using UnityEngine;

namespace TankBattle.ScriptableObjects
{
    [CreateAssetMenu(fileName = "new MonsterData", menuName = "StaticData/MonsterData", order = 1)]
    public class MonsterData : ScriptableObject
    {
        [SerializeField] private Monster _prefab;
        [Range(0, 100)][SerializeField] private int _health;
        [Range(0, 100)][SerializeField] private float _damage;
        [Range(0, 100)][SerializeField] private float _speed;
        [Range(0, 1)][SerializeField] private float _defenceValue;

        public Monster Prefab => _prefab;
        public int Health => _health;
        public float Damage => _damage;
        public float DefenceValue => _defenceValue;
        public float Speed => _speed;
    }
}