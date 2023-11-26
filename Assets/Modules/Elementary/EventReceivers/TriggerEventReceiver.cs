using System;
using UnityEngine;

namespace Elementary
{
    [DisallowMultipleComponent]
    public sealed class TriggerEventReceiver : MonoBehaviour
    {
        public event Action<Collider> TriggerEntered;

        public event Action<Collider> TriggerStaying;

        public event Action<Collider> TriggerExited;
    
        private void OnTriggerEnter(Collider other)
        {
            this.TriggerEntered?.Invoke(other);
        }

        private void OnTriggerStay(Collider other)
        {
            this.TriggerStaying?.Invoke(other);
        }

        private void OnTriggerExit(Collider other)
        {
            this.TriggerExited?.Invoke(other);
        }
    }
}
