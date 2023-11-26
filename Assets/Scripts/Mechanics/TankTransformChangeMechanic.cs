using Elementary;
using GameElements;
using TankBattle.Elementary;
using UnityEngine;

namespace TankBattle.Mechanics
{
    public class TankTransformChangeMechanic : MonoBehaviour, IGameInitElement, IGameFinishElement
    {
        [SerializeField] private Vector3EventReceiver _directionReceiver;
        [SerializeField] private Transform _transform;
        [SerializeField] private FloatBehaviour _moveSpeed;
        [SerializeField] private FloatBehaviour _rotationSpeed;

        void IGameInitElement.InitGame(IGameContext context)
        {
            _directionReceiver.Event += OnEvent;
        }

        void IGameFinishElement.FinishGame(IGameContext context)
        {
            _directionReceiver.Event -= OnEvent;
        }

        private void OnEvent(Vector3 direction)
        {
            _transform.Translate(0, 0, direction.x * _moveSpeed.Value * Time.deltaTime);

            float rotationAmount = direction.y * _rotationSpeed.Value * Time.deltaTime;
            _transform.Rotate(0, rotationAmount, 0);
        }
    }
}