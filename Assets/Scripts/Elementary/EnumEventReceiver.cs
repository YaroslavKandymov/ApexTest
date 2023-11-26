using System;
using UnityEngine;

namespace TankBattle.Elementary
{
    public class EnumEventReceiver : MonoBehaviour
    {
        public event Action<Enum> Event;
        
        public void Call(Enum value)
        {
            Event?.Invoke(value);
        }
    }
}