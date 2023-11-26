using System;
using UnityEngine;

namespace Elementary
{
    public sealed class EventReceiver : MonoBehaviour
    {
        public event Action Event;
        
        public void Call()
        {
            Event?.Invoke();
        }
    }
}