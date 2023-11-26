using System;
using System.Collections;
using GameElements;
using UnityEngine;

namespace TankBattle.InputComponents
{
    public class KeyboardShootInput : MonoBehaviour, IGameInitElement, IGameFinishElement
    {
        [SerializeField] private KeyCode _shootCode = KeyCode.X;

        private Coroutine _coroutine;

        public event Action Clicked; 

        void IGameInitElement.InitGame(IGameContext context)
        {
            _coroutine = StartCoroutine(CheckInput());
        }

        void IGameFinishElement.FinishGame(IGameContext context)
        {
           StopCoroutine(_coroutine);
        }

        private IEnumerator CheckInput()
        {
            while (true)
            {
                if (Input.GetKeyDown(_shootCode))
                {
                    Clicked?.Invoke();
                }

                yield return null;
            }
        }
    }
}