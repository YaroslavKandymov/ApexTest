using TankBattle.Elementary;
using TankBattle.Interfaces;
using UnityEngine;

namespace TankBattle.Components
{
    public class MoveToPointComponent : MonoBehaviour, IMoveToPointComponent
    {
        [SerializeField] private Vector3EventReceiver _eventReceiver;
        
        public void Move(Vector3 point)
        {
            _eventReceiver.Call(point);
        }
    }
}