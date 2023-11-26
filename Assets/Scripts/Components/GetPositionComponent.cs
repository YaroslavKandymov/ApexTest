using TankBattle.Interfaces;
using UnityEngine;

namespace TankBattle.Components
{
    public class GetPositionComponent : MonoBehaviour, IGetPositionComponent
    {
        [SerializeField] private Transform _person;
        
        public Vector3 GetPosition()
        {
            return _person.position;
        }
    }
}