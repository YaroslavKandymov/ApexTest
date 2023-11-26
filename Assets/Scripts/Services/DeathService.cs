using System;
using Entities;

namespace TankBattle.Services
{
    public class DeathService
    {
        public event Action<IEntity> Dead;

        public void Register(IEntity entity)
        {
            Dead?.Invoke(entity);
        }
    }
}