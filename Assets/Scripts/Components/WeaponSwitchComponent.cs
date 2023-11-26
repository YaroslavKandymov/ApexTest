using TankBattle.Elementary;
using TankBattle.Enums;
using TankBattle.Interfaces;
using UnityEngine;

namespace TankBattle.Components
{
    public class WeaponSwitchComponent : MonoBehaviour, IWeaponSwitchComponent
    {
        [SerializeField] private EnumEventReceiver _eventReceiver;
        
        public void Switch(QueueMoveType type)
        {
            _eventReceiver.Call(type);
        }
    }
}