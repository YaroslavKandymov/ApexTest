using System;
using System.Collections;
using GameElements;
using UnityEngine;

namespace TankBattle.InputComponents
{
    public class KeyboardSwitchWeaponInput : MonoBehaviour, IGameInitElement, IGameFinishElement
    {
        [SerializeField] private KeyCode _backwardInput = KeyCode.Q;
        [SerializeField] private KeyCode _forwardInput = KeyCode.W;

        private Coroutine _coroutine;

        public event Action PreviousButtonClicked;
        public event Action NextButtonClicked;

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
                if (Input.GetKeyDown(_backwardInput))
                {
                    PreviousButtonClicked?.Invoke();
                }

                if (Input.GetKeyDown(_forwardInput))
                {
                    NextButtonClicked?.Invoke();
                }

                yield return null;
            }
        }
    }
}