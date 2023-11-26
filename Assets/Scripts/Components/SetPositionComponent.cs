using TankBattle.Elementary;
using TankBattle.Interfaces;
using UnityEngine;

namespace TankBattle.Components
{
    public class SetPositionComponent : MonoBehaviour, ISetPositionComponent
    {
        [SerializeField] private Vector3EventReceiver _eventReceiver;
        
        public void Set(Vector3 position)
        {
            _eventReceiver.Call(position);
        }
    }
}