using System;
using System.Collections;
using GameElements;
using TankBattle.Other;
using TankBattle.StringFields;
using UnityEngine;
using Zenject;

namespace TankBattle.InputComponents
{
    public class KeyboardAxisInput : IGameStartElement, IGameFinishElement
    {
        [Inject] private CoroutinePlayer _coroutinePlayer;

        private Coroutine _coroutine;

        public event Action<Vector3> DirectionChanged;

        void IGameStartElement.StartGame(IGameContext context)
        {
            _coroutine = _coroutinePlayer.Run(Move());
        }

        void IGameFinishElement.FinishGame(IGameContext context)
        {
            _coroutinePlayer.Stop(_coroutine);
        }

        private IEnumerator Move()
        {
            while (true)
            {
                float vertical = Input.GetAxis(Axis.Vertical);
                float horizontal = Input.GetAxis(Axis.Horizontal);

                var direction = new Vector3(vertical, horizontal);

                DirectionChanged?.Invoke(direction);

                yield return null;
            }
        }
    }
}