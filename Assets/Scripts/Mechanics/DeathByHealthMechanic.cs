using Elementary;
using Entities;
using GameElements;
using TankBattle.Services;
using UnityEngine;
using Zenject;

namespace TankBattle.Mechanics
{
    public class DeathByHealthMechanic : MonoBehaviour, IGameInitElement, IGameFinishElement
    {
        [SerializeField] private UnityEntity _entity;
        [SerializeField] private FloatBehaviour _health;

        [Inject] private DeathService _deathService;
        
        void IGameInitElement.InitGame(IGameContext context)
        {
            _health.ValueChanged += OnValueChanged;
        }

        void IGameFinishElement.FinishGame(IGameContext context)
        {
            _health.ValueChanged -= OnValueChanged;
        }

        private void OnValueChanged(float value)
        {
            if (value <= 0)
            {
                _deathService.Register(_entity);
                
                _entity.gameObject.SetActive(false);
            }
        }
    }
}