using System;
using UnityEngine;

namespace TankBattle.Elementary
{
    public class Vector3EventReceiver : MonoBehaviour
    {
        public event Action<Vector3> Event;
        
        public void Call(Vector3 value)
        {
            Event?.Invoke(value);
        }
    }
}