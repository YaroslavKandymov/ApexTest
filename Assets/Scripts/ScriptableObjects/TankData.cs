using UnityEngine;

namespace TankBattle.ScriptableObjects
{
    [CreateAssetMenu(fileName = "new TankData", menuName = "StaticData/TankData", order = 2)]
    public class TankData : ScriptableObject
    {
        [Range(0, 100)][SerializeField] private int _health;
        [Range(0, 1)][SerializeField] private float _defenceValue;
        [Range(0, 100)][SerializeField] private float _speed;

        public int Health => _health;
        public float DefenceValue => _defenceValue;
        public float Speed => _speed;
    }
}