using System;
using System.Collections;
using UnityEngine;

namespace Elementary
{
    [AddComponentMenu("Elementary/Stopwatch")]
    public sealed class StopwatchBehaviour : MonoBehaviour
    {
        public event Action OnStarted;

        public event Action OnTimeChanged;

        public event Action OnCanceled;

        public event Action OnReset;

        public bool IsPlaying { get; private set; }

        public float CurrentTime
        {
            get { return this.currentTime; }
            set { this.currentTime = Mathf.Max(value, 0); }
        }

        private float currentTime;

        private Coroutine coroutine;
        
        public void Play()
        {
            if (this.IsPlaying)
            {
                return;
            }

            this.IsPlaying = true;
            this.OnStarted?.Invoke();
            this.coroutine = this.StartCoroutine(this.TimerRoutine());
        }

        public void Stop()
        {
            if (this.coroutine != null)
            {
                this.StopCoroutine(this.coroutine);
            }

            if (this.IsPlaying)
            {
                this.IsPlaying = false;
                this.OnCanceled?.Invoke();
            }
        }
        
        public void ResetTime()
        {
            this.currentTime = 0;
            this.OnReset?.Invoke();
        }

        private IEnumerator TimerRoutine()
        {
            while (true)
            {
                yield return null;
                this.currentTime += Time.deltaTime;
                this.OnTimeChanged?.Invoke();
            }
        }
    }
}