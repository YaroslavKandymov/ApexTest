using TankBattle.Elementary;
using TankBattle.Interfaces;
using UnityEngine;

namespace TankBattle.Components
{
    public class ChangeTransformComponent : MonoBehaviour, IChangeTransformComponent
    {
        [SerializeField] private Vector3EventReceiver _eventReceiver;
        
        public void Change(Vector3 value)
        {
            _eventReceiver.Call(value);
        }
    }
}