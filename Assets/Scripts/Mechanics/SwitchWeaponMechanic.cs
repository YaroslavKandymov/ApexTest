using System;
using GameElements;
using TankBattle.Elementary;
using TankBattle.Enums;
using TankBattle.TankWeapons;
using UnityEngine;

namespace TankBattle.Mechanics
{
    public class SwitchWeaponMechanic : MonoBehaviour, IGameInitElement, IGameFinishElement
    {
        [SerializeField] private EnumEventReceiver _eventReceiver;
        [SerializeField] private WeaponCollection _weaponCollection;
        
        void IGameInitElement.InitGame(IGameContext context)
        {
            _eventReceiver.Event += OnEvent;
        }

        void IGameFinishElement.FinishGame(IGameContext context)
        {
            _eventReceiver.Event -= OnEvent;
        }

        private void OnEvent(Enum type)
        {
            if (type is QueueMoveType queueMoveType)
            {
                Switch(queueMoveType);
            }
        }

        private void Switch(QueueMoveType queueMoveType)
        {
            switch (queueMoveType)
            {
                case QueueMoveType.Next:
                    _weaponCollection.TakeNextWeapon();
                    break;
                case QueueMoveType.Previous:
                    _weaponCollection.TakePreviousWeapon();
                    break;
                default:
                    throw new ArgumentException("Wrong type");
            }
        }
    }
}