using System;
using UnityEngine;

namespace Elementary
{
    [DisallowMultipleComponent]
    public sealed class CollisionEventReceiver : MonoBehaviour
    {
        public event Action<Collision> CollisionEntered;

        public event Action<Collision> CollisionStaying; 

        public event Action<Collision> CollisionExited;
        
        private void OnCollisionEnter(Collision collision)
        {
            CollisionEntered?.Invoke(collision);
        }

        private void OnCollisionStay(Collision collision)
        {
            this.CollisionStaying?.Invoke(collision);
        }

        private void OnCollisionExit(Collision collision)
        {
            this.CollisionExited?.Invoke(collision);
        }
    }
}