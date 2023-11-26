using System.Collections;
using UnityEngine;

namespace TankBattle.Other
{
    public class CoroutinePlayer : MonoBehaviour
    {
        public Coroutine Run(IEnumerator coroutine)
        {
            return StartCoroutine(RunCoroutine(coroutine));
        }

        public void Stop(Coroutine coroutine)
        {
            if(coroutine == null)
                return;
            
            StopCoroutine(coroutine);
        }

        private IEnumerator RunCoroutine(IEnumerator coroutine)
        {
            yield return coroutine;
        }
    }
}