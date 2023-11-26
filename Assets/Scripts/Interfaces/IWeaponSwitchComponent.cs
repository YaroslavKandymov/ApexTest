using TankBattle.Enums;

namespace TankBattle.Interfaces
{
    public interface IWeaponSwitchComponent
    {
        public void Switch(QueueMoveType type);
    }
}