using UnityEngine;

namespace TankBattle.BulletComponents
{
    public class BulletMover : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _force;

        public void Move(Vector3 direction)
        {
            _rigidbody.velocity = direction.normalized * _force;
        }
    }
}