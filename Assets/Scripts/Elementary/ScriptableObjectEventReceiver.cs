using System;
using UnityEngine;

namespace TankBattle.Elementary
{
    public class ScriptableObjectEventReceiver : MonoBehaviour
    {
        public event Action<ScriptableObject> Event;
        
        public void Call(ScriptableObject value)
        {
            Event?.Invoke(value);
        }
    }
}