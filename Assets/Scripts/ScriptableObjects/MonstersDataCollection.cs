using System.Collections.Generic;
using UnityEngine;

namespace TankBattle.ScriptableObjects
{
    [CreateAssetMenu(fileName = "new MonstersDataCollection", menuName = "StaticData/MonstersDataCollection", order = 3)]
    public class MonstersDataCollection : ScriptableObject
    {
        [SerializeField] private MonsterData[] _monsterDatas;

        public IReadOnlyCollection<MonsterData> MonsterDatas => _monsterDatas;

        public MonsterData GetRandomData()
        {
            return _monsterDatas[Random.Range(0, _monsterDatas.Length)];
        }
    }
}