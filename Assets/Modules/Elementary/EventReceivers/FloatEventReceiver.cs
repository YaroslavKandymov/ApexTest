using System;
using UnityEngine;

namespace Elementary
{
    public sealed class FloatEventReceiver : MonoBehaviour
    {
        public event Action<float> Event;
        
        public void Call(float value)
        {
            Event?.Invoke(value);
        }
    }
}