using System;
using System.Collections;
using UnityEngine;

namespace TankBattle.BulletComponents
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private BulletMover _mover;
        [SerializeField] private float _disableTime;

        private Coroutine _coroutine;
        
        public BulletMover Mover => _mover;
        public float Damage { get; private set; }

        public void Init(float damage)
        {
            Damage = damage;
        }

        private void OnEnable()
        {
            _coroutine ??= StartCoroutine(Disable());
        }

        private void OnDisable()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }

        private IEnumerator Disable()
        {
            yield return new WaitForSeconds(_disableTime);

            if (gameObject.activeSelf == true)
                gameObject.SetActive(false);
        }
    }
}